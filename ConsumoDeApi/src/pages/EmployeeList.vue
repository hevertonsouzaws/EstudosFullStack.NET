<script setup lang="ts">
import { onMounted } from 'vue';
import { storeToRefs } from 'pinia';
import { useEmployeeStore } from '@/shared/stores/employee.store';

const employeeStore = useEmployeeStore()

const { employees, inactiveEmployees, isLoading, error } = storeToRefs(employeeStore);

const { loadEmployees, loadInactiveEmployees } = employeeStore;

onMounted(() => {
    employeeStore.loadEmployees();
    employeeStore.loadInactiveEmployees();
});

</script>

<template>
    <section class="w-full bg-gray-900 min-h-screen text-gray-200 py-20 p-10">

        <div class="py-5 p-2 max-w-7xl m-auto border-2 border-blue-900 rounded-2xl">

            <div class="w-full text-center text-xl font-semibold flex justify-evenly border-b border-blue-400 p-5">

                <div class="border border-blue-400  rounded-full text-center flex items-center justify-center p-2">
                    <span><i class="fi fi-rr-form text-2xl p-2"></i></span>
                    <h1 class="font-semibold mb-1">Registrados</h1>
                </div>

                <div class="border border-blue-400 rounded-full text-center flex items-center justify-center p-4 py-2">
                    <span><i class="fi fi-rr-check text-xl p-2"></i></span>
                    <h1>Ativos: {{ employeeStore.totalEmployees }}</h1>
                </div>

                <div class="border border-blue-400 rounded-full text-center flex items-center justify-center p-4 py-2">
                    <span><i class="fi fi-rr-check text-xl p-2"></i></span>
                    <h1>Inativos: {{ employeeStore.inactiveEmployees }}</h1>
                </div>

            </div>

            <div v-if="employeeStore.isLoading" class="p-4 mt-2 rounded-xl text-center w-[50%] m-auto">
                <p>Buscando Dados...</p>
            </div>

            <div v-else-if="employeeStore.error" class="feedback error">
                <p>Falha: {{ employeeStore.error }}</p>
                <button @click="employeeStore.loadEmployees()">Tentar novamente</button>
            </div>

            <div v-else-if="employeeStore.totalEmployees > 0" class="mt-5">
                <ul>
                    <li v-for="employee in employeeStore.employees" :key="employee.employeeId"
                        class="employee-item flex justify-between py-3 p-4 mt-2 border-2 border-blue-900 rounded-lg">

                        <div class="w-full">
                            <p><i class="fi fi-rr-user text-base p-2"></i>{{ employee.name }}</p>
                        </div>

                        <div class="w-full">
                            <p><i class="fi fi-rr-code-simple text-base p-2"></i>{{ employee.position }}</p>
                        </div>

                        <div class="w-[40%]">
                            <p v-if="employee.isActive"><i class="fi fi-rr-check text-base p-2"></i>ativo</p>
                        </div>
                    </li>
                </ul>
            </div>

            <div v-else>
                <p>Nenhum funcionário cadastrado no sistema</p>
            </div>
        </div>

        <div v-if="employeeStore.totalEmployees > 0"
            class="py-5 p-2 max-w-7xl m-auto border-2 border-blue-900 rounded-2xl mt-10">
            <p>Galeria</p>
            <div class="flex flex-wrap justify-right gap-8 max-w-5xl m-auto">
                <div v-for="employee in employeeStore.employees" :key="employee.employeeId"
                    class="flex flex-col items-center cursor-pointer transition-transform transform hover:scale-105 duration-300 hover:text-red-500">
                    <div
                        class="w-[100px] h-[100px] rounded-xl overflow-hidden border-2 border-transparent hover:border-red-500 transition-colors duration-300 ">
                        <img :src="employee.photo" :alt="employee.name" class="w-full h-full object-cover ">
                    </div>
                </div>
            </div>
        </div>

        <div v-if="employeeStore.totalEmployees > 0"
            class="py-5 p-2 max-w-7xl m-auto border-2 border-red-900 rounded-2xl mt-10">
            <p>Galeria</p>
            <div class="flex flex-wrap justify-right gap-8 max-w-5xl m-auto">
                <div v-for="employee in employeeStore.inactiveEmployees" :key="employee.employeeId"
                    class="flex flex-col items-center cursor-pointer transition-transform transform hover:scale-105 duration-300 hover:text-red-500">
                    <div
                        class="w-[100px] h-[100px] rounded-xl overflow-hidden border-2 border-transparent hover:border-red-500 transition-colors duration-300 ">
                        <img :src="employee.photo" :alt="employee.name" class="w-full h-full object-cover ">
                    </div>
                </div>
            </div>
        </div>
       

    </section>
</template>

<style scoped>
.feedback {
    padding: 15px;
    margin: 10px 0;
    border-radius: 4px;
}

.error {
    background-color: #ffebee;
    color: #c62828;
    border: 1px solid #c62828;
}
</style>
