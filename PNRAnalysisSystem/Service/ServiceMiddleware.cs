using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace PNRAnalysisSystem.Service
{
    public class ServiceMiddleware
    {
        public class AuthFilter : Attribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
            }
        }

        public class ServiceExceptionInterceptor : ExceptionFilterAttribute, IExceptionFilter
        {
            public override void OnException(ExceptionContext context)
            {
                var error = new Dictionary<string, string>()
                 {
                     {"StatusCode" , "500" },
                     {"Message" , "Something went wrong! Internal Server Error." }
                 };

                context.Result = new JsonResult(error);

                context.Result = new ViewResult
                {
                    ViewName = "../Home/Error"
                };
                context.ExceptionHandled = true;
            }
        }

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

                    await context.Response
                        .WriteAsync($"{GetType().Name} catch exception. Message: {ex.Message}");
                }
            }
        }
    }
}
