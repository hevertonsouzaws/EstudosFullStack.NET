<script setup lang="ts">
import { ref, computed } from 'vue';
import { useEmployeeStore } from '@/shared/stores/estudyEmployee';
import type { Employee } from '@/shared/types/EstudyEmployee';

const employeeStore = useEmployeeStore();

// 1. Estado Local
const newEmployeeForm = ref({
    name: '',
    role: ''
})

const isFormValid = computed(() => {
    return (
        newEmployeeForm.value.name.trim() !== '' &&
        newEmployeeForm.value.role.trim() !== ''
    );
});

const submitEmployee = (): void => {
    if (!isFormValid.value) {
        alert("Preencha todos os campos!");
        return;
    }

    const newEmployee: Employee = {
        id: employeeStore.totalEmployees() + 1,
        name: newEmployeeForm.value.name.trim(),
        role: newEmployeeForm.value.role.trim()
    };

    employeeStore.addEmployee(newEmployee);
    newEmployeeForm.value = { name: '', role: '' };
};
</script>

<template>
    <form @submit.prevent="submitEmployee" class="min-w-full min-h-[350px] p-4 rounded-lg shadow-md bg-gray-600">
        <div class="flex flex-col justify-between gap-4">
            <h1 class="text-xl text-center m-4 text-white">Adicionar novo WS</h1>
            <input required type="text" placeholder="Nome" v-model="newEmployeeForm.name"
                class="border p-3 rounded-lg bg-gray-600 text-gray-100" />
            <input required type="text" placeholder="Cargo" v-model="newEmployeeForm.role"
                class="border p-3 rounded-lg w-full bg-gray-600 text-gray-100" />
            <button
                class="py-3 mt-5 w-full bg-blue-500 text-white font-semibold rounded-lg shadow-m disabled:bg-gray-400 disabled:cursor-not-allowed"
                type="submit" :disabled="!isFormValid">
                Salvar
            </button>
        </div>
    </form>
</template>