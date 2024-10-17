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
   - Click `Create database` (All options not mentioned should be left the same as they are)
   - Engine options:
     - Select `PostgreSQL`
   - Templates:
     - Select `Free tier`
   - Settings:
     - Change the name of `DB instance identifier` (e.g `{name}-database`)
     - Set a `Master password`. Remember this!
   - Instance configuration:
     - Change `db.t4g.micro` to `db.t3.micro`
   - Connectivity:
     - Set `Public access` to `Yes`
   - Monitoring:
     - Uncheck `Turn on Performance Insights`
   - Click `Create database`
   - In the newly created database. Note down `{Endpoint} & {port}` in the `Connectivity & security` section!

4. Connecting the RDS database to your backend
   - In your backend, open `appsettings.json` and add this line under `"AllowedHosts": "*"`:
   ```bash
   "ConnectionStrings": {
    "DefaultConnection": "Host={Endpoint};Port={port};Database={name}-database;User Id=postgres;Password={Master password}"
    }
   ```
   - Now when your backend code is completed you can run these commands in Visual Studio's `Package Manager Console`:
   ```bash
   add-migration First
   ```
   ```bash
   update-database
   ```
   - If everything was set up correctly you should now be able to connect to your database with `TablePlus` or `Beehive` and see that your `DbSet` items in your DbContext are tables in the database.

5. Zip the backend
   - Navigate to your folder `backend.wwwapi` in git bash and run this command:
   ```bash
   dotnet publish -c Release -o out
   ```
   - Go to the `out` folder in File Explorer
   - Select all files
     - `Compress to...`
       - `ZIP`
   - Name it `backend.zip`

6. Deploy your Backend API
   - Navigate to  [Elastic Beanstalk](https://eu-north-1.console.aws.amazon.com/elasticbeanstalk/home?region=eu-north-1#/applications)
   - Click `Create application`
     - Enter application name (e.g `{name}-backend-api`)
     - Click `Create`
   - Click `Create new environment` (All options not mentioned should be left the same as they are)
   - Environment information:
     - Enter environment name (e.g `{name}-backend-env`)
   - Platform:
     - Set `Platform` to `.NET Core on Linux`
   - Application Code:
     - Select `Upload your code`
     - Set `Version label` to `v1`
     - Select `Local file`
     - Select `Choose file` and choose your `backend.zip` file.
   - Presets:
     - Select `High availability`
   - Click `Next`
    -----------------------------
   - Scroll down all the way and Click `Skip to review`
   - Click `Edit` on `Step 4: Configure instance traffic and scaling`
   - Instances:
     - Set `Root volume type` to `General Purpose 3(SSD)`
   - Capacity:
     - Remove the `t3.small` tag.
   - Scroll down all the way and Click `Skip to review`
    -----------------------------
   - Scroll down all the way and Click `Submit`
   - Now just wait for the Backend to Deploy!
   - Note down your environments `Domain`

7. Prepare the Frontend
   - Create a .env file in your frontend that contains:
   ```bash
   VITE_ENDPOINT_URL=http://{Domain}
   ``` 
   - Make sure the above url ends with `.com` and not `.com/`
   - Finish writing the code of the frontend that links to your backend.
   - Run this command to build the frontend:
   ```bash
   npm run build
   ```

8. Deploy your Frontend
   - Navigate to [S3 Bucket](https://eu-north-1.console.aws.amazon.com/s3/home?region=eu-north-1)
   - Click `Create bucket` (All options not mentioned should be left the same as they are)
   - General configuration:
     - Enter bucket name (e.g `{name}-bucket`)
   - Block Public Access settings for this bucket:
     - Uncheck `Block all public access`
     - Check `I acknowledge`
   - Click `Create bucket`
   -----------------------------
   - Navigate to the bucket you created and click on it
     - Click `Upload`
        - Click `Add files`
           - Select both `index.html` and `vite.svg` in your `dist` folder in the frontend and hit enter.
        - Click `Add folder`
          - Select the `assets` folder in your `dist` folder and hit enter.
    - Click `Upload`
   - Navigate to `Properties`
     - Find `Static website hosting` and Click `Edit`
       - Select `Enable`
       - Type `index.html` in `Index document`
       - Click `Save changes`
   - Navigate to `Permissions`
     - Find `Bucket policy` and Click `Edit`
       - Copy this code into the Policy:
       ```bash
        {
          "Version": "2012-10-17",
          "Statement": [
            {
              "Sid": "PublicReadGetObject",
              "Effect": "Allow",
              "Principal": "*",
              "Action": "s3:GetObject",
              "Resource": "arn:aws:s3:::{BucketName}/*"
            }
          ]
        }
       ```
       - Click `Save changes`
   - Navigate to `Properties`
     - Find `Static website hosting`
       - `Bucket website endpoint` contains the URL for your deployed Frontend. 

## Introduction


## Technical Designs

## Technical Descriptions

## References
