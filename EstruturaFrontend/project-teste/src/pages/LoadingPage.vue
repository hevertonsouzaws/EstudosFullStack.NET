<template>
    <AppIntro 
        v-if="!appStarted"
        @startApp="handleStartApp"
        audio-src="/audio/uivo.mp3" 
    />

    <div v-else class="min-h-screen p-8 bg-gray-900 text-white flex flex-col items-center justify-center">
        <h1 class="text-4xl font-bold mb-4">Aplicação Iniciada!</h1>
        <p class="text-xl text-green-400">Você pressionou "Começar".</p>

        <button 
            @click="restartIntro"
            class="mt-8 bg-gray-700 hover:bg-gray-600 text-white font-bold py-2 px-4 rounded"
        >
            Reiniciar Introdução
        </button>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import AppIntro from '@/shared/components/loading/AppIntro.vue';
import { useLoadingStore } from '@/shared/stores/loading';

const loadingStore = useLoadingStore();
const appStarted = ref(false);

const handleStartApp = () => {
    appStarted.value = true;
};

const restartIntro = () => {
    appStarted.value = false;
};
</script>