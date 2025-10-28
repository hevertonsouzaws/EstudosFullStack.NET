<script setup lang="ts">
import Environment from '@components/config/Environment.vue';
import AppHeader from './shared/components/Layout/AppHeader.vue';
</script>

<template>
  <AppHeader />
  <Environment />
   <section class="w-full bg-gray-900 min-h-screen text-gray-200">  <router-view> </router-view></section>

</template>
