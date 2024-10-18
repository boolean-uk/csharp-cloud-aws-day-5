**Note: Change any headings in this document**

# Project Guide

## Setup
1. RDS Database Setup:
- Created and configured an RDS instance.
- Established a connection to the RDS database from the backend.

2. EC2 Instance Configuration:
- Launched an EC2 instance with an AWS server.
- Installed necessary tools such as YUM and .NET SDK 8.0 to run the backend.

3. Source Code Deployment:
- Cloned the backend Git repository into the AWS server.
- Configured and ran the backend application on the EC2 instance.

4. Frontend Deployment:
- TODO

## Introduction
This project involves the development of a full stack application (backend up and running so far) using AWS services such as RDS and EC2 (working on s3). The backend is connected to an RDS database, while the frontend is planned to be hosted on an S3 bucket. The entire infrastructure is deployed and runs on AWS.

## Technical Designs
AWS Infrastructure
- RDS: The Relational Database Service (RDS) is used to store application data (CRUD operations).
- EC2: The Elastic Compute Cloud (EC2) instance runs the backend application, exposing the API endpoints.
## Technical Descriptions
1. RDS Setup:
- Created an RDS database with appropriate configurations for the backend.
- Connected the backend to the RDS using connection strings configured in the appsettings.json.

2. EC2 Instance:
- Launched an AWS EC2 instance with the required configuration to run .NET applications.
- Installed YUM package manager and .NET SDK 8.0 to support the backend app in the AWS ssh.
- Cloned the Git repository of the backend app and ran the application using "dotnet run --urls http://0.0.0.0:5000".

