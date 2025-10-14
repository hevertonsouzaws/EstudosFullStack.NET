<script setup lang="ts">
import { reactive } from 'vue';
import type { EmployeeInterface } from './types/Employee';
import EmployeesList from './components/EmployeesList.vue';

let employees = reactive<EmployeeInterface[]>([
  { id: 1, name: 'Heverton', age: 19 },
  { id: 2, name: 'Gustavo', age: 22 },
  { id: 3, name: 'Kesia', age: 25 }
]);

</script>

<template>
  <div>
    <div>
      <h1>Employees
      </h1>
      <p v-for="ws in employees" :key="ws.id">
        {{ ws.name }}
      </p>
    </div>
    <h1>Idades</h1>

    <p v-for="ws in employees" :key="ws.id">
      {{ ws.age }}
    </p>

    <div>
      <h1>Props</h1>
      <EmployeesList :employees="employees"/>
    </div>

  </div>

</template>

<style scoped>
* {
  color: white;
  list-style: none;
  text-align: left;
}
</style>
