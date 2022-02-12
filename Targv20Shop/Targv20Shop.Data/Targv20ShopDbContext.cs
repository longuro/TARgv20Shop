﻿using Microsoft.EntityFrameworkCore;
using Targv20Shop.Core.Domain;

namespace Targv20Shop.Data
{
    public class Targv20ShopDbContext : DbContext
    {
        public Targv20ShopDbContext(DbContextOptions<Targv20ShopDbContext> options)
            : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<ExistingFilePath> ExistingFilePath { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<FileToDatabase> FileToDatabase { get; set; }
    }
}
