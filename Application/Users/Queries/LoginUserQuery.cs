using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class LoginUserQuery: IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
