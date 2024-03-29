﻿using Entities.Concretes;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class ApplicationStateConfiguration : IEntityTypeConfiguration<ApplicationState>
{
    public void Configure(EntityTypeBuilder<ApplicationState> builder)
    {
        builder.ToTable("ApplicationStates").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.Name).HasColumnName("Name");

        builder.HasMany(x => x.Applications);
    }
}
