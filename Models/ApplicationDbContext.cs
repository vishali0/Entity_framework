using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Crud_Operation.NewFolder
{
    class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;user id=sa;password=Ilmf@9003781886;database=CustomerDatabase");
        }

        public DbSet<Customer> Customers { get; set; }
        
    }
}
