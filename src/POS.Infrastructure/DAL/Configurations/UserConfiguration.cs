using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.DAL.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.Username).IsUnique();
            builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.FullName)
                .HasMaxLength(100);

            builder.Property(x => x.Role)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.CreatedAt)
                .IsRequired();
        }
    }
}
