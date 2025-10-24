<script setup lang="ts">
import AppHeader from '@/shared/components/layout/AppHeader.vue';
</script>

<template>
  <div class="min-h-screen text-white bg-gradient-to-br from-gray-600 to-gray-800">
    <AppHeader cla/>
    <RouterView />
  </div>
</template>
