using LMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Data
{
    public class SmartLMSDbContext : DbContext
    {
        public SmartLMSDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<categories> categories { get; set; }
        public virtual DbSet<courses> courses { get; set; }
        public virtual DbSet<units> units { get; set; }
        public virtual DbSet<questions> questions { get; set; }
        public virtual DbSet<choices> choices { get; set; }
        public virtual DbSet<responses> responses { get; set; }
        public virtual DbSet<attempts> attempts { get; set; }
        public virtual DbSet<enrolls> enrolls { get; set; }
    }
}

