using Application.AuthServices;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class LoginUserQueryHandler:IRequestHandler<LoginUserQuery, string>
    {
        private readonly UserManager<User> userManager;
        private readonly IAuthService authService;

        public LoginUserQueryHandler(UserManager<User> userManager,IAuthService authService)
        {
            this.userManager = userManager;
            this.authService = authService;
        }

        public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null || !await userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new Exception("نام کاربری یا رمز عبور اشتباه هست");
            }
            return await authService.LoginAsync(request.Email, request.Password);
        }
    }
}
