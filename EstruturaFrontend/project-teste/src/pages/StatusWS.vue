<template>
    <div class="w-full">

        <div class="max-w-xl m-auto rounded-lg mt-10">
            <h1 class="text-xl text-center bg-gray-800 rounded-lg">
                Requisições para a api do StatusWS
            </h1>
        </div>
        <div>
            <Requisicoes />
        </div>

    </div>
</template>

<script setup lang="ts">
import Requisicoes from '@/shared/components/StatusWS/Requisicoes.vue';


</script>