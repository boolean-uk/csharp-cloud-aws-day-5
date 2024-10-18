Project Guide
Setup
1. Created an RDS Database

    Service: AWS RDS
    Database Type: PostgreSQL
    Steps Taken:
        Launched an RDS PostgreSQL instance in AWS.
        Configured security groups to allow access from the EC2 instance.
        Took note of the database credentials (username, password, endpoint) for use in the backend API.

2. Created an EC2 Instance

    Service: AWS EC2
    Instance Type: t2.micro (or the instance type you used)
    Steps Taken:
        Launched an EC2 instance with appropriate inbound rules allowing SSH and application traffic.
        Used SSH to access the EC2 instance and install required software (e.g., .NET Core SDK).
        Pulled the repository from GitHub, which contains the CinemaAPI.

3. Pulled and Configured CinemaAPI

    Repository: Pulled the CinemaAPI repository from GitHub using git clone.
    appsettings.json Configuration:
        Since appsettings.json wasn't part of the repository, manually copied it from the local machine to the EC2 instance using scp.
        Updated the PostgreSQL RDS credentials inside appsettings.json to connect to the RDS instance.
        Example connection string in appsettings.json:

        json

        "ConnectionStrings": {
            "DefaultConnection": "Host=<RDS-Endpoint>;Database=<DB-Name>;Username=<Username>;Password=<Password>"
        }

4. Ran the CinemaAPI on EC2

    Steps:
        Navigated to the API project directory inside the EC2 instance.
        Built and ran the application using .NET Core commands:

        bash

        dotnet build
        dotnet run

        The API was successfully hosted on the EC2 instance, accessible via the public IP address and port.

5. Created a Frontend (index.html)

    Frontend Purpose: To interact with the CinemaAPI using a simple HTML file and JavaScript for data fetching and submission.
    Steps:
        Created an index.html file with basic structure and included JavaScript to fetch data from the CinemaAPI hosted on the EC2 instance.
        Added a button to fetch data using the following JavaScript:

        javascript

        fetch('http://<EC2-IP-Address>:<Port>/cinema/cinema/movies')
          .then(response => response.json())
          .then(data => console.log(data));

        The frontend was hosted in an S3 bucket, and CORS was enabled on the backend to allow requests from the S3-hosted frontend.

6. Created a Lambda Function for Data Transformation

    Service: AWS Lambda
    Purpose: To transform the JSON data fetched from the CinemaAPI.
    Steps:
        Created a Lambda function using Node.js.
        The function took the JSON data returned from the API and applied serialization to it


7. Integrated API Gateway

    Service: AWS API Gateway
    Purpose: To expose the Lambda function via an HTTP API.
    Steps:
        Created a new API in API Gateway and integrated it with the Lambda function.
        Configured the necessary routes and stages for the API.
        The frontend now fetched data via the API Gateway, which transformed the API response via Lambda.

8. Created Terraform Script
   Created a terraform script to automate deployment of lambda function. Copy of script is attached in the folder.

Introduction

This project is a full-stack web application that involves interacting with a cinema API to manage movie data. The backend API is deployed on AWS EC2, with PostgreSQL as the database hosted in AWS RDS. The frontend is hosted on S3 and makes requests to the API. Additionally, an AWS Lambda function is used to transform JSON data before returning it to the frontend, with an API Gateway facilitating communication between the frontend and Lambda.
Technical Designs
Architecture Overview

    Frontend:
        Hosted in an AWS S3 bucket, this is a simple HTML page with JavaScript for making API requests.
    Backend API (CinemaAPI):
        A .NET Core API deployed on an AWS EC2 instance, connected to an RDS PostgreSQL database.
        The API handles movie-related data, providing endpoints for fetching and submitting movie details.
    RDS Database:
        PostgreSQL database hosted in AWS RDS that stores movie data.
    AWS Lambda:
        A function that transforms the JSON response from the CinemaAPI.
    AWS API Gateway:
        Facilitates the communication between the frontend and the Lambda function, exposing the transformed data.

Technical Descriptions

    Backend API (CinemaAPI):
        The .NET Core API is responsible for CRUD operations on movie data. It uses Entity Framework Core for database interactions with PostgreSQL in RDS.
        The API is deployed on an EC2 instance, with access configured via security groups.

    Frontend (HTML + JavaScript):
        A basic HTML page is created to allow users to fetch and submit data to the CinemaAPI.
        JavaScript’s fetch API is used to send HTTP requests to the API endpoints and display the data in the browser.

    CORS Configuration:
        CORS is configured in the CinemaAPI to allow requests from the S3 bucket URL where the frontend is hosted. This prevents CORS-related errors when the frontend interacts with the backend API.

    AWS Lambda Function:
        A simple AWS Lambda function is used to manipulate or transform the JSON data from the CinemaAPI before returning it to the frontend.
        The Lambda function is triggered via an API Gateway.

    API Gateway:
        AWS API Gateway is configured to expose the Lambda function as a REST API.
        It allows the frontend to interact with the transformed data through a clean HTTP API.

References

    AWS RDS Documentation
    AWS EC2 Documentation
    AWS Lambda Documentation
    API Gateway Documentation
    Entity Framework Core Documentation
    CORS in ASP.NET Core