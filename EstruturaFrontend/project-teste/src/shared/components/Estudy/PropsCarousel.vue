<script setup lang="ts">
interface Props {
    gifUrl: string,
    title: string
}

const props = defineProps<Props>();
</script>

<template>
    <div class="flex-shrink-0 w-48 h-48 rounded-xl shadow-lg m-2 p-4 flex flex-col items-center justify-center transition-transform duration-300 hover:scale-[1.05]">
        <img :src="props.gifUrl" :alt="props.title" class="rounded-full w-20 h-20 hover:scale-[1.05]">
    <p class="text-base  text-gray-200 text-center mt-5">{{ props.title }}</p>
    </div>
</template>

