    using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            for (int i = 1; i <= 1000; i++)
            {
                modelBuilder.Entity<Models.Book>().HasData(new Models.Book()
                {
                     Id = i,
                     Name = "Kitap Adı"+i ,
                     Description = "Kitap açıklaması..."+ i,
                     PageCount=300+i
            });
            }
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Models.Book> Books { get; set; }
    }
}
