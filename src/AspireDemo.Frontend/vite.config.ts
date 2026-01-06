import react from "@vitejs/plugin-react";
import { defineConfig } from "vite";

console.log("VITE ENV:", process.env);

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    host: true,
    proxy: {
      "/api": {
        target: process.env.API_HTTPS || process.env.API_HTTP,
        changeOrigin: true,
      },
    },
  },
});
