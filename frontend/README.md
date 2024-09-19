# Dealoviy

Project based on Vue 3 + Vite + Typescript + Vuetify

## Run project

### Install dependencies

Run the following command to install all dependencies:

```sh
npm install
```

### Configure .env

Make copy of `.env.example` file and rename it to `.env` and replace `VITE_API_URL` with you back-end api server:

```sh
VITE_API_URL=http://HOST:PORT/api
```

### Run dev server

Run the following command:

```sh
npm run dev
```

or if you want to share this server to local network:

```sh
npm run dev -- --host
```

### Production

Run the following command for build static files that will be stored in the `/dist` directory:

```sh
npm run build
```
