using CoronaStat.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaStat.API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
      
        }
        // Values class, Values veritabanında tablo
        public DbSet<Value> Values { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorldParameter> WorldParameters{ get; set; }

    }
}
