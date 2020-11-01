using System.Threading.Tasks;
using DNPAssigment1.Models;

 namespace DNPAssigment1.Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string userName, string password);
    }
}