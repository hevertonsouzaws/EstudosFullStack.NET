<template>
    <div>
        <h1>Lista de employees</h1>
        <p v-for="employee in employees" :key="employee.id">
            {{ employee.name }} - {{ employee.age }} anos
        </p>
    </div>

</template>

<script setup lang="ts">
import type { EmployeeInterface } from '../types/Employee';
import type { PropType } from 'vue';

const props = defineProps({
    employees: {
        required: true,
        type: Array as PropType<EmployeeInterface[]>
    }
})
</script>

