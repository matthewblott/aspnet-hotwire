import { UserConfig, defineConfig } from 'vite';
import appsettings from "./appsettings.json";
export default defineConfig(async () => {
	const config: UserConfig = {
		appType: 'custom',
		root: 'Assets',
		publicDir: 'public',
		build: {
			emptyOutDir: true,
			manifest: true,
			outDir: '../wwwroot',
			assetsDir: '',
		},
		server: {
      port: appsettings.Vite.Server.Port, 
			strictPort: true,
      hmr: {
        host: "localhost",
        clientPort: appsettings.Vite.Server.Port
      }
		},
		optimizeDeps: {
			include: []
		}
	}

	return config;
});
