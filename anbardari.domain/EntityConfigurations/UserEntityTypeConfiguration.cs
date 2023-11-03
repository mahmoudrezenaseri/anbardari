using anbardari.domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace anbardari.domain.EntityConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> b)
        {
            b.HasKey(k => k.Id);

            b.Property(a => a.UserName).HasMaxLength(15);
            b.Property(a => a.About).IsRequired(false).HasMaxLength(350);
            b.Property(a => a.FirstName).HasMaxLength(20);
            b.Property(a => a.LastName).HasMaxLength(20);
            b.Property(a => a.BirthDate).IsRequired(false).HasMaxLength(150);
            b.Ignore(a => a.FullName);

            b.Property(p => p.CreateAt);
            b.Property(p => p.ModifiedAt);
        }
    }
}
