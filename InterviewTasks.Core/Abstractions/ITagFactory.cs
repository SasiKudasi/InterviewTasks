using System;
using InterviewTasks.Core.Models;

namespace InterviewTasks.Core.Abstractions
{
	public interface ITagFactory
	{
		Tag Create(Guid id, string name, Guid? testTaskId, TestTask testTask);
	}
}