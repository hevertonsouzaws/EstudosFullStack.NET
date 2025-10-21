<script setup lang="ts">
import { ref } from 'vue';
import PropsCarousel from './PropsCarousel.vue';

const iconGifs = ref([
  { id: 1, title: 'Codando', url: 'https://cdn-icons-gif.flaticon.com/8722/8722699.gif' },
  { id: 2, title: '...', url: 'https://cdn-icons-gif.flaticon.com/17091/17091713.gif' },
  { id: 3, title: '...', url: 'https://cdn-icons-gif.flaticon.com/17122/17122475.gif' },
  { id: 4, title: '...', url: 'https://cdn-icons-gif.flaticon.com/17122/17122378.gif' },
  { id: 5, title: '...', url: 'https://cdn-icons-gif.flaticon.com/15713/15713152.gif' },
  { id: 6, title: '...', url: 'https://cdn-icons-gif.flaticon.com/17122/17122407.gif' },
]);
</script>

<template>
  <div class=" p-4 bg-gray-600 rounded-xl shadow-2xl">
    <h3 class="text-2xl font-bold mb-4 text-gray-200">Carrossel de Ícones (Tecnologias)</h3>

    <div class="flex overflow-x-auto whitespace-nowrap py-4 -mx-2">
      
      <PropsCarousel
        v-for="icon in iconGifs"
        :gif-url="icon.url"
        :title="icon.title"
      />
      
    </div>
    
    <p class="text-xs text-gray-400 mt-2">Arraste para o lado para ver mais!</p>
  </div>
</template>