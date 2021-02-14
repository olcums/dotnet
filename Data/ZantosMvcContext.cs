using Microsoft.EntityFrameworkCore;
using ZantosMvc.Models;

namespace ZantosMvc.Data
{
    public class ZantosMvcContext : DbContext
    {
        public ZantosMvcContext (DbContextOptions<ZantosMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Report> Report { get; set; }
    }
}