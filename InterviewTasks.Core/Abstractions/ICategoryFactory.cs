using System;
using InterviewTasks.Core.Models;

namespace InterviewTasks.Core.Abstractions
{
	public interface ICategoryFactory
	{
		Category Create(Guid id, string name, ICollection<TestTask> testTasks);
	}
}

