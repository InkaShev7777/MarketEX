using System;
using Domain;
using Domain.Interfaces.UnitOfWork;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarcetUser.Controllers
{
	[ApiController]
    
    [Route("api/[controller]")]
	public class ControllerClass : ControllerBase
	{
		private readonly IUnitOfWork unit;
		public ControllerClass(IUnitOfWork unitOfWork)
		{
			this.unit = unitOfWork;
		}
		//
		//	user
		//

		[HttpGet]
		[Route("GetAllCategory")]
		public IResult GetResult()
		{
			return Results.Ok(this.unit.categoryRepository.GetAll());
		}

		[HttpGet]
		[Route("GetProductsByID")]
		public IResult GetProductsByID(int id)
		{
			return Results.Ok(this.unit.productRepository.GetByCategoryID(id));
		}

        [HttpGet]
        [Route("SearchProduct")]
        public IResult SearchProduct(string text)
        {
            return Results.Ok(this.unit.productRepository.SearchProduct(text));
        }

        //
        //	admin
        //

        [HttpPost]
        [Route("addCategory")]
        [Authorize(Roles = RolesInProject.Admin)]
        public void AddCategory(CategoryProduct category)
        {
            this.unit.categoryRepository.Add(category);
        }

        [HttpPost]
		[Route("deleteProduct")]
		[Authorize(Roles = RolesInProject.Admin)]
		public void DeleteProduct(int id)
		{
			this.unit.productRepository.Delete(id);
		}
        [HttpPost]
        [Route("addProduct")]
        [Authorize(Roles = RolesInProject.Admin)]
        public void AddProduct(Product product)
        {
			this.unit.productRepository.Add(product);
        }
        [HttpPost]
        [Route("updateProduct")]
        [Authorize(Roles = RolesInProject.Admin)]
        public void UpdateProduct(Product product)
        {
			this.unit.productRepository.Update(product);
        }
    }
}

