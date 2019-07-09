using System;
using Application;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public partial class MotoDBContext : DbContext, IMotoDBContext
    {
        public MotoDBContext(DbContextOptions<MotoDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
