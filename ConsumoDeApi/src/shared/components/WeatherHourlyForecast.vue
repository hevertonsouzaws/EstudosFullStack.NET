<script setup lang="ts">
import { storeToRefs } from 'pinia';
import { useWeatherStore } from '../stores/weather.store';

const weatherStore = useWeatherStore();
const { hourlyForecast } = storeToRefs(weatherStore)

function getIconUrl(iconCode: string) {
    return `https://openweathermap.org/img/wn/${iconCode}.png`;
}
</script>

<template>
    <div v-if="hourlyForecast.length" class="">
        <h3 class="m-10">Previsão nas Próximas Horas</h3>

        <div class="flex justify-around gap-5 font-semibold mb-2 flex-wrap">
            <div v-for="item in hourlyForecast" :key="item.time"
                class="p-10 border text-lg rounded-lg border-blue-400 ">
                <p class="">{{ item.time }}</p>
                <img :src="getIconUrl(item.iconCode)" :alt="item.iconCode" class="" />
                <p class="">{{ item.temp }}°</p>
            </div>
        </div>
    </div>
</template>
s
<style scoped></style>