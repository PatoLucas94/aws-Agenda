using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace getAllUsers_PF
{
    public class UserService : IUserService
    {
        private readonly IAmazonDynamoDB _dynamoDB;
        public UserService(IAmazonDynamoDB dynamoDB)
        {
            _dynamoDB = dynamoDB;
        }
        public async Task<User[]> getAllUsersAsync()
        {
            var result = await _dynamoDB.ScanAsync(new ScanRequest
            {
                TableName = "Users"
            });

            if (result != null && result.Items != null)
            {
                var users = new List<User>();
                foreach (var item in result.Items)
                {
                    item.TryGetValue("Id", out var id);
                    item.TryGetValue("Name", out var name);
                    item.TryGetValue("LastName", out var lastName);
                    item.TryGetValue("Address", out var address);
                    item.TryGetValue("Email", out var email);
                    item.TryGetValue("PhoneNumber", out var phoneNumber);

                    users.Add(new User
                    {
                        Id = Convert.ToInt32(id.N),
                        Name = name?.S,
                        LastName = lastName?.S,
                        Address = address?.S,
                        Email = email?.S,
                        PhoneNumber = phoneNumber?.S
                    });
                }
                return users.ToArray();
            }
            return Array.Empty<User>();
        }






    }
}
