using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace LibyanaHub.Services.WebApi.Middleware
{
	public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
	{
		public async ValueTask<bool> TryHandleAsync(
			HttpContext httpContext,
			Exception exception,
			CancellationToken cancellationToken)
		{
			var exceptionMessage = exception.Message;
			logger.LogError(exception,
				"Error Message: {@ExceptionMessage}", exceptionMessage);

			var problemDetails = new ProblemDetails
			{
				Status = StatusCodes.Status500InternalServerError,
				Title = "Server Error: An unexpected error has occurred.",
				Detail = exception.Message, // It's often better to use a generic message in production
				Instance = httpContext.Request.Path,
			};

			httpContext.Response.StatusCode = problemDetails.Status.Value;

			await httpContext.Response
				.WriteAsJsonAsync(problemDetails, cancellationToken);

			return true;
		}
	}
}
