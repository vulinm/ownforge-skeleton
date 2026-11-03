# App skeleton

Empty application consisting of an ASP.NET Core API, a React web frontend (nginx), and PostgreSQL, each running in its own container.

## Creating a new application from the skeleton
1. git clone this repository into a new folder and change origin to point to the new repository.
2. cp .env.example .env and configure APP_NAME (same as the repository name) and the passwords.
3. Push to main: CI builds <app>-web, <app>-api, and <app>-deploy images.

## Local development
docker compose up --build

## Configuration
All configuration settings and secrets are provided through .env. The .env file must never be committed to the repository.

## License
PolyForm Noncommercial 1.0.0: free for noncommercial use only. Commercial use requires a separate license from the author. See LICENSE.
