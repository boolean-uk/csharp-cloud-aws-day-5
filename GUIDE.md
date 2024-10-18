**Note: Change any headings in this document**

# Project Guide

## Setup
Backend is running on Elastic Beanstalk with and RDS database.
To setup this application, follow the references

## Introduction
Backend and frontend Todo list API written in C#/.NET, but it's dogs instead of todos. 
Frontend is written in React and deployed using Elastic Beanstalk environment and S3 bucket.
Backend is written in C# and deployed using Elastic Beanstalk and RDS Database.

## Technical Designs
### Backend
Backend can be run with Swagger to access POST, PUT, GET and DELETE dog models that are stored on the database.
Frontend can be run using Vite where UI elements can be used to create new dogs, see current dogs and delete dogs from the list.

## Technical Descriptions
### Backend
The backend is built with ASP.NET Core, providing a RESTful API with endpoints to manage dog models. It is deployed on AWS using Elastic Beanstalk, handling the app environment and deployment. Said backend then interacts with an RDS PostgreSQL database in order to store and manage dog models. DogContext uses Entity Framework and appsettings connection string to communicate and do operations on the RDS database.

### Frontend
The UI is built using React for user-friendly interaction with the backend API. It displays an input box for the dog's name and a create button to add the new dog to the list. It also displays a list of all dogs in the database in which the user can delete dogs from the list. The frontend dynamically updates the list displayed when a dog is either added or removed.  It is deployed on AWS using an S3 bucket configured to host a static webiste. It accesses the backend API to update the database.

## References
[Elastic Beanstalk, RDS](https://github.com/boolean-uk/csharp-cloud-aws-day-1)
