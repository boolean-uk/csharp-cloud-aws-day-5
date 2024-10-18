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
- Created an S3 bucket to host the frontend.
- Deployed the frontend code (HTML, CSS, JavaScript) to the S3 bucket.
- 

## Introduction
This project involves the development of a full stack application using AWS services such as RDS, EC2, and S3. The backend is connected to an RDS database, while the frontend is hosted on an S3 bucket. The entire infrastructure is deployed and run on AWS.

## Technical Designs
1. AWS Infrastructure
- RDS: The Relational Database Service (RDS) is used to store application data (CRUD operations).
- EC2: The Elastic Compute Cloud (EC2) instance runs the backend application, exposing the API endpoints.
- S3: Simple Storage Service (S3) is used to serve static assets of the frontend.
2. System Architecture
- The frontend hosted on S3 sends requests to the backend running on the EC2 instance. The backend is connected to the RDS database for data persistence.

## Technical Descriptions
1. RDS Setup:
- Created an RDS database with appropriate configurations for the backend.
- Connected the backend to the RDS using connection strings configured in the appsettings.json.

2. EC2 Instance:
- Launched an AWS EC2 instance with the required configuration to run .NET applications.
- Installed YUM package manager and .NET SDK 8.0 to support the backend app.
- Cloned the Git repository of the backend app and ran the application using "dotnet run --urls http://0.0.0.0:5000".

3. S3 Bucket:
- Created an S3 bucket to host the frontend.
- Uploaded the frontend files (HTML, CSS, JavaScript) to the bucket, ensuring that public access was enabled for web hosting.

4. CORS Setup:
- Configured CORS in the backend (Program.cs) to allow requests from the S3-hosted frontend by adding the appropriate policy in the .NET application.

## References
- **AWS Documentation:**
  - [Amazon RDS](https://docs.aws.amazon.com/rds/index.html)
  - [Amazon EC2](https://docs.aws.amazon.com/ec2/index.html)
  - [Amazon S3](https://docs.aws.amazon.com/s3/index.html)
  
- **.NET Documentation:**
  - [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
