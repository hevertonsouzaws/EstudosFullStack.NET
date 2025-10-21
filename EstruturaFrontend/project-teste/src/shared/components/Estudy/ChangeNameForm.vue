<script setup lang="ts">
import { ref } from 'vue';
import { useNameChengerStore } from '@/shared/stores/changeName';

const nameStore = useNameChengerStore();

const inputNewName = ref<string>('');

const HandleNameChange = (): void => {
    nameStore.setName(inputNewName.value);

    inputNewName.value = '';
}
</script>

<template>
    <form class="flex flex-col min-w-full p-4 rounded-lg shadow-md max-w-2xl bg-gray-600">
        <h1 class="text-xl mb-4">nome atual:
            <span class="font-semibold">{{ nameStore.currentName }}</span>
        </h1>
        <p class="text-lg mb-4">
            Digite um nome para alterar o atual:
        </p>

        <div class="flex justify-between gap-4">
            <input type="text" placeholder="Digite um nome aqui"
                class="border p-2 rounded-lg w-full bg-gray-600 text-gray-100" v-model="inputNewName" />

            <button class="py-3 w-40 bg-blue-500 text-white font-semibold rounded-lg shadow-m" @click="HandleNameChange"
                :disabled="!inputNewName">
                Alterar
            </button>
        </div>
    </form>
</template>