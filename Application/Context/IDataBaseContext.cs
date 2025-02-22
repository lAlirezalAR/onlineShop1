using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Context
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }
        int SaveChanges();
    }
}
