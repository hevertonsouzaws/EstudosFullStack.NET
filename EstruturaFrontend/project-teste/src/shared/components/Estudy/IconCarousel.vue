<script setup lang="ts">
// Define o contrato de props usando TypeScript
interface Props {
  gifUrl: string;
  title: string;
}
const props = defineProps<Props>();

const ITEM_WIDTH_PX = 208; 

</script>

<template>
  <div
    class="flex-shrink-0 w-48 h-48 bg-gray-700 rounded-xl shadow-lg m-2 p-4 flex flex-col items-center justify-center transition-transform duration-300 hover:scale-[1.02]"
    :style="{ minWidth: `${ITEM_WIDTH_PX}px` }"
  >
    <img
      :src="props.gifUrl"
      :alt="props.title"
      class="w-24 h-24 object-contain mb-2"
    />
    <p class="text-sm font-semibold text-gray-200 text-center">{{ props.title }}</p>
  </div>
</template>