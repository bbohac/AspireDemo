import "./App.css";
import { useWeather } from "./hooks/useWeather";

function App() {
  const { data, loading } = useWeather();

  if (loading) {
    return <p>Loading...</p>;
  }

  return (
    <ul>
      {data.map((w, i) => (
        <li key={i}>
          <strong>{w.date}</strong>: {w.temperatureC}°C ({w.summary})
        </li>
      ))}
    </ul>
  );
}

export default App;
