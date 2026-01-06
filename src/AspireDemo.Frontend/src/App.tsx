import "./App.css";
import { useForecast } from "./hooks/useForecast";

function App() {
  const { data, loading } = useForecast();

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
