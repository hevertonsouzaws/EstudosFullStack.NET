export interface IWheaterStoreState {
    weatherData: IWeatherInfo | null;
    hourlyForecast: IHourlyForecast[];
    isLoading: boolean;
    error: string | null;
}

export interface IWeatherInfo{
    city: string;
    temperature: number;
    description: string;
    iconCode: string;
}

export interface IHourlyForecast {
    time: string;
    temp: number;
    iconCode: string;
}