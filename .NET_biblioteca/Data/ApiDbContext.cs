#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

    public class ApiDbContext : DbContext
    {
        public ApiDbContext (DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Bibliotecario> Bibliotecario { get; set; }
    }
