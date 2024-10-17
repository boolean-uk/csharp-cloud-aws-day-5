**Note: Change any headings in this document**

# Project Guide

## Setup
1. Creating a backend
   - Open up git bash in this folder and write:
    ```bash
    mkdir Backend
    ```
   - Then run the following commands in the Backend directory:
   ```bash
   dotnet new sln --name backend
   ```
   ```bash
   dotnet new webapi --name backend.wwwapi
   ```
   ```bash
   dotnet sln add **/*.csproj
   ```

2. Creating a frontend
   - Go back to the root directory and write this in git bash:
    ```bash
    mkdir Frontend
    ```
    - Then run the following command in the Frontend directory:
    ```bash
    npm create vite@latest frontend -- --template react
    ```
    - Then run the following command in the frontend directory:
    ```
    npm install
    ```

Now both the skeleton for the backend and frontend should be set up.

3. Creating an RDS Database
   - Navigate to [RDS Database](https://eu-north-1.console.aws.amazon.com/rds/home?region=eu-north-1#databases:)

## Introduction

## Technical Designs

## Technical Descriptions

## References
