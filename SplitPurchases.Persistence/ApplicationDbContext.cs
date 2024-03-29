﻿using Microsoft.EntityFrameworkCore;
using SplitPurchases.Application.Interfaces;
using SplitPurchases.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //here we can add logic before saving
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //here we can customize models using Fluent Api
            base.OnModelCreating(modelBuilder);
        }
    }
}
