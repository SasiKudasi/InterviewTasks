using System;
using InterviewTasks.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewTasks.DataAccess.Configure
{
    public class TagConfigure : IEntityTypeConfiguration<TagEntity>
    {
        public void Configure(EntityTypeBuilder<TagEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired();
            builder.HasOne(x => x.TestTask)
                .WithMany(x => x.Tags)
                .HasForeignKey(x => x.TestTaskId);
        }
    }
}

