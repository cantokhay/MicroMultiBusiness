﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MicroMultiBusiness.IdentityServer.Tools
{
	public class JwtTokenGenereator
	{
		public static TokenResponseVM GenerateToken(GetCheckAppUserVM model)
		{
			var claims = new List<Claim>();
			if(!string.IsNullOrWhiteSpace(model.Role))
				claims.Add(new Claim(ClaimTypes.Role, model.Role));

			claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id));

			if (!string.IsNullOrWhiteSpace(model.UserName))
				claims.Add(new Claim("UserName", model.UserName));

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
			var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);
			JwtSecurityToken token = new JwtSecurityToken(
				issuer: JwtTokenDefaults.ValidIssuer,
				audience: JwtTokenDefaults.ValidAudience,
				claims: claims,
				notBefore: DateTime.UtcNow,
				expires: expireDate,
				signingCredentials: signInCredentials);

			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			return new TokenResponseVM(tokenHandler.WriteToken(token), expireDate);
		}
	}
}
