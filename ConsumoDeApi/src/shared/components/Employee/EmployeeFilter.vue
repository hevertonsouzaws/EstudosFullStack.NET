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
    <div class="mt-10 py-2 p-2 w-[80%] m-auto">
        <div class="flex w-full justify-center items-center gap-5 p-4 rounded-lg">
            <select :value="positionFilter" @change="handlePositionChange"
                class="bg-gray-900 cursor-pointer border border-blue-400 rounded-lg p-3 w-80 text-blue-500">
                <option class="bg-gray-800" value="">Todos</option>
                <div class="cursor-pointer">
                    <option v-for="position in uniquePositions" :key="position" :value="position"
                        class="text-gray-200 bg-gray-900">
                        <p>{{ position }}</p>
                    </option>
                </div>
            </select>
            <div class="bg-gray-900 cursor-pointer border border-blue-400 rounded-lg py-2.5 w-80 text-center">
                <p class="text-lg"><i class="fi fi-rr-user text-base p-2"></i>{{ filteredEmployees.length }}</p>
            </div>
        </div>

        <div v-if="isLoading">
            <p>Carregando dados...</p>
        </div>

        <div v-else-if="error">
            <p class="error-message">Erro ao carregar: {{ error }}</p>
        </div>

        <div v-else>
            <div class="mt-5 border-2 border-blue-900 rounded-xl py-3 p-2 max-w-full m-auto">
                <ul class="flex flex-wrap gap-y-3 gap-4 items-center justify-right pl-5">
                    <li v-for="employee in filteredEmployees" :key="employee.employeeId"
                        class="min-w-[32%] py-3 p-4 border-2 border-blue-900 rounded-lg text-gray-300 hover:text-white hover:border-blue-400 duration-100">

                        <div class="w-[full]">
                            <p><i class="fi fi-rr-user text-base p-2"></i>{{ employee.name }}</p>
                            <p><i class="fi fi-rr-code-simple text-base p-2"></i>{{ employee.position }}</p>
                        </div>

                        <div class="w-[full]">

                        </div>
                    </li>
                </ul>
            </div>
        </div>

    </div>
</template>
