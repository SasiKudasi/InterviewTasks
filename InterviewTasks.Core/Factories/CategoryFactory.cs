using System;
using InterviewTasks.Core.Abstractions;
using InterviewTasks.Core.Models;

namespace InterviewTasks.Core.Factories
{
	public class CategoryFactory : ICategoryFactory
    {
		

        public Category Create(Guid id, string name, ICollection<TestTask> testTasks)
        {
            return new Category(id, name, testTasks);
        }
    }
}

