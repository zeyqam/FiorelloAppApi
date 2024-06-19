using FiorelloAppApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FiorelloAppApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderInfo> SlidersInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Slider>().HasQueryFilter(m => !m.SofDeleted);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            
        }

    }
}
