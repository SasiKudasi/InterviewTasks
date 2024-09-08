using System;
namespace InterviewTasks.Contracts.TagDTO
{
	public record TagRequest(
		Guid Id,
		string Name,
		Guid? TestTaskId);
}

