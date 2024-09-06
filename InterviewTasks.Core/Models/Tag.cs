using System;
using InterviewTasks.Core.Abstractions;

namespace InterviewTasks.Core.Models
{
	public class Tag
	{
		public Tag(Guid id, string name, Guid testTaskId, TestTask testTask)
		{
			Id = id;
			Name = name;
			TestTaskId = testTaskId;
			TestTask = testTask; 
		}

		public Guid Id { get; }
		public string Name { get; }
        public Guid TestTaskId { get; set; }
        public TestTask TestTask { get; set; }

    }
}

