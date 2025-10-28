import { defineStore } from 'pinia'
import type { IWheaterStoreState, IWeatherInfo, IHourlyForecast } from "../types/weather.type";
import { fetchCurrentWeather, fetchHourlyForecast } from '../services/external/weather.service';

export const useWeatherStore = defineStore('weather', {

    // 1. Estado Inicial
    state: (): IWheaterStoreState => ({
        weatherData: null,
        hourlyForecast: [],
        isLoading: false,
        error: null,
    }),

    getters: {
        weatherIconUrl: (state) => {
            if (!state.weatherData?.iconCode) return null;
            return `https://openweathermap.org/img/wn/${state.weatherData.iconCode}@2x.png`;
        }
    },

    actions: {
        async loadWeather(city: string) {
            this.isLoading = true;
            this.error = null;
            this.weatherData = null;
              this.hourlyForecast = []; 

            try {
                const data: IWeatherInfo = await fetchCurrentWeather(city);
                this.weatherData = data;

                const forecastData: IHourlyForecast[] = await fetchHourlyForecast(city);
                this.hourlyForecast = forecastData;
            } catch (e: any) {
                this.error = e.message;
            } finally {
                this.isLoading = false;
            }
        },
    },
});
