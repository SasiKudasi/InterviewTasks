using System;
using InterviewTasks.Core.Abstractions;
using InterviewTasks.Core.Enums;

namespace InterviewTasks.Core.Models
{
	public class TestTask
	{
		public TestTask(Guid? id, string title, string decription,
						DateTime dateAdded, string filePath,
						DifficultyLevels difficultyLevels,
						Guid categoryId, Category category, ICollection<Tag> tags )
		{
            Id = id;
            Title = title;
			Description = decription;
            DateAdded = dateAdded;
            FilePath = filePath;
            DifficultyLevels = difficultyLevels;
            CategoryId = categoryId;
            Category = category;
            Tags = tags ?? new List<Tag>();
        }
        public Guid? Id { get; }
        public string Title { get; } = String.Empty;
        public string Description { get; } = String.Empty;
        public DateTime DateAdded { get; }
        public string FilePath { get; } = String.Empty;
        public DifficultyLevels DifficultyLevels { get; } = DifficultyLevels.Easy;
        public Guid CategoryId { get; }
        public Category? Category { get; }
        public ICollection<Tag>? Tags { get; } = new List<Tag>();
    }
}

