# Cinema API Application Guide

This document outlines the setup and usage of my Cinema API application, which leverages AWS services for the database, backend, and frontend.
Frontend url is [here](http://aws-jonas-halvorsen-day-5.s3-website.eu-north-1.amazonaws.com/).

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

The backend API is structured according to the [API Documentation:](http://aws-day-5-jonas-api-env.eba-862qwvjc.eu-north-1.elasticbeanstalk.com/index.html)

**Example:**
To retrieve customer data:
```http://aws-day-5-jonas-api-env.eba-862qwvjc.eu-north-1.elasticbeanstalk.com/customers```
