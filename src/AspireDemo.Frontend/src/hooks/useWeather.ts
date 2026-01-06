import { useEffect, useState } from "react";
import { getWeather } from "../api/weather";
import type { WeatherForecast } from "../models/WeatherForecast";

export function useWeather() {
  const [data, setData] = useState<WeatherForecast[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getWeather()
      .then(setData)
      .finally(() => setLoading(false));
  }, []);

  return { data, loading };
}
