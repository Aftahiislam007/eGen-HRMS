using Egen.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Egen.Model.ModelConfiguration.Security
{
    public class UserDbConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "Sec");
            builder.Property(u => u.LoginId).HasMaxLength(50);
            builder.Property(p => p.Password).HasMaxLength(250);
        }
    }
}
