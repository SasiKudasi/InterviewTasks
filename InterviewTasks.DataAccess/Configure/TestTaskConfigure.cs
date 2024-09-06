using System;
using InterviewTasks.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewTasks.DataAccess.Configure
{
	public class TestTaskConfigure : IEntityTypeConfiguration<TestTaskEntity>
    {
		
        public void Configure(EntityTypeBuilder<TestTaskEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .IsRequired();
            builder.Property(x => x.Description)
                .IsRequired();
            builder.Property(x => x.DateAdded)
                .IsRequired();
            builder.Property(x => x.FilePath)
                .IsRequired(false);
            builder.Property(x => x.DifficultyLevels)
                .IsRequired();
            builder.HasOne(x => x.Category)
                .WithMany(x => x.TestTasks)
                .HasForeignKey(x => x.CategoryId);
            builder.HasMany(x => x.Tags)
                .WithOne(x => x.TestTask)
                .HasForeignKey(x => x.TestTaskId);
        }
    }
}

