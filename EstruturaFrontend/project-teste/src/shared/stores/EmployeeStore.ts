import { ref } from "vue";
import { defineStore } from "pinia";
import type { Employee } from "../types/Employee";

export const useEmployeeStore = defineStore('employee', () => {
    const employees = ref<Employee[]>([]);

    const addEmployee = (newEmployee: Employee): void => {
        employees.value.push(newEmployee);
    };

    const totalEmployees = (): number => {
        return employees.value.length;
    }

    return { employees, addEmployee, totalEmployees }
})
