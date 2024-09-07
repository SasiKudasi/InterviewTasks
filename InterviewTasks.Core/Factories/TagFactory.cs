using System;
using InterviewTasks.Core.Abstractions;
using InterviewTasks.Core.Models;

namespace InterviewTasks.Core.Factories
{
	public class TagFactory : ITagFactory
    {
		

        public Tag Create(Guid id, string name, Guid testTaskId, TestTask testTask)
        {
            return new Tag(id, name, testTaskId, testTask);
        }
    }
}

