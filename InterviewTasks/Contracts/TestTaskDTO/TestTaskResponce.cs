﻿using System;
using InterviewTasks.Contracts.TagDTO;
using InterviewTasks.Core.Enums;
using InterviewTasks.Core.Models;

namespace InterviewTasks.Contracts.TestTaskDTO
{
    public record TestTaskResponce(
     Guid Id,
     string Title,
     string Description,
     DateTime DateAdded,
     string FilePath,
     DifficultyLevels DifficultyLevels,
     Guid? CategoryId,
     ICollection<TagRequest>? Tags);
}

