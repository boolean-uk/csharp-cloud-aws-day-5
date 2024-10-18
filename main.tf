provider "aws" {
  region = "eu-north-1"  # Change to your AWS region
}

# IAM role for Lambda execution with a policy
resource "aws_iam_role" "lambda_exec" {
  name = "lambda_exec_role"

  assume_role_policy = jsonencode({
    Version = "2012-10-17"
    Statement = [{
      Action = "sts:AssumeRole"
      Principal = {
        Service = "lambda.amazonaws.com"
      }
      Effect = "Allow"
      Sid    = ""
    }]
  })
}

# Attach basic execution policy to Lambda
resource "aws_iam_policy" "lambda_policy" {
  name        = "LambdaExecutionPolicy"
  description = "IAM policy for Lambda execution with necessary permissions"
  
  policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Effect = "Allow"
        Action = [
          "logs:CreateLogGroup",
          "logs:CreateLogStream",
          "logs:PutLogEvents"
        ]
        Resource = "*"
      }
    ]
  })
}

# Attach the created policy to the Lambda role
resource "aws_iam_role_policy_attachment" "lambda_execution_policy_attachment" {
  role       = aws_iam_role.lambda_exec.name
  policy_arn = aws_iam_policy.lambda_policy.arn
}

# Lambda function
resource "aws_lambda_function" "process_movie_data" {
  function_name = "ProcessMovieData"
  handler       = "ProcessMovieData::ProcessMovieData.Function::FunctionHandler"
  runtime       = "dotnet8"  # Change based on the .NET version you are using

  role = aws_iam_role.lambda_exec.arn

  filename = "ProcessMovieData.zip"  # The ZIP file containing your Lambda code
}

# API Gateway REST API
resource "aws_api_gateway_rest_api" "movie_api" {
  name        = "MovieAPI"
  description = "API for movie data"
}

# API Gateway Resource
resource "aws_api_gateway_resource" "movies" {
  rest_api_id = aws_api_gateway_rest_api.movie_api.id
  parent_id   = aws_api_gateway_rest_api.movie_api.root_resource_id
  path_part   = "movies"
}

# API Gateway Method (POST)
resource "aws_api_gateway_method" "post_movies" {
  rest_api_id   = aws_api_gateway_rest_api.movie_api.id
  resource_id   = aws_api_gateway_resource.movies.id
  http_method   = "POST"
  authorization = "NONE"  # Change if you want to use authentication
}

# Integration with Lambda function
resource "aws_api_gateway_integration" "post_movies_integration" {
  rest_api_id = aws_api_gateway_rest_api.movie_api.id
  resource_id = aws_api_gateway_resource.movies.id
  http_method = aws_api_gateway_method.post_movies.http_method

  integration_http_method = "POST"
  type                    = "AWS_PROXY"
  uri                     = aws_lambda_function.process_movie_data.invoke_arn
}

# API Gateway Deployment
resource "aws_api_gateway_deployment" "movie_api_deployment" {
  depends_on = [aws_api_gateway_integration.post_movies_integration]
  rest_api_id = aws_api_gateway_rest_api.movie_api.id
  stage_name  = "prod"
}
