using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace getUser_PF
{
    public class UserService : IUserService
    {
        private readonly IAmazonDynamoDB _amazonDynamoDB;
        public UserService(IAmazonDynamoDB amazonDynamoDB)
        {
            _amazonDynamoDB = amazonDynamoDB;
        }

        public async Task<User> getUserAsync(int id)
        {
            var request = new QueryRequest
            {
                TableName = "Users",
                KeyConditionExpression = "Id = :PK",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
                {
                    {":PK", new AttributeValue{N = id.ToString()} }
                },
            };

            var response = await _amazonDynamoDB.QueryAsync(request);

            var users = new List<User>();

            foreach (var item in response.Items)
            {
                item.TryGetValue("Id", out var _id);
                item.TryGetValue("Name", out var name);
                item.TryGetValue("LastName", out var lastName);
                item.TryGetValue("Address", out var address);
                item.TryGetValue("Email", out var email);
                item.TryGetValue("PhoneNumber", out var phoneNumber);

                users.Add(new User
                {
                    Id = Convert.ToInt32(_id.N),
                    Name = name?.S,
                    LastName = lastName?.S,
                    Address = address?.S,
                    Email = email?.S,
                    PhoneNumber = phoneNumber?.S
                });
            }

            return users[0];
        }



    }
}
