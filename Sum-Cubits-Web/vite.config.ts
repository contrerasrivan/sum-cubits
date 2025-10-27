import VueI18nPlugin from '@intlify/unplugin-vue-i18n/vite'
import vueDevTools from 'vite-plugin-vue-devtools'
import { fileURLToPath, URL } from 'node:url'
import { resolve, dirname } from 'node:path'
import vue from '@vitejs/plugin-vue'
import { defineConfig } from 'vite'
import fs from 'fs'

export default defineConfig({
  plugins: [
    vue(),
    vueDevTools(),
    VueI18nPlugin({
      include: resolve(dirname(fileURLToPath(import.meta.url)), './src/locales/**')
    })
  ],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    }
  },
  server: {
    port: 4001,
    https: {
      key: fs.readFileSync('./https/certificate.key'),
      cert: fs.readFileSync('./https/certificate.pem')
    }
  },
  build:{
    outDir: '../Sum-Cubits-Publish/web',
    emptyOutDir: true,
  }
})

