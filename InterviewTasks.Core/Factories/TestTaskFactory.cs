using System;
using InterviewTasks.Core.Abstractions;
using InterviewTasks.Core.Enums;
using InterviewTasks.Core.Models;

namespace InterviewTasks.Core.Factories
{
    public class TestTaskFactory : ITestTaskFactory
    {
        public TestTask Create(Guid id, string title, string decription,
            DateTime dateAdded,string filePath, DifficultyLevels difficultyLevels,
            Guid categoryId, Category category, ICollection<Tag> tags)
        {
            return new TestTask(id, title, decription,
                dateAdded, filePath, difficultyLevels,
                categoryId, category, tags);
        }
    }
}

