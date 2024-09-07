using System;
using InterviewTasks.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewTasks.DataAccess
{
	public class InterviewTasksDbContext : DbContext
	{
		public InterviewTasksDbContext(DbContextOptions<InterviewTasksDbContext> options) : base (options)
		{
		}
        DbSet<TestTaskEntity> TestTasks { get; set; }
		DbSet<TagEntity> Tags { get; set; }
		DbSet<TagEntity> Categories { get; set; }
	}
}

