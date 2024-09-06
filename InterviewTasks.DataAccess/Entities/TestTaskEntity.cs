using System;
using InterviewTasks.Core.Enums;

namespace InterviewTasks.DataAccess.Entities
{
	public class TestTaskEntity
	{
        public Guid Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime DateAdded { get; }
        public string FilePath { get; set; } = String.Empty;
        public DifficultyLevels DifficultyLevels { get; set; } = DifficultyLevels.Easy;
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public ICollection<TagEntity> Tags { get; set; } = new List<TagEntity>();
    }
}

