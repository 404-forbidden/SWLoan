using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SWLoan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWLoan.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}
