using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace updateUser_PF
{
    public class UserService: IUserService
    {
        private readonly IAmazonDynamoDB _amazonDynamoDB;
        public UserService(IAmazonDynamoDB amazonDynamoDB)
        {
            _amazonDynamoDB = amazonDynamoDB;
        }

        public async Task<User> updateUserAsync(User updatedUser)
        {
            var request = new UpdateItemRequest
            {
                TableName = "Users",
                Key = new Dictionary<string, AttributeValue>
                {
                    {"Id", new AttributeValue{N = updatedUser.Id.ToString()}}
                },
                ExpressionAttributeNames = new Dictionary<string, string>()
                {
                    {"#Name", "Name" },
                    {"#LastName", "LastName" },
                    {"#Address", "Address" },
                    {"#Email", "Email" },
                    {"#PhoneNumber", "PhoneNumber" },
                },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
                {
                    {":Name", new AttributeValue{S = updatedUser.Name }},
                    {":LastName", new AttributeValue{S = updatedUser.LastName }},
                    {":Address", new AttributeValue{S = updatedUser.Address }},
                    {":Email", new AttributeValue{S = updatedUser.Email }},
                    {":PhoneNumber", new AttributeValue{S = updatedUser.PhoneNumber }}
                },
                UpdateExpression = "SET #Name = :Name, #LastName = :LastName, #Address = :Address, " +
                "                       #Email = :Email, #PhoneNumber = :PhoneNumber"
            };

            await _amazonDynamoDB.UpdateItemAsync(request);
            return updatedUser;
        }
    }
}
