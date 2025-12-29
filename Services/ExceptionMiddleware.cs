using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                var response = new ApiResponse<string>(
                    500,
                    ex.Message,
                    null
                );

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }

}
