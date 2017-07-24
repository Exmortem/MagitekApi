using MagitekApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MagitekApi.Database
{
    public class MagitekContext : DbContext
    {
        public MagitekContext(DbContextOptions option) : base(option) { }
        public DbSet<MagitekSettings> MagitekSettings { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<News> News { get; set; }
    }

    public static class MagitekContextFactory
    {
        public static MagitekContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MagitekContext>();
            optionsBuilder.UseMySql("server=localhost;port=3306;database=Magitek;user=root;password=Fester79934");

            var context = new MagitekContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}
