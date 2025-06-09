namespace test.Models.data
{
    using Microsoft.EntityFrameworkCore;
   

    namespace test.Data
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
            {
            }

            public DbSet<Film> Films { get; set; }
            public DbSet<Cinema> Cinemas { get; set; }
        }
    }

}
