<template>
    <header class="bg-gray-900 border-b border-blue-600 top-0 z-50 p-8">
        <nav class="text-white">
            <div class="flex items-center justify-center gap-10 selection:">
                <router-link to="/">
                    <i class="fi fi-rr-house-chimney text-xl"></i>
                </router-link>
                <router-link to="/employees">
                    <i class="fi fi-rr-book text-xl"></i>
                </router-link>
                <router-link to="/clima">
                    <i class="fi fi-rr-dashboard text-xl"></i>
                </router-link>
                <router-link to="/filtro">
                    <i class="fi fi-rr-loading text-xl"></i>
                </router-link>
            </div>
        </nav>
    </header>
</template>

<script setup lang="ts">
</script>