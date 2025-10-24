<template>
    <div class="fixed inset-0 z-50 bg-black flex items-center justify-center">

        <div class="flex flex-col items-center justify-center transition-all duration-1000">

            <div v-if="stage === 'spinner'" class="w-20 h-20 relative">
                <div class="absolute inset-0 border-4 border-white border-t-orange-400 rounded-full animate-spin-slow">
                </div>
                <div
                    class="absolute inset-2 border-4 border-whhite-400 border-t-white rounded-full animate-spin-reverse-slow">
                </div>
            </div>

            <div v-else-if="stage === 'logo' || stage === 'ready'" :class="logoContainerClasses">
                <img :src="logoAlcatteiaSrc" alt="Logo da Aplicação"
                    class="w-[180px] h-auto transition-all duration-200"
                    :class="{ 'logo-fade-in': stage === 'logo' }" />
            </div>

            <button v-if="stage === 'ready'" @click="startAppHandler"
                class="opacity-0 transform transition-all duration-200 flex flex-col items-center justify-center group mt-6"
                :class="{ 'opacity-100 translate-y-0': stage === 'ready' }">

                <i class="fi fi-rr-play-circle text-5xl animate-pulse hover:scale-105 text-orange-500"></i>


            </button>

        </div>

        <audio ref="audioPlayer" :src="audioSrc" preload="auto"></audio>
    </div>
</template>

<script setup lang="ts">
import { ref, onMounted, computed, onUnmounted } from 'vue';
import type { AppIntroProps } from '@/shared/types/loading';
import { useLoadingStore } from '@/shared/stores/loading';
import logoAlcatteiaSrc from '@/assets/img/logoAlcatteia.png';

type TimerHandle = ReturnType<typeof setTimeout> | null;

// Duração ajustada para o CSS.
const FADE_DURATION_MS = 3000;

const props = withDefaults(defineProps<AppIntroProps>(), {
    siteName: 'Meu App',
    logoSrc: '',
    audioSrc: '',
});

const emit = defineEmits(['startApp']);
const loadingStore = useLoadingStore();

type Stage = 'spinner' | 'logo' | 'ready' | 'hidden';
const stage = ref<Stage>('spinner');
const audioPlayer = ref<HTMLAudioElement | null>(null);
let timer: TimerHandle = null;
let fadeTimer: TimerHandle = null;
let audioStopTimer: TimerHandle = null;

const logoContainerClasses = computed(() => {
    // Usaremos a classe 'logo-fade-in' diretamente no <img> para a animação.
    return '';
});

const startAudioWithTimeout = (): void => {
    if (audioStopTimer !== null) clearTimeout(audioStopTimer);

    if (props.audioSrc && audioPlayer.value) {
        audioPlayer.value.volume = 0.6;

        audioPlayer.value.play().then(() => {
            audioStopTimer = setTimeout(() => {
                audioPlayer.value?.pause();
                audioPlayer.value!.currentTime = 0;
            }, FADE_DURATION_MS);
        }).catch(() => {
            console.warn("Áudio bloqueado pelo navegador.");
        });
    }
};

const stopAudio = (): void => {
    if (audioStopTimer !== null) clearTimeout(audioStopTimer);
    if (audioPlayer.value) {
        audioPlayer.value.pause();
        audioPlayer.value.currentTime = 0;
    }
};

const runIntroSequence = () => {
    stage.value = 'spinner';
    loadingStore.startLoading();

    timer = setTimeout(() => {
        stage.value = 'logo';
        startAudioWithTimeout();

        fadeTimer = setTimeout(() => {
            stage.value = 'ready';
            loadingStore.finishLoading();
        }, FADE_DURATION_MS);
    }, 4000);
};

const startAppHandler = () => {
    if (audioPlayer.value && audioPlayer.value.paused) {
        startAudioWithTimeout();
    }
    emit('startApp');
};

onMounted(() => {
    runIntroSequence();
});

onUnmounted(() => {
    if (timer !== null) clearTimeout(timer);
    if (fadeTimer !== null) clearTimeout(fadeTimer);
    stopAudio();
});
</script>

<style scoped>
/* ---------------------------------------------------- */
/* ANIMAÇÃO DE FADE-IN DA LOGO (SUBSTITUI O BLUR) */
/* ---------------------------------------------------- */

@keyframes logo-reveal {
    0% {
        opacity: 0.1;
        /* Imagem quase invisível */
    }

    30% {
        opacity: 0.8;
        /* 80% embaçada */
    }

    60% {
        opacity: 0.4;
        /* 40% embaçada */
    }

    100% {
        opacity: 1;
        /* 0% embaçada, totalmente visível */
    }
}

.logo-fade-in {
    animation: logo-reveal 3s forwards;
}

@keyframes spin-slow {
    0% {
        transform: rotate(0deg);
    }

    100% {
        transform: rotate(360deg);
    }
}

.animate-spin-slow {
    animation: spin-slow 1.5s linear infinite;
}

@keyframes spin-reverse-slow {
    0% {
        transform: rotate(360deg);
    }

    100% {
        transform: rotate(0deg);
    }
}

.animate-spin-reverse-slow {
    animation: spin-reverse-slow 2s linear infinite;
}
</style>