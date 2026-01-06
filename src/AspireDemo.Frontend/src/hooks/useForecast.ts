import { useEffect, useState } from "react";
import { getForecast } from "../api/forecast";
import type { WeatherForecast } from "../models/WeatherForecast";

export function useForecast() {
  const [data, setData] = useState<WeatherForecast[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getForecast()
      .then(setData)
      .finally(() => setLoading(false));
  }, []);

  return { data, loading };
}
