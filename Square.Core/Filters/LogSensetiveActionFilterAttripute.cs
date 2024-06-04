using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;


namespace Square.Core.Filters
{
    public class LogSensitiveActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            var clientIP = context.HttpContext.Connection.RemoteIpAddress.ToString();

           
            Debug.WriteLine($"Controller: {controllerName}, Action: {actionName}, Client IP: {clientIP}");

           
            var requestMethod = context.HttpContext.Request.Method;
            var requestPath = context.HttpContext.Request.Path;
            var requestQueryString = context.HttpContext.Request.QueryString;
            var requestHeaders = context.HttpContext.Request.Headers;

          
            Debug.WriteLine($"Request Method: {requestMethod}, Path: {requestPath}, Query String: {requestQueryString}");
            Debug.WriteLine("Request Headers:");
            foreach (var header in requestHeaders)
            {
                Debug.WriteLine($"{header.Key}: {header.Value}");
            }
        }
    }
}
