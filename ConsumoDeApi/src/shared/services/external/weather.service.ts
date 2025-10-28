import axios from "axios";
import type { IWeatherInfo, IHourlyForecast } from "@/shared/types/weather.type";

const API_KEY = import.meta.env.VITE_OPENWEATHER_API_KEY;
const BASE_URL = import.meta.env.VITE_OPENWEATHER_BASE_URL;
const WEATHER_URL = `${BASE_URL}/weather`;
const FORECAST_URL = `${BASE_URL}/forecast`;

export async function fetchCurrentWeather(city: string): Promise<IWeatherInfo> {
    try {
        const reponse = await axios.get(WEATHER_URL, {
            params: {
                q: city,
                appid: API_KEY,
                units: 'metric',
                lang: 'pt_br'
            }
        });

        const data = reponse.data;

        return {
            city: data.name,
            temperature: Math.round(data.main.temp),
            description: data.weather[0].description,
            iconCode: data.weather[0].icon,
        };
    } catch (error: any) {
        if (error.reponse && error.reponse.status === 404) {
            throw new Error(`A cidade "${city} não foi encontrada, verifique o nome.`)
        }
        throw new Error("Falha na comunicação com a API de clima")

    }
}

export async function fetchHourlyForecast(city: string): Promise<IHourlyForecast[]> {
    try {
        const response = await axios.get(FORECAST_URL, { // <--- Endpoint /forecast
            params: {
                q: city,
                appid: API_KEY,
                units: 'metric',
                lang: 'pt_br'
            }
        });

        const rawData = response.data.list;

        const nextHoursForecast: IHourlyForecast[] = rawData.slice(0, 8).map((item: any) => {
            const date = new Date(item.dt * 1000);

            return {
                time: date.toLocaleTimeString('pt-BR', { hour: '2-digit', minute: '2-digit' }),
                temp: Math.round(item.main.temp),
                iconCode: item.weather[0].icon,
            };
        });

        return nextHoursForecast;

    } catch (error: any) {
        console.error("Erro ao buscar previsão por hora:", error);
        return [];
    }
}

