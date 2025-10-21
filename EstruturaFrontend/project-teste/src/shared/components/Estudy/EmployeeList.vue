<script setup lang="ts">
import { useEmployeeStore } from '@/shared/stores/EmployeeStore';

const employeeStore = useEmployeeStore();
</script>

<template>
    <div class="p-4 w-full rounded-lg bg-gray-600 shadow-md">
        <h2 class="text-xl mb-2 text-gray-200">Lista de Funcionários ({{ employeeStore.totalEmployees() }})</h2>

        <div class="h-[280px] overflow-y-auto pr-2">

            <div v-if="employeeStore.employees.length === 0" class="text-center p-8 text-gray-200 italic">
                Nenhum funcionário cadastrado ainda.
            </div>

            <div v-else class="space-y-3">
                <div v-for="employee in employeeStore.employees" :key="employee.id"
                    class="p-4 border-l-4 border-gray-200 bg-gray-300 rounded-lg shadow-sm hover:shadow-md transition-shadow">
                    <p class="font-bold text-lg text-gray-800">{{ employee.name }}</p>
                    <p class="text-sm text-gray-600">Cargo: {{ employee.role }}</p>
                    <p class="text-xs text-gray-500">ID: {{ employee.id }}</p>
                </div>
            </div>
        </div>
    </div>
</template>