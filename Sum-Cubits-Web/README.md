# Sum Cubits Web

## Getting Started

### Prerequisites
- Node.js (Latest LTS version recommended)
- PNPM package manager
- npm install vue-i18n

### Installation

```bash
# Install dependencies
pnpm install

# Start development server
pnpm dev
```

### Build

```bash
# Build for staging
pnpm build:staging

# Build for production
pnpm build
```

### https
```
dotnet dev-certs https --trust
dotnet dev-certs https --export-path "./https/certificate.pem" --no-password --format PEM
```

## Project Structure

```
├── public/            # Public static assets
├── src/               # Source code
│   ├── auth/          # Authentication configuration
│   ├── components/    # Reusable Vue components
│   ├── composables/   # Vue composition functions
│   ├── features/      # Feature modules
│   │   ├── reservation/     # Reservation management
│   │   └── ...        # Other feature modules
│   ├── locales/       # Internationalization files
│   ├── prime/         # PrimeVue configuration
│   ├── resources/     # Application resources
│   ├── router/        # Vue Router configuration
│   ├── store/         # Pinia store modules
│   ├── App.vue        # Root component
│   ├── main.ts        # Application entry point
│   └── main.css       # Global styles
├── .env.development   # Development environment variables
├── eslint.config.js   # ESLint configuration
├── index.html         # HTML entry point
├── package.json       # Project dependencies and scripts
├── tsconfig.json      # TypeScript configuration
├── vite.config.ts     # Vite configuration
└── vitest.config.ts   # Vitest configuration
```

## Technology Stack

### Frontend Framework and Libraries
- Vue.js 3.5.16 - Progressive JavaScript framework
- TypeScript 5.8.3 - Static typing for JavaScript
- Pinia 3.0.3 - State management
- Vue Router 4.5.1 - Client-side routing
- PrimeVue 4.3.5 - UI component library
- PrimeFlex 4.0.0 - CSS utility library
- PrimeIcons 7.0.0 - Icon library
- Vue I18n 11.1.5 - Internationalization
- Auth0 Vue SDK 2.4.0 - Authentication
- VueUse 13.3.0 - Composition utilities

### Development Tools
- Vite 6.3.5 - Build tool and dev server
- Vitest 3.2.3 - Testing framework
- ESLint 9.28.0 - Linting
- Prettier 3.5.3 - Code formatting
- PNPM - Package manager

## Features

The application appears to have several core features based on the directory structure:

- **Authentication**: Integration with Auth0 for user authentication
- **Internationalization**: Multi-language support