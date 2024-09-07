using System;
using InterviewTasks.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewTasks.DataAccess.Configure
{
	public class CategoryConfigure : IEntityTypeConfiguration<CategoryEntity>
    {
		
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired();
            builder.HasMany(x => x.TestTasks)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}

