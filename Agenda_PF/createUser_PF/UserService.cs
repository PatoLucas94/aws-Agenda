using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace createUser_PF
{
    public class UserService : IUserService
    {
        private readonly IAmazonDynamoDB _amazonDynamoDB;
        public UserService(IAmazonDynamoDB amazonDynamoDB)
        {
            _amazonDynamoDB = amazonDynamoDB;
        }

        public async Task<int> createUserAsync(User newUser)
        {
            var request = new PutItemRequest
            {
                TableName = "Users",
                Item = new Dictionary<string, AttributeValue>
                {
                    {"Id", new AttributeValue{N = newUser.Id.ToString() }},
                    {"Name", new AttributeValue{S = newUser.Name }},
                    {"LastName", new AttributeValue{S = newUser.LastName}},
                    {"Address", new AttributeValue{S = newUser.Address }},
                    {"Email", new AttributeValue{S = newUser.Email }},
                    {"PhoneNumber", new AttributeValue{S = newUser.PhoneNumber }}
                }
            };

            await _amazonDynamoDB.PutItemAsync(request);

            return newUser.Id;
        }
    }
}
