using System;
using InterviewTasks.Core.Models;

namespace InterviewTasks.DataAccess.Entities
{
	public class TagEntity
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TestTaskId { get; set; }
        public TestTaskEntity TestTask { get; set; }
    }
}

