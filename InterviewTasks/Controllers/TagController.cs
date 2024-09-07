using System;
using InterviewTasks.Core.Abstractions;
using InterviewTasks.Core.Models;
using Microsoft.AspNetCore.Mvc;


namespace InterviewTasks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
	{
		private readonly IService<Tag> _service;
		public TagController(IService<Tag> service)
		{
			_service = service;
		}


	}
}

