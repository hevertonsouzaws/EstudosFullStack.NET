<script setup lang="ts">
import Environment from '@components/config/Environment.vue';
import AppHeader from './shared/components/Layout/AppHeader.vue';
</script>

<template>

  <section class="w-full min-h-auto bg-gray-900 min-h-screen text-gray-200">
    <AppHeader />
    <Environment />
    <router-view> </router-view>
  </section>

</template>
