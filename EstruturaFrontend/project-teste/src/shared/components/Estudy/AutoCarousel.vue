<script setup lang="ts">
import { ref, onMounted, onUnmounted } from 'vue'; 
import IconCarousel from './IconCarousel.vue';

// 1. DADOS e REATIVIDADE
const iconGifs = ref([
  { id: 1, title: 'Codando', url: 'https://cdn-icons-gif.flaticon.com/8722/8722699.gif' },
  { id: 2, title: 'Ideia', url: 'https://cdn-icons-gif.flaticon.com/17091/17091713.gif' },
  { id: 3, title: 'Café', url: 'https://cdn-icons-gif.flaticon.com/17122/17122475.gif' },
  { id: 4, title: 'Revisão', url: 'https://cdn-icons-gif.flaticon.com/17122/17122378.gif' },
  { id: 5, title: 'Deploy', url: 'https://cdn-icons-gif.flaticon.com/15713/15713152.gif' },
  { id: 6, title: 'Otimização', url: 'https://cdn-icons-gif.flaticon.com/17122/17122407.gif' },
]);


const carouselRef = ref<HTMLElement | null>(null);

let intervalId: ReturnType<typeof setInterval> | null = null; 

const scrollSpeed = 0.5; 
const intervalTime = 10; 

const originalItemCount = iconGifs.value.length;

// 3. LÓGICA DE ROLAGEM CONTÍNUA
const autoScroll = () => {
    const carousel = carouselRef.value;
    if (!carousel) return;

    // 1. Move o carrossel um pouco (0.5px)
    carousel.scrollLeft += scrollSpeed;
    
    // 2. Verifica o loop: Se o carrossel rolou o suficiente para exibir a segunda cópia dos itens
    // A rolagem volta "instantaneamente" para o início da segunda cópia para simular o infinito.
    // O scrollWidth é o tamanho total, e queremos voltar quando rolamos metade dele.
    if (carousel.scrollLeft >= carousel.scrollWidth / 2) {
        // Teleporta de volta para o início da segunda metade
        carousel.scrollLeft = 0; 
    }
};

onMounted(() => {
    intervalId = setInterval(autoScroll, intervalTime);
});

// Limpa o loop
onUnmounted(() => {
    if (intervalId !== null) {
        clearInterval(intervalId);
    }
});

// Pausa e Resume (melhorando o UX)
const pauseAutoplay = () => {
    if (intervalId !== null) {
        clearInterval(intervalId);
        intervalId = null;
    }
};

const resumeAutoplay = () => {
    if (intervalId === null) {
        intervalId = setInterval(autoScroll, intervalTime);
    }
};

</script>

<template>
  <div class=" p-4 bg-gray-600 rounded-xl shadow-2xl">
    <h3 class="text-2xl font-bold mb-4 text-gray-200">Carrossel de Ícones (Tecnologias)</h3>

    <div
      ref="carouselRef"
      class="flex overflow-x-auto whitespace-nowrap py-4 -mx-2 hide-scrollbar"
      @mouseenter="pauseAutoplay" 
      @mouseleave="resumeAutoplay"
    >
      
      <IconCarousel
        v-for="icon in iconGifs"
        :key="icon.id"
        :gif-url="icon.url"
        :title="icon.title"
      />
      <IconCarousel
        v-for="icon in iconGifs"
        :key="icon.id + originalItemCount" 
        :gif-url="icon.url"
        :title="icon.title"
      />
      
    </div>
    
    <p class="text-xs text-gray-400 mt-2">Passe o mouse para pausar, ou arraste para o lado!</p>
  </div>
</template>

<style>
/* ... (Seu CSS para esconder a barra de rolagem permanece o mesmo) ... */
.hide-scrollbar::-webkit-scrollbar {
    display: none;
}
.hide-scrollbar {
    -ms-overflow-style: none;  
    scrollbar-width: none;  
}
</style>