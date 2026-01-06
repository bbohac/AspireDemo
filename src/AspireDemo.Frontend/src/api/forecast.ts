import type { WeatherForecast } from "../models/WeatherForecast";

export async function getForecast(): Promise<WeatherForecast[]> {
  const response = await fetch("/api/v1/forecast?days=5");
  if (!response.ok) {
    const problem = await response.json();
    console.error(problem);

    console.log(problem.errors?.Days?.[0] ?? problem.title);

    throw new Error("Failed to load forecast data");
  }

  return response.json();
}
