using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application
{
    public interface IMotoDBContext
    {
        DbSet<User> Users { get; set; }
    }
}
