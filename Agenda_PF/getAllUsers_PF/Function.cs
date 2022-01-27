using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace getAllUsers_PF
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <returns></returns>
        public async Task<UserResponse> FunctionHandler()
        {
            var userService = new UserService(new AmazonDynamoDBClient());
            var users = await userService.getAllUsersAsync();
            return new UserResponse
            {
                StatusCode = 200,
                Message = "Response successfull",
                Data = users

            };
        }
    }
}
