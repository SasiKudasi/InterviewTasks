using System;
using InterviewTasks.Core.Models;

namespace InterviewTasks.DataAccess.Entities
{
	public class TagEntity
	{
        public Guid Id { get; }
        public string Name { get; }
        public Guid TestTaskId { get; set; }
        public TestTaskEntity TestTask { get; set; }
    }
}

