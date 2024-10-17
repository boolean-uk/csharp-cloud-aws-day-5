# Project Guide

## Setup
Backend running on Elastic Beanstalk, with an RDS database, with a SQS/SNS queueing system.

Follow the references for hosting this application on Elastic Beanstalk, for creating an RDS database,
and for setting up SQS/SNS.

## Introduction
Backend PizzaShop API written in C#/.NET (Frontend TBA).

## Technical Designs
Users of the PizzaShop API can create and view customers, pizzas and orders.

Endpoints:

+ ***/*** Root directory
+ ***/customers*** Post/Get for customers
+ ***/pizzas*** Post/Get for pizzas
+ ***/orders*** Post order to queue
+ ***/processorders*** Process the orders in queue
+ ***/vieworders*** View the orders that have been processed

## Technical Descriptions
The orders work through a SQS/SNS queueing system, where an order gets placed in the queue from post, and the orders
then get processed by going to the /processorders endpoint. You can view processed orders from the /vieworders endpoint.

When an order gets processed, it also gets pushed to the RDS database. Non-processed orders will not show up here.

## References
Look through the old AWS github repos for an idea on how to work with Elastic Beanstalk, RDS, SQS/SNS...

[Elastic Beanstalk, RDS](https://github.com/boolean-uk/csharp-cloud-aws-day-1)

[SQS/SNS](https://github.com/boolean-uk/csharp-cloud-aws-day-4)
