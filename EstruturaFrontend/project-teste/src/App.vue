<script setup lang="ts">
import AppHeader from '@/shared/components/layout/AppHeader.vue';
</script>

<template>
  <div class="min-h-screen text-white bg-gray-700">
    <AppHeader />
    <RouterView />
  </div>
</template>
