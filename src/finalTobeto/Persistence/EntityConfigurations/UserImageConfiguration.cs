using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;
public class UserImageConfiguration : IEntityTypeConfiguration<UserImage>
{
    public void Configure(EntityTypeBuilder<UserImage> builder)
    {
        builder.ToTable("UserImages").HasKey(ui => ui.Id);

        builder.Property(ui => ui.Id).HasColumnName("Id").IsRequired();
        builder.Property(ui => ui.UserId).HasColumnName("UserId");
        builder.Property(ui => ui.ImagePath).HasColumnName("ImagePath");
        builder.Property(ui => ui.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ui => ui.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ui => ui.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(x => x.User);

        builder.HasQueryFilter(ui => !ui.DeletedDate.HasValue);
    }
}