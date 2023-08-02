namespace TasksWebApi.Middlewares
{
    public class TimeMiddleware
    {
        readonly RequestDelegate next;
        public TimeMiddleware(RequestDelegate next) => this.next = next;

        public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
        {
            await next(context);
            if (context.Request.Query.Any(a => a.Key == "time")) await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }
    }
    public static class TimeMiddlewareExtension
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder) => builder.UseMiddleware<TimeMiddleware>();
    }
}
