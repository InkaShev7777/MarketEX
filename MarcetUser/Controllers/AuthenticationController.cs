using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MarcetUser.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthenticationController:ControllerBase
	{
		private readonly RoleManager<IdentityRole> rolemanager;
		private readonly UserManager<IdentityUser> userManager;
		private readonly IConfiguration configuration;

		public AuthenticationController(RoleManager<IdentityRole> _rolemanager, UserManager<IdentityUser> _userManager, IConfiguration _configuration)
		{
			this.rolemanager = _rolemanager;
			this.userManager = _userManager;
			this.configuration = _configuration;
		}

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] Login model)
		{
			var user = await this.userManager.FindByNameAsync(model.UserName);
			var d = this.userManager.CheckPasswordAsync(user, model.Password);
			if(user != null && await userManager.CheckPasswordAsync(user, model.Password))
			{
				var userRole = await userManager.GetRolesAsync(user);
				var authClaimse = new List<Claim>
				{
					new Claim(ClaimTypes.Name,user.UserName),
					new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
				};
				foreach (var item in userRole)
				{
					authClaimse.Add(new Claim(ClaimTypes.Role, item));
				}
				var token = GetToken(authClaimse);
				return Ok(new
				{
					Token = new JwtSecurityTokenHandler().WriteToken(token),expiration = token.ValidTo
				}) ;
			}
			return Unauthorized();
		}
		private JwtSecurityToken GetToken(List<Claim> claimsList)
		{
			var signKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:secret"]));
			var token = new JwtSecurityToken(
				issuer: configuration["JWT:validIssuer"],
				audience: configuration["JWT:validAudience"],
				expires: DateTime.Now.AddHours(6),
				claims: claimsList,
				signingCredentials: new SigningCredentials(signKey,SecurityAlgorithms.HmacSha256)
				);
			return token;
		}
	}
}

