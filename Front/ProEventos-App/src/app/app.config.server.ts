import { provideRouter } from '@angular/router';
import { mergeApplicationConfig, ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { appConfig } from './app.config';
import { serverRoutes } from './app.routes.server';

const serverConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(serverRoutes)
  ]
};

export const config = mergeApplicationConfig(appConfig, serverConfig);
