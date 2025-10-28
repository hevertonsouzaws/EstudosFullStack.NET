<template>
    <section class="w-full bg-gray-900 min-h-screen text-gray-200 py-20 p-10">
        <div class="py-10 p-10 max-w-7xl m-auto border-2 border-blue-900 rounded-2xl text-center">

            <div class="w-full">
                <h1 class="text-2xl font-semibold">Consumindo API de clima</h1>
            </div>

            <div class=" m-auto flex justify-between mt-10">

                <input
                    class="w-[80%] p-4 bg-transparent border border-gray-500 rounded-xl hover:border-yellow-600 focus:border-blue-400 focus:ring-1 focus:ring-blue-400 focus:ring-opacity-50 focus:outline-none"
                    type="text" v-model="searchCity" placeholder="Ex: São Paulo" @keyup.enter="handleSearch">

                <button class="rounded-xl bg-gradient-to-r  from-blue-300 via-blue-500 to-blue-700 w-[15%] p-[2px]"
                    @click="handleSearch" :disabled="isLoading">
                    <div
                        class="bg-gray-900 h-full rounded-lg flex items-center justify-center hover:bg-gray-950/80 duration-100">
                        {{ isLoading ? 'Buscando...' : 'Buscar clima'
                        }}
                    </div>
                </button>

            </div>

            <div v-if="isLoading" class="mt-10">
                <p>Carregando dados de {{ searchCity }}...</p>
            </div>

            <div v-else-if="error">
                <p>Erro: {{ error }}</p>
                <button @click="handleSearch">Tentar novamente</button>
            </div>

            <div v-else-if="weatherData"
                class="border border-blue-400 mt-10 m-auto flex justify-around items-center py-1 rounded-3xl text-lg">

                <h2>{{ weatherData.city }}</h2>

                <div class="flex items-center">
                    <img v-if="weatherIconUrl" :src="weatherIconUrl" class="w-20">

                    <p class="">{{ weatherData.temperature }}°C</p>
                </div>

                <p>{{ weatherData.description }}</p>
            </div>

            <div v-else class="my-8 text-gray-400">
                <p>Digite o nome de uma cidade para verificar o clima.</p>
            </div>

            <WeatherHourlyForecast />
        </div>
    </section>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { storeToRefs } from 'pinia';
import { useWeatherStore } from '@/shared/stores/weather.store';
import WeatherHourlyForecast from '@/shared/components/WeatherHourlyForecast.vue';

const searchCity = ref('')

const weatherStore = useWeatherStore();

const { weatherData, isLoading, error, weatherIconUrl } = storeToRefs(weatherStore);
const { loadWeather } = weatherStore;

function handleSearch() {
    if (searchCity.value.trim()) {
        loadWeather(searchCity.value.trim())
    }
}
</script>
