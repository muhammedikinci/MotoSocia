using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace Application
{
    public interface IMotoDBContext
    {
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
