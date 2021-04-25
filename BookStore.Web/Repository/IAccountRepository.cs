using BookStore.Web.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStore.Web.Repository
{
    public interface IAccountRepository
    {
        Task CreateUserAsync(SignUpModel model);
        Task<bool> Login(LoginModel model);
    }
}