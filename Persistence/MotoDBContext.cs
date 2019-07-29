using System;
using System.Collections.Generic;
using Application;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Persistence
{
    public partial class MotoDBContext : DbContext, IMotoDBContext
    {
        public MotoDBContext(DbContextOptions<MotoDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(b => b.GroupIDs)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<UserRelational>>(v)
                );

            modelBuilder.Entity<User>()
                .Property(b => b.PostIDs)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<UserRelational>>(v)
                );

            modelBuilder.Entity<User>()
               .Property(b => b.EventIDs)
               .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<UserRelational>>(v)
                );

            modelBuilder.Entity<Group>()
               .Property(b => b.MediaLinks)
               .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<MediaLink>>(v)
                );

            modelBuilder.Entity<Group>()
               .Property(b => b.AdminIDs)
               .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Counter<int>>(v)
                );

            modelBuilder.Entity<Group>()
               .Property(b => b.MemberIDs)
               .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Counter<int>>(v)
                );

            modelBuilder.Entity<Group>()
               .Property(b => b.EventIDs)
               .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Counter<int>>(v)
                );

            modelBuilder.Entity<Group>()
               .Property(b => b.PostIDs)
               .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Counter<int>>(v)
                );

            modelBuilder.Entity<Event>()
               .Property(b => b.Subscribers)
               .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Counter<int>>(v)
                );

            modelBuilder.Entity<Event>()
              .Property(b => b.EventDates)
              .HasConversion(
                   v => JsonConvert.SerializeObject(v),
                   v => JsonConvert.DeserializeObject<Dates>(v)
               );

            modelBuilder.Entity<Post>()
               .Property(b => b.LikedUsers)
               .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Counter<int>>(v)
                );

            modelBuilder.Entity<Post>()
               .Property(b => b.CommentedUser)
               .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Counter<int>>(v)
                );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
