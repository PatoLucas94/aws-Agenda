using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
//[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace getUser_PF
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<UserResponse> FunctionHandler(UserRequest userRequest)
        {
            var userService = new UserService(new AmazonDynamoDBClient());
            var result = await userService.getUserAsync(userRequest.Id);
            return new UserResponse 
            {
                StatusCode = 200,
                Message = "Response Successfull",
                Data = result
            };
        }
    }
}
