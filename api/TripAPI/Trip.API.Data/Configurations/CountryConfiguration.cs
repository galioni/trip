using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trip.API.Core.Models;

namespace Trip.API.Data.Configurations
{
	public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(80);

            builder
                .Property(m => m.Code)
                .IsRequired()
                .HasMaxLength(3);

            builder
                .Property(m => m.IsActive)
                .IsRequired();

            builder
                .Property(m => m.Created)
                .IsRequired();

            builder
                .Property(m => m.Modified)
                .IsRequired();

            builder
                .ToTable("Country");
        }
    }
}
