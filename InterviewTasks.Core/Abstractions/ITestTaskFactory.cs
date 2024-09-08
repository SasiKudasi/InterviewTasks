using System;
using InterviewTasks.Core.Enums;
using InterviewTasks.Core.Models;

namespace InterviewTasks.Core.Abstractions
{
	public interface ITestTaskFactory
	{
        TestTask Create(Guid? id, string title, string decription,
                        DateTime dateAdded, string filePath,
                        DifficultyLevels difficultyLevels,
                        Guid categoryId, Category category, ICollection<Tag> tags);
    }
}

