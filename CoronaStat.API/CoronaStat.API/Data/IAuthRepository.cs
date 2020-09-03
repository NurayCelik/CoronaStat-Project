using CoronaStat.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaStat.API.Data
{
    public interface IAuthRepository
    {
        Task<User> RegisterAsync(User user, string password);
        Task<User> LoginAsync(string userName, string password);
        Task<bool> UserExistsAsync(string userName);
    }
}
