using FiorelloAppApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiorelloAppApi.Helpers.EntityConfigurations
{
    public class SliderConfigurations : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {

            builder.Property(s => s.Image)
                   .IsRequired()
                   .HasMaxLength(200);
        }
    }
}
