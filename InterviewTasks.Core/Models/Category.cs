using System;
using InterviewTasks.Core.Abstractions;

namespace InterviewTasks.Core.Models
{
	public class Category
	{
		public Category(Guid id, string name, ICollection<TestTask> testTasks)
		{
			Id = id;
			Name = name;
			TestTasks = testTasks;
		}
		public Guid Id { get; }
		public string Name { get; } = string.Empty;
        public ICollection<TestTask> TestTasks { get; } = new List<TestTask>();

    }
}