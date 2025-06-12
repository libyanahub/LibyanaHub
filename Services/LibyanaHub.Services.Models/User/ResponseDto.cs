namespace LibyanaHub.Services.Models.User
{
	public class ResponseDto
	{
		public object? Result { get; set; }
		public bool IsSuccess { get; set; } = true;
		public string Message { get; set; } = "Operation Success";
	}
}
