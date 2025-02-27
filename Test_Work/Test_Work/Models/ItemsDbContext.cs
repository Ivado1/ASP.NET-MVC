using Microsoft.EntityFrameworkCore;

namespace Test_Work.Models
{
    public class ItemsDbContext: DbContext
    {
       public DbSet<Item> Items { get; set; }

        public ItemsDbContext(DbContextOptions<ItemsDbContext>options)
        :base(options)
        {

        }
    }
}
