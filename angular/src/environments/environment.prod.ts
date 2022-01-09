import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'BlogStore',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44343',
    redirectUri: baseUrl,
    clientId: 'BlogStore_App',
    responseType: 'code',
    scope: 'offline_access BlogStore',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44343',
      rootNamespace: 'BlogStore',
    },
  },
} as Environment;
