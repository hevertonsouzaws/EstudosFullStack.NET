<template>
    <div class="p-2 max-w-7xl m-auto">
        <div
            class="w-full text-center text-lg font-semibold flex justify-evenly p-5 border-t-2 border-b-2 border-blue-600 rounded-xl">

            <div class="border border-gray-400 rounded-xl text-center w-40 h-20 flex flex-col justify-center">
                <span><i class="fi fi-rr-user text-2xl p-2"></i></span>
                <h1 class="mb-1 text-sm">WS´s</h1>
            </div>

            <div class="border border-gray-400 rounded-xl text-center w-40 h-20 flex flex-col justify-center">
                <span><i class="fi fi-rr-check text-xl p-2"></i></span>
                <h1>{{ employeeStore.totalEmployees }}</h1>
            </div>

            <div
                class="border border-gray-400 rounded-xl text-center w-40 h-20 flex flex-col justify-center hover:scale-105 hover:border-blue-400 duration-200 cursor-pointer">
                <button @click="handleExportPDF
                ">
                    <span><i class="fi fi-rr-file-pdf text-2xl p-2 hover:text-[28px] duration-300"></i></span>
                    <h1 class="text-sm hover:text-white">Baixar</h1>
                </button>
            </div>
        </div>

        <div v-if="employeeStore.isLoading" class="p-4 mt-2 rounded-xl text-center w-[50%] m-auto">
            <p>Buscando Dados...</p>
        </div>

        <div v-else-if="employeeStore.error" class="mt-10 w-[60%] m-auto flex flex-col items-center gap-5">
            <p class="p-4 border border-red-800 rounded-full bg-red-900/20">Falha: {{ employeeStore.error }}</p>
            <button class=" mb-5 p-2 bg-blue-900 rounded-xl hover:bg-blue-700"
                @click="employeeStore.loadEmployees()">Tentar novamente</button>
        </div>

        <div v-else-if="employeeStore.totalEmployees > 0" class="mt-5 border-2 border-blue-900 rounded-xl py-2 p-4">
            <ul>
                <li v-for="employee in employeeStore.employees" :key="employee.employeeId"
                    class="employee-item flex justify-between py-3 mt-2 mb-2 p-4 border-2 border-blue-900 rounded-lg text-gray-300 hover:text-white hover:border-blue-400 duration-100">

                    <div class="w-full">
                        <p><i class="fi fi-rr-user text-base p-2"></i>{{ employee.name }}</p>
                    </div>

                    <div class="w-full">
                        <p><i class="fi fi-rr-code-simple text-base p-2"></i>{{ employee.position }}</p>
                    </div>

                    <div class="w-full">
                        <p><i class="fi fi-rr-clock text-base p-2"></i>{{ formateDate(employee.createdAt) }}</p>
                    </div>

                    <div class="w-[40%]">
                        <p v-if="employee.isActive"><i class="fi fi-rr-check text-base p-2"></i>ativo</p>
                    </div>
                </li>
            </ul>

            <div class="py-5 p-2 max-w-7xl m-auto border-t-2 rounded-xl mt-10">
                <p class="text-center">Galeria</p>
                <div class="flex flex-wrap justify-center items-center gap-8 max-w-full m-auto p-10">
                    <div v-for="employee in employeeStore.employees" :key="employee.employeeId"
                        class="flex flex-col items-center cursor-pointer transition-transform transform hover:scale-105 duration-300 saturate-0 hover:saturate-100">
                        <div
                            class="w-[80px] h-[80px] rounded-full overflow-hidden border-2 border-transparent hover:border-red-500 transition-colors duration-300 ">
                            <img :src="employee.photo" :alt="employee.name" class="w-full h-full object-cover ">
                        </div>
                    </div>
                    <div v-for="employee in employeeStore.inactiveEmployees" :key="employee.employeeId"
                        class="flex flex-col items-center cursor-pointer transition-transform transform hover:scale-105 duration-300 saturate-0 hover:saturate-100">
                        <div
                            class="w-[80px] h-[80px] rounded-full overflow-hidden border-2 border-transparent hover:border-red-500 transition-colors duration-300">
                            <img :src="employee.photo" :alt="employee.name" class="w-full h-full object-cover ">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</template>

<script setup lang="ts">
import { storeToRefs } from 'pinia';
import { onMounted } from 'vue';
import { useEmployeeStore } from '@/shared/stores/employee.store';
import { formateDate } from '@/shared/helpers/dateFormatter';
import { exportEmployeesToPDF } from '@/shared/helpers/pdfExporter';

const employeeStore = useEmployeeStore()

const { employees, inactiveEmployees, isLoading, error } = storeToRefs(employeeStore);

const { loadEmployees, loadInactiveEmployees } = employeeStore;

function handleExportPDF() {
    exportEmployeesToPDF(employees.value, 'Relatório Geral');
}

onMounted(() => {
    employeeStore.loadEmployees();
    employeeStore.loadInactiveEmployees();
});
</script>