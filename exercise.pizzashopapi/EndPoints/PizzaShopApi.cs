using Amazon.EventBridge;
using Amazon.EventBridge.Model;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Amazon.SQS;
using Amazon.SQS.Model;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        private static string _queueUrl = "https://sqs.eu-north-1.amazonaws.com/637423341661/tvaltnOrderQueue"; // Format of https://.*
        private static string _topicArn = "arn:aws:sns:eu-north-1:637423341661:tvaltnOrderCreatedTopic"; // Format of arn:aws.*
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var shop = app.MapGroup("");
            shop.MapGet("/", ApiGet);
            shop.MapPost("/processorders", CreateOrder);
            shop.MapGet("/processorders", ProcessOrders);
            shop.MapGet("/vieworders", GetOrders);

            shop.MapPost("/pizzas", CreatePizza);
            shop.MapGet("/pizzas", GetPizzas);

            shop.MapPost("/customers", CreateCustomer);
            shop.MapGet("/customers", GetCustomers);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult ApiGet()
        {
            return TypedResults.Ok("API Works");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> ProcessOrders(IRepository<Order> repository)
        {
            IAmazonSQS sqs = new AmazonSQSClient();

            var request = new ReceiveMessageRequest
            {
                QueueUrl = _queueUrl,
                MaxNumberOfMessages = 10,
                WaitTimeSeconds = 20
            };

            var response = await sqs.ReceiveMessageAsync(request);

            var resultOrders = new List<Order>();

            foreach (var message in response.Messages)
            {
                Order? order = null;
                // Get the message that is nested in the queue request
                using (JsonDocument document = JsonDocument.Parse(message.Body))
                {
                    string innerMessage = document.RootElement.GetProperty("Message").GetString()!;

                    // Deserialize the inner message
                    order = JsonSerializer.Deserialize<Order>(innerMessage);
                }

                // Just delete duplicate orders, lazy...
                var existingOrder = await repository.Get([], o => o.PizzaId == order.PizzaId && o.CustomerId == order.CustomerId);
                if (existingOrder != null)
                {
                    await sqs.DeleteMessageAsync(_queueUrl, message.ReceiptHandle);
                    continue;
                }

                // Process order (e.g., update inventory)
                order!.Status = (PizzaStatus) 5;
                var result = await repository.Create(["Customer", "Pizza"], order!);
                resultOrders.Add(result); // add this to our resultorders list that we render

                // Delete message after processing
                await sqs.DeleteMessageAsync(_queueUrl, message.ReceiptHandle);
            }
            if (resultOrders.Count == 0)
            {
                return TypedResults.Ok("0 Orders have been added");
            }

            var resultDTO = new List<OrderDTO>();
            foreach (var res in resultOrders)
            {
                resultDTO.Add(new OrderDTO() { Customer = res.Customer, Pizza = res.Pizza, Status = res.Status.ToString() });
            }


            return TypedResults.Ok(resultDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrders(IRepository<Order> repository)
        {
            var result = await repository.GetAll(["Customer", "Pizza"]);
            var resultDTO = new List<OrderDTO>();
            foreach (var res in result)
            {
                resultDTO.Add(new OrderDTO() { Customer = res.Customer, Pizza = res.Pizza, Status = res.Status.ToString() });
            }
            return TypedResults.Ok(resultDTO);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateOrder(IRepository<Order> repository, OrderView view)
        {
            IAmazonSimpleNotificationService sns = new AmazonSimpleNotificationServiceClient();
            IAmazonEventBridge eventBridge = new AmazonEventBridgeClient();

            var order = new Order() { CustomerId = view.CustomerId, PizzaId = view.PizzaId, Status = (PizzaStatus) 1 };

            // Publish to SNS
            var message = JsonSerializer.Serialize(order);
            var publishRequest = new PublishRequest
            {
                TopicArn = _topicArn,
                Message = message
            };

            await sns.PublishAsync(publishRequest);

            // Publish to EventBridge
            var eventEntry = new PutEventsRequestEntry
            {
                Source = "order.service",
                DetailType = "OrderCreated",
                Detail = JsonSerializer.Serialize(order),
                EventBusName = "CustomEventBus"
            };

            var putEventsRequest = new PutEventsRequest
            {
                Entries = new List<PutEventsRequestEntry> { eventEntry }
            };

            await eventBridge.PutEventsAsync(putEventsRequest);

            return TypedResults.Ok("order put in queue");
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzas(IRepository<Pizza> repository)
        {
            var result = await repository.GetAll([]);
            var resultDTO = new List<PizzaDTO>();
            foreach (var res in result)
            {
                resultDTO.Add(new PizzaDTO() { Id = res.Id, Name = res.Name, Price = res.Price });
            }
            return TypedResults.Ok(resultDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePizza(IRepository<Pizza> repository, PizzaView view)
        {
            var result = await repository.Create([], new Pizza() { Name = view.Name, Price = view.Price });
            var resultDTO = new PizzaDTO() { Id = result.Id, Name = result.Name, Price = result.Price };
            return TypedResults.Ok(resultDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomers(IRepository<Customer> repository)
        {
            var result = await repository.GetAll([]);
            var resultDTO = new List<CustomerDTO>();
            foreach (var res in result)
            {
                resultDTO.Add(new CustomerDTO() { Id = res.Id, Name = res.Name });
            }
            return TypedResults.Ok(resultDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateCustomer(IRepository<Customer> repository, CustomerView view)
        {
            var result = await repository.Create([], new Customer() { Name = view.Name });
            var resultDTO = new CustomerDTO() { Id = result.Id, Name = result.Name };
            return TypedResults.Ok(resultDTO);
        }
    }
}
