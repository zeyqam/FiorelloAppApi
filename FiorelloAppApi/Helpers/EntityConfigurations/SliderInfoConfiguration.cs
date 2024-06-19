using FiorelloAppApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiorelloAppApi.Helpers.EntityConfigurations
{
    public class SliderInfoConfiguration : IEntityTypeConfiguration<SliderInfo>
    {
        public void Configure(EntityTypeBuilder<SliderInfo> builder)
        {
            builder.Property(si => si.Title)
              .IsRequired()
              .HasMaxLength(100); 

            builder.Property(si => si.Description)
                   .IsRequired()
                   .HasMaxLength(500); 

            builder.Property(si => si.Image)
                   .IsRequired()
                   .HasMaxLength(200);
        }
    }
}
