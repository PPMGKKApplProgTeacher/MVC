using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ZooMVCDemo.Models;

namespace ZooMVCDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ZooMVCDemo.Models.Zookeeper> Zookeeper { get; set; }
        public DbSet<ZooMVCDemo.Models.FAQ> FAQ { get; set; }
        public DbSet<ZooMVCDemo.Models.Animal> Animal { get; set; }
        public DbSet<ZooMVCDemo.Models.Department> Department { get; set; }
    }
}
