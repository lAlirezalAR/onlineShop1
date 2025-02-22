using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.AuthService
{
/**public interface AuthService:IAuthService
 {
     private readonly UserManager<User> _userManager;
     private readonly SignInManager<User> _signInManager;
     private readonly IConfiguration _configuration;

     public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
     {
         _userManager = userManager;
         _signInManager = signInManager;
         _configuration = configuration;
     }

     public async Task<string> RegisterAsync(RegisterDto model)
     {
         var user = new User { UserName = model.Email, Email = model.Email, FullName = model.FullName };
         var result = await _userManager.CreateAsync(user, model.Password);

         if (!result.Succeeded)
             return "ثبت نام ناموفق بود";

         return "ثبت نام موفقیت‌آمیز بود!";
     }

     public async Task<string> LoginAsync(LoginDto model)
     {
         var user = await _userManager.FindByEmailAsync(model.Email);
         if (user == null)
             return "کاربر یافت نشد";

         var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
         if (!result.Succeeded)
             return "نام کاربری یا رمز عبور نادرست است";

         return GenerateJwtToken(user);
     }

     private string GenerateJwtToken(User user)
     {
         var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]);
         var tokenHandler = new JwtSecurityTokenHandler();
         var tokenDescriptor = new SecurityTokenDescriptor
         {
             Subject = new ClaimsIdentity(new[]
             {
                 new Claim(ClaimTypes.NameIdentifier, user.Id),
                 new Claim(ClaimTypes.Name, user.UserName),
                 new Claim(ClaimTypes.Email, user.Email)
             }),
             Expires = DateTime.UtcNow.AddHours(2),
             SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
         };

         var token = tokenHandler.CreateToken(tokenDescriptor);
         return tokenHandler.WriteToken(token);
     }
 }**/
}
