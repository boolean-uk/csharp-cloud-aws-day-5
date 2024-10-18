# Project Guide

## Scope

The scope of this project is to set up a backend application hosted on an Amazon EC2 instance, configure the necessary networking components using AWS services, 
and manage access through AWS Identity and Access Management (IAM).  
The project aims toward deploying and managing a backend application in a cloud environment, focusing on the following core objectives:

- Setting up an EC2 instance for hosting the backend application.
- Creating and configuring a Virtual Private Cloud (VPC) and API Gateway.
- Introducing IAM and policies for secure access management.

## Introduction

This project guide aims to walk you through the process of setting up a backend application on an Amazon EC2 instance, configuring essential networking components, and managing access using IAM. 
By the end of this project, you will have a functional backend application hosted on AWS, accessible via an API Gateway, and secured with IAM policies.

This project serves as a backend service designed to handle API requests using the following technologies:

- Language: C#
- Framework: ASP.NET Core
- Database: PostgreSQL

## Technical Designs

### EC2 Instance Setup
1. **Instance Creation:**
- Launch an EC2 instance using the AWS Management Console.
- Select an appropriate Amazon Machine Image (AMI) and instance type.
- Configure instance details, including VPC and subnet settings.
- Set up security groups to allow necessary traffic (HTTP, HTTPS, SSH).
2. **Instance Connection:**
- Connect to the EC2 instance using SSH.
- Install required dependencies for the backend application.
3. **Application Deployment:**
- Transfer application files to the EC2 instance.
- Deploy and start the backend application.
### Networking Configuration
1. **VPC Creation:**
-Create a VPC with a specified CIDR block.
-Set up subnets within the VPC.
2. **Internet Gateway and Route Table:**
-Attach an Internet Gateway to the VPC.
-Configure route tables to direct traffic to the Internet Gateway.
3. **API Gateway Setup:**
-Create a REST API using API Gateway.
-Configure HTTP methods and integrate with the backend application hosted on the EC2 instance.
### IAM and Policies
1. **IAM Basics:**
- Create IAM users and assign roles.
- Understand and apply IAM policies to control access to AWS resources.
2. **Role Assignment:**
- Create IAM roles for EC2 instances to access other AWS services.
- Attach policies to roles and assign them to EC2 instances.

## Technical Descriptions
### EC2 Instance Setup
- **Create an EC2 Instance:** Use the AWS Management Console to launch an instance, selecting an AMI like Amazon Linux 2 or Ubuntu Server. Choose an instance type (e.g., t2.micro for free-tier), configure instance details, and set up security groups to allow HTTP, HTTPS, and SSH access.
- **Connect to the EC2 Instance:** Use SSH to connect to the instance and install necessary dependencies such as the .NET SDK or Nginx.
- **Deploy Your Backend Application:** Transfer your application files to the EC2 instance using scp, extract the files, and start the application using the appropriate commands.
### Networking Configuration
- **Create a VPC:** In the AWS Management Console, create a VPC with a CIDR block (e.g., 10.0.0.0/16) and set up subnets in different availability zones.
- **Configure Route Table and Internet Gateway:** Attach an Internet Gateway to the VPC and configure route tables to direct traffic to the Internet Gateway for public subnets.
- **Create and Configure API Gateway:** Set up a REST API in API Gateway, define HTTP methods, and integrate with the backend application using the public IP or domain of the EC2 instance.
### IAM and Policies
- **Understand IAM Basics:** Navigate to the IAM service, create users, and assign roles. Attach policies to users based on their roles, such as AmazonEC2FullAccess or AmazonS3ReadOnlyAccess.
- **Create and Use IAM Roles:** Create IAM roles for EC2 instances to access other AWS resources, attach appropriate policies, and assign the roles to EC2 instances.
