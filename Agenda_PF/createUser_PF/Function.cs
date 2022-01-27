using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.Lambda.Core;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
//[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace createUser_PF
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <returns></returns>
        public async Task<UserResponse> FunctionHandler(User newUser)
        {
            var userService = new UserService(new AmazonDynamoDBClient());
            var newUserId = await userService.createUserAsync(newUser);

            var sns = new AmazonSimpleNotificationServiceClient();
            string arnTopic = "arn:aws:sns:us-east-1:857777003126:CreateUser";
            string message = $"El cliente con ID {newUserId} se ha creado de forma exitosa";

            await sns.PublishAsync(new PublishRequest
            {
                Subject = "NEW CLIENT CREATED !!!",
                Message = message,
                TopicArn = arnTopic
            });

            return new UserResponse 
            {
                StatusCode = 200,
                Message = $"User Created Successfully with id {newUserId}"
            };
        }
    }
}
