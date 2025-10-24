<script setup lang="ts">
import { getEmployeeById } from '@/shared/services/EmployeeService';
import { useEmployeeStoreWS } from '@/shared/stores/employee';
import { onMounted } from 'vue';
import EmployeeList from '../Estudy/EmployeeList.vue';

const id = 1;

const employeeStore = useEmployeeStoreWS();
onMounted(async () => {
    await employeeStore.fetchEmployees();

    if (employeeStore.error) {
        console.error('Falha ao carregar a lista de funcionários:', employeeStore.error);
    }
    else if (employeeStore.employees.length > 0) {
        console.log(' Array de Funcionários Carregado com Sucesso:', employeeStore.employees);
    } else {
        console.log('Lista de funcionários carregada, mas está vazia.');
    }
    employeeStore.fetchEmployeeById(id)
});
</script>

<template>
    <h1>Ativos: {{ employeeStore.employees.length }}</h1>
    <h1>nomes:  </h1>
</template>