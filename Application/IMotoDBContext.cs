using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application
{
    public interface IMotoDBContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Post> Posts { get; set; }

        int SaveChanges();
    }
}
