# Cinema API Application Guide

This document outlines the setup and usage of my Cinema API application, which leverages AWS services for the database, backend, and frontend.

---

## Project Overview

This project consists of a backend API deployed on AWS Elastic Beanstalk, a database hosted on AWS RDS, and a frontend hosted on AWS S3 for static website hosting. The application is designed to manage customers, movies, screenings, and tickets.

---

## Setup Instructions

### Database Setup

- **Service**: AWS RDS is used for persistent database storage.
- **Configuration**: The connection string is specified in the `appsettings.json` file. Database migrations are managed using Entity Framework.
  
### Backend Setup

- **Deployment**: The backend API is deployed using AWS Elastic Beanstalk.
- **Note**: The `Migrations` folder and `appsettings.json` file are excluded from the repository for security reasons.

### Frontend Setup

- **Hosting**: The frontend is hosted on AWS S3 as a static website.
- **Configuration**: Ensure the correct API URL is provided in the fetch requests. The `node_modules` folder is excluded from the repository.

---

## Running the Application Locally

To run the application locally after cloning the repository:

### Backend

1. Navigate to the `backend` folder.
2. Run the following commands:
   ```bash
   dotnet restore
   dotnet build
   dotnet run

### Frontend

1. Navigate to the `frontend` folder.
2. Run the following commands:
   ```bash
   npm install
   npm audit fix
   npm run dev

---

## API Documentation and endpoints

The backend API is structured with aim to fulfill the [API Documentation:](https://boolean-uk.github.io/csharp-api-cinema-challenge/extensions)

**Base API Endpoint:**
```http://aws-day-5-jonas-api-env.eba-862qwvjc.eu-north-1.elasticbeanstalk.com```

Available API Routes:
- ```/customers```
  - Get customers: ```/```
  - Create customer: ```/```
  - Get customer by id: ```/{id}```
  - Update customer: ```/{id}```
  - Delete customer: ```{id}```

- ```/movies```
  - Get movies: ```/```
  - Create movie: ```/```
  - Get movie by id: ```/{id}```
  - Update movie: ```/{id}```
  - Delete movie: ```{id}```

- ```/screenings```
  - Get screenings: ```/```
  - Create screening: ```/```
  - Get screenings by movie: ```/movies/{id}```
  - Get screening by id: ```/{id}```
  - Update screenning: ```/{id}```
  - Delete screening: ```/{id}```

- ```/tickets```
  - Get tickets: ```/```
  - Create ticket ```/customers/{id}```
  - Get tickets by screening: ```/screenings/{id}```
  - Get ticket by id: ```/{id}```
  - Delete ticket: ```/{id}```

**Example:**
To retrieve customer data:
```http://aws-day-5-jonas-api-env.eba-862qwvjc.eu-north-1.elasticbeanstalk.com/customers```
