using System;
namespace InterviewTasks.DataAccess.Entities
{
	public class CategoryEntity
	{
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<TestTaskEntity> TestTasks { get; set; } = new List<TestTaskEntity>();

    }
}

