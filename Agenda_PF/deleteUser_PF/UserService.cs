using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deleteUser_PF
{
    public class UserService : IUserService
    {
        private readonly IAmazonDynamoDB _amazonDynamoDB;
        public UserService(IAmazonDynamoDB amazonDynamoDB)
        {
            _amazonDynamoDB = amazonDynamoDB;
        }

        public async Task<int> deleteUserAsync(int id)
        {
            var request = new DeleteItemRequest
            {
                TableName = "Users",
                Key = new Dictionary<string, AttributeValue>
                {
                    {"Id", new AttributeValue{N = id.ToString()}}
                }
            };

            await _amazonDynamoDB.DeleteItemAsync(request);
            return id;
        }
    }
}
