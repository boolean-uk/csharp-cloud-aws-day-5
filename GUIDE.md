**Note: Change any headings in this document**

# Project Guide

This guide dives into the setup and technicalities of setting up an AWS EC2 instance and hosting backend code on said instance.

## Setup
To setup an EC2 instance we need access to Amazons AWS services. Ensure you have an IAM account accessable to you and that you are able to access the EC2 service page on AWS.

To setup the actual instance we will follow the steps below to ensure we end up with a working instance. Ensure you follow the steps thouroghly as deviation from them may produce unwanted results.

**Step 1.**

* Open the AWS Management Console and navigate to the EC2 service.
* Click "Launch Instance."
* Choose an Amazon Machine Image (AMI), such as Amazon Linux 2 or Ubuntu Server.
* Select an instance type (e.g., t2.micro for free-tier).
* Configure instance details, ensuring that it’s deployed into the correct VPC and subnet.
* Add storage if necessary, or proceed with default settings.
* Configure security group settings to allow HTTP, HTTPS, and SSH access.
* Click "Launch" and select or create a new key pair to access the instance.

After completing these steps you have two ways of connecting to the EC2 instance. One is through the built in terminal in AWS and the other is through a terminal on your desktop which you use to SSH to the EC2 instance.

For this guide we will use the latter to prove the instance is setup correctly and works as expected.

**Step 2.**

Start by opening a CMD window. If problems occur when trying to execute the following commands, proceed by running it as administrator and try again.

Run the following command to connect to the EC2 instance.

```ssh -i "your-key.pem" ec2-user@your-ec2-public-ip```

NOTE: The "your-key.pem" is the file you downloaded when creating the key pair in the previous step. If you are not standing in the directory where the .pem file is please provide the path to it. The ec2-user should be ubuntu if you did not change it, as for the ip it is the public ip of the EC2 instance found on the AWS EC2 page.

When connected to the EC2 instance install all dependencies that are needed to host your backend. In our case we would run the following commands:

```sudo apt-get update```

```sudo apt-get install -y dotnet-sdk-8.0```

```sudo apt-get install -y nginx```

This will give you the basics to run the backend, please install any other dependencies you might need due to deviency.

**Step 3.**
Using ```scp``` we will transfer your backend code to the EC2 instance. Your backend code should be neatly packed into a .zip file for this. If not please run the following commands to publish and compress your backend.

```dotnet publish -c Release -o out```

```cd out```

```zip -r MyApi.zip .```

When you have this .zip file enter the following command in a terminal that is not connected to your EC2 instance:

```scp -i "your-key.pem" MyApi.zip ec2-user@your-ec2-public-ip:/home/ec2-user/```

NOTE: This command uses the same .pem key and user is ubuntu@your-public-ip and the directory path ec2-user should be replaced to ubuntu aswell.

In the terminal that is connected to the EC2 enter the following commands:

```unzip MyApi.zip```

```dotnet MyApi.dll```

Doing this should startup your backend on the EC2 instance. Then follow the instructions below

**Create a Virtual Private Cloud (VPC)**

1. In the AWS Management Console, navigate to the VPC service.
2. Click "Create VPC."
3. Choose "VPC only" and configure the CIDR block (e.g., 10.0.0.0/16).
4. Create subnets within your VPC for different availability zones.

**Configure Route Table and Internet Gateway**

1. Create and attach an Internet Gateway to your VPC to allow internet access.
2. In the Route Tables section, add routes that direct traffic to the Internet Gateway for public subnets.

**Create and Configure API Gateway**

1. Navigate to the API Gateway service.
2. Click "Create API" and select "REST API."
3. Define an API name and create an HTTP method (e.g., GET, POST) that corresponds to your backend application.
4. Set the integration type as "HTTP" or "Lambda Function," depending on your application.
   - For "HTTP" integration, use the public IP or domain of your EC2 instance as the endpoint.

**Test the API Gateway**

1. Once configured, test the API Gateway by sending HTTP requests to the API Gateway's URL.
2. Ensure that it forwards requests correctly to your EC2-hosted backend.

## Introduction
Setting up a robust backend infrastructure is crucial for any modern web application. This guide will walk you through the process of creating and configuring an EC2 instance on AWS, setting up a Virtual Private Cloud (VPC), and deploying an API Gateway to manage your backend services. By following these steps, you will ensure a secure, scalable, and efficient environment for your C# backend application.

## Technical Designs
The technical design of this setup involves several key components. First, we will create an EC2 instance, which serves as the virtual server for hosting your backend application. This instance will be configured with necessary software such as the .NET SDK and NGINX. Next, we will establish a VPC to provide a secure network environment, complete with subnets, route tables, and an Internet Gateway. Finally, we will set up an API Gateway to handle HTTP requests and route them to your backend application, ensuring seamless communication between the client and server.

## Technical Descriptions
**EC2 Instance Setup:** Begin by accessing the AWS Management Console and navigating to the EC2 service. Launch a new instance using an appropriate Amazon Machine Image (AMI) and instance type. Configure the instance details, including VPC and subnet settings, and set up security groups to allow necessary traffic. Once the instance is launched, connect to it via SSH and install the required dependencies, such as the .NET SDK and NGINX.
**VPC Configuration:** In the VPC service, create a new VPC with a specified CIDR block. Within this VPC, create subnets across different availability zones to ensure high availability. Attach an Internet Gateway to the VPC and configure route tables to direct traffic appropriately. This setup provides a secure and isolated network environment for your EC2 instance.
**API Gateway Setup:** Navigate to the API Gateway service in the AWS Management Console. Create a new REST API and define the necessary HTTP methods (e.g., GET, POST) that correspond to your backend application. Set the integration type to either HTTP or Lambda Function, depending on your application architecture. For HTTP integration, use the public IP or domain of your EC2 instance as the endpoint. Test the API Gateway to ensure it correctly forwards requests to your backend.
