using System;

namespace MicroMultiBusiness.IdentityServer.Tools
{
	public class TokenResponseVM
	{
		public TokenResponseVM(string token, DateTime expireDate)
		{
			Token = token;
			ExpireDate = expireDate;
		}

		public string Token { get; set; }
		public DateTime ExpireDate { get; set; }
	}
}
