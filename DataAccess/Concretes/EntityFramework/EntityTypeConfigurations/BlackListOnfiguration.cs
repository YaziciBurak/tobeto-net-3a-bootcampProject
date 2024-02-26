using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class BlackListOnfiguration : IEntityTypeConfiguration<BlackList>
{
    public void Configure(EntityTypeBuilder<BlackList> builder)
    {
        builder.ToTable("BlackLists").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.ApplicantId).HasColumnName("ApplicantId");
        builder.Property(x => x.Reason).HasColumnName("Reason");
        builder.Property(x => x.Date).HasColumnName("Date");
        builder.Ignore(x => x.CreatedDate);
        builder.Ignore(x => x.DeletedDate);
        builder.Ignore(x => x.UpdatedDate);

        builder.HasOne(x => x.Applicant);
    }
}
