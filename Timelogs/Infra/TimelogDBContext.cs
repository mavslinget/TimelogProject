using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra
{
    public class TimelogDBContext : DbContext
    {
        public DbSet<Employees> Employee { get; set; }
        public DbSet<Departments> Department { get; set; }
        public DbSet<Timelog> Timelog { get; set; }


        public TimelogDBContext(DbContextOptions<TimelogDBContext> options) : base(options)
        {

        }
        public TimelogDBContext()
        {

        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=.;Database=Timelogs;Integrated Security=true;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}


