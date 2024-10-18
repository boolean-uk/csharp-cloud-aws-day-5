**Note: Change any headings in this document**

# Project Guide

## Setup
I set up a RDS database with a beanstalk backend and bucket frontend, following the same setup that we used for AWS Day 1. I set up the RDS Postgres DB and connected a beanstalk to it. I then set up the todo api deliverables on the beanstalk and migrated the database. I then lastly set up a S3 bucket with the dist files from NPM build of the todo front-end react. 

## Technical Designs
Its the simple todo application that stores the todo entries in the database and fetches the data using the todo api.
The front end then fetch the data from the API's

## References
Csharp-AWS-Day-1
