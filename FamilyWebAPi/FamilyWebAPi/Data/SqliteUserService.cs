using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNPAssigment1.Models;
using FamilyWebAPi.DataAccess;

namespace DNPAssigment1.Data
{
    public class SqliteUserService : IUserService
    {
        private FamilyDBContext ctx;

        public SqliteUserService(FamilyDBContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<User> ValidateUserAsync(string userName, string password)
        {
            User first = ctx.Users.FirstOrDefault(user => user.UserName.Equals(userName
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