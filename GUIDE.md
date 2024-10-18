**Note: Change any headings in this document**

# Project Guide

## Setup
1. RDS Database Setup:
- Created and configured a RDS instance.
- Connected the RDS database to the backend project.

2. Elastic Beanstalk Setup:
- To deploy the backend I built my API, published the application, and compressed the out files.  
- Then I created an application in Elastic Beanstalk, and an environment for my application where I uploaded the zip file. 

3. S3 Bucket Setup:
- To deploy the frontend I created a S3 bucket and uploaded files and assets folder after running the npm run build command. 

## Introduction
This is a Todo Application where you can add tasks to a list, check off completed tasks, and delete tasks. 
The backend API is written in C# and deployed on AWS using a RDS Database and Elastic Beanstalk. The frontend is written in React and deployed using S3 Bucket.

## Technical Designs/Descriptions
Backend: The backend is built using .Net/C#. Through RESTful APIs with endpoints one it is possible to manage a Todo list. The application is connected to a RDS postgres database, and it is deployed on AWS using Elastic Beantalk that handles the application environment. 
Frontend: The frontend UI is built with React, and deploted on AWS using a S3 Bucket that is configured to host a static website. It can access the backend API hosted on Elastic Beantalk to make updated to the database.

## References
