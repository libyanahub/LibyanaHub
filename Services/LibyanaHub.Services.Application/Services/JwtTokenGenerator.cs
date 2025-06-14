using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Domain.Entities.Identity;
using LibyanaHub.Services.Models.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibyanaHub.Services.Application.Services
{
	public class JwtTokenGenerator : IJwtTokenGenerator
	{
		private readonly JwtOptions _jwtOptions;

		public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions)
		{
			_jwtOptions = jwtOptions.Value;
		}

		public string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles)
		{
			var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
			var tokenHandler = new JwtSecurityTokenHandler();

			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.Email, applicationUser.Email),
				new Claim(ClaimTypes.NameIdentifier, applicationUser.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.UniqueName, applicationUser.UserName)
			};
			claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

			var descriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.AddSeconds(30),
				Issuer = _jwtOptions.Issuer,
				Audience = _jwtOptions.Audience,
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(key),
					SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(descriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
