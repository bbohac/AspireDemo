import type { WeatherForecast } from "../models/WeatherForecast";

export async function getWeather(): Promise<WeatherForecast[]> {
  const response = await fetch("/api/weatherforecast");
  if (!response.ok) {
    throw new Error("Failed to load weather data");
  }

  return response.json();
}
