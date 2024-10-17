**Note: Change any headings in this document**

# Project Guide
This is my Cinema API Application that is set up using AWS Services for database, backend and frontend.

## Setup
The database is set up using AWS RDS for persistent storage.
It is set up with a appsettings.json file that contains the connection string to the database.
And migration to the database.

For the backend I have uploaded and deployed the API to AWS Elastic Beanstalk.
The backend code is complete with the exception of Migrations folder and appsettings.json file.

The frontend is set up using AWS S3 for static website hosting.
The frontend code is complete with the exception of the API URL in the fetch requests and the node_modules folder.
It is talking to the backend API which is again talking to the database.

## Introduction
When cloning the repository, if you want to run it locally you will need to do ´´´dotnet restore´´´ and ´´´dotnet build´´´ and ´´´dotnet run´´´ in the backend folder. For the frontend you will need to do ´´´npm install´´´ and ´´´npm run dev´´´ in the frontend folder.

## References
The backend API is setup according to the following [API Documentation:](https://boolean-uk.github.io/csharp-api-cinema-challenge/extensions)

Database endpoint: http://aws-day-5-jonas-api-env.eba-862qwvjc.eu-north-1.elasticbeanstalk.com
Use one of the calls /customers, /movies, /screenings, /tickets to the endpoint
Example: http://aws-day-5-jonas-api-env.eba-862qwvjc.eu-north-1.elasticbeanstalk.com/customers
