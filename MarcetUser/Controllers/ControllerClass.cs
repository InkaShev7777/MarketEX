using System;
using Domain.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MarcetUser.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ControllerClass:ControllerBase
	{
		private readonly IUnitOfWork unit;
		public ControllerClass(IUnitOfWork unitOfWork)
		{
			this.unit = unitOfWork;
		}
		[HttpGet]
		[Route("GetAllCategory")]
		public IResult GetResult()
		{
			return Results.Ok(this.unit.categoryRepository.GetAll());
		}
	}
}

