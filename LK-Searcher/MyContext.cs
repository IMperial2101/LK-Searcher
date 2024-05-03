using Microsoft.EntityFrameworkCore;
using LK_Searcher.EntityModels;

namespace LK_Searcher
{
    internal class MyContext : DbContext
    {
        public MyContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database = LK-Searcher;username = postgres;password = 137731")
                //.LogTo(Console.WriteLine)
                ;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<ScopusFile> ScopusFiles { get; set; }
        public DbSet<WOSFile> WOSFiles { get; set; }
        public DbSet<Publish> Publishes { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}
