using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AuthService
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto model);
        Task<string> LoginAsync(LoginDto model);
    }
}
