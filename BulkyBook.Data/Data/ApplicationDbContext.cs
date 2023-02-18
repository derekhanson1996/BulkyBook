using BulkyBook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.Data
{
    public class ApplicationDbContext :IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //Creates a table named Categories using the Category class
        public DbSet<Category> Categories { get; set; }

        //Creates a table named CoverTypes using the CoverType class
        public DbSet<CoverType> CoverTypes { get; set; }

        //Creates a table named Products using the Product class
        public DbSet<Product> Products { get; set; }
    }
}