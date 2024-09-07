using System;
namespace InterviewTasks.Contracts.TagDTO
{
	public record TagRequest(
		string Name,
		Guid TestTaskId);
}

