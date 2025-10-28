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
            <div class="employee-table mt-5 border-2 border-blue-900 rounded-xl py-2 p-4 max-w-7xl m-auto">
                <div class="header-row">
                    <span>Nome</span>
                    <span>Cargo</span>
                </div>
                <ul>
                    <li v-for="employee in filteredEmployees" :key="employee.employeeId"
                        class="employee-item w-[50%] justify-between py-3 mt-2 mb-2 p-4 border-2 border-blue-900 rounded-lg text-gray-300 hover:text-white hover:border-blue-400 duration-100">

                        <div class="w-full">
                            <p><i class="fi fi-rr-user text-base p-2"></i>{{ employee.name }}</p>
                        </div>

                        <div class="w-full">
                            <p><i class="fi fi-rr-code-simple text-base p-2"></i>{{ employee.position }}</p>
                        </div>
                    </li>
                </ul>
            </div>
            <p class="mt-4">Total exibido: {{ filteredEmployees.length }}</p>
        </div>


    </div>
</template>
