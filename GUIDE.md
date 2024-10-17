# Project Guide

## Setup
This project is running on Elastic Beanstalk, with an RDS database, with a SQS/SNS queueing system.

## Introduction
Backend PizzaShop API written in C#/.NET, frontend hosted by Swagger.

## Technical Designs
Users of the PizzaShop API can create and view customers, pizzas and orders.

## Technical Descriptions
The orders work through a SQS/SNS queueing system, where an order gets placed in the queue from post, and the orders
then get processed by going to the /processorders endpoint. You can view processed orders from the /vieworders endpoint.

When an order gets processed, it also gets pushed to the RDS database. Non-processed orders will not show up here.

## References
Look through the old AWS github repos for an idea on how to work with Elastic Beanstalk, RDS, SQS/SNS...

[Elastic Beanstalk, RDS](https://github.com/boolean-uk/csharp-cloud-aws-day-1)

[SQS/SNS](https://github.com/boolean-uk/csharp-cloud-aws-day-4)
