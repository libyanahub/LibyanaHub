﻿namespace LibyanaHub.Services.Domain.Dtos
{
	public class LoginResponseDto
	{
		public UserDto User { get; set; }
		public string Token { get; set; }
	}
}
