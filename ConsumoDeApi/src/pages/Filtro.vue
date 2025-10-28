<script setup lang="ts">
import { onMounted } from 'vue';
import { storeToRefs } from 'pinia';
import { useEmployeeStore } from '@/shared/stores/employee.store';

const store = useEmployeeStore();
const {
    filteredEmployees,
    isLoading,
    error,
    uniquePositions,
    positionFilter
} = storeToRefs(store);

onMounted(() => {
    store.loadEmployees();
});

function handlePositionChange(event: Event) {
    const target = event.target as HTMLSelectElement;
    store.setPositionFilter(target.value);
}
</script>

<template>
    <section class="w-full bg-gray-900 min-h-screen text-gray-200 py-10 p-10">
        <div>
            <h1>Lista de Funcionários (Filtro Front-end)</h1>

            <select :value="positionFilter" @change="handlePositionChange" class="filter-dropdown">
                <option value="">-- Filtrar por Cargo (Todos) --</option>
                <option v-for="position in uniquePositions" :key="position" :value="position">
                    {{ position }}
                </option>
            </select>

            <div v-if="isLoading">
                <p>Carregando dados completos da API...</p>
            </div>

            <div v-else-if="error">
                <p class="error-message">Erro ao carregar: {{ error }}</p>
            </div>

            <div v-else>
                <div class="employee-table">
                    <div class="header-row">
                        <span>Nome</span>
                        <span>Cargo</span>
                    </div>
                    <div v-for="employee in filteredEmployees" :key="employee.employeeId" class="data-row">
                        <span>{{ employee.name }}</span>
                        <span>{{ employee.position }}</span>
                    </div>
                </div>
                <p class="mt-4">Total exibido: {{ filteredEmployees.length }}</p>
            </div>
        </div>
    </section>

</template>
