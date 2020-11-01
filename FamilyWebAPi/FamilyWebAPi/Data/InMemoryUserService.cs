using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNPAssigment1.Models;


namespace DNPAssigment1.Data
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;
        
        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    Password = "123456",
                    Role = "admin",
                    SecurityLevel = 2,
                    UserName = "Admin1"
                },  
                new User
                {
                    Password = "654321",
                    Role = "UsualUser",
                    SecurityLevel = 1,
                    UserName = "Bob"
                },
            }.ToList();
        }

        public async Task<User> ValidateUserAsync(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName
            ));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}