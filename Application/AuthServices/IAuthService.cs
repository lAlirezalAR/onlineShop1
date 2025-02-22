using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AuthServices
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(string fullName, string email, string password);
        Task<string> LoginAsync(string email, string password);
    }
}
