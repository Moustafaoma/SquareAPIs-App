using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square.Core.MiddleWares
{
    // To Measure the time of request in APIs EndPoint
    public class ProfilingMiddleWare
    {
        private readonly RequestDelegate _next; /// To go to the next middleware
        private readonly ILogger<ProfilingMiddleWare> _logger; //To Write the information in output window 
        public ProfilingMiddleWare(RequestDelegate next, ILogger<ProfilingMiddleWare> logger)
        {
            _next = next;
            _logger = logger;

        }
        public async Task Invoke(HttpContext context)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            await _next(context);
            stopWatch.Stop();
            _logger.LogInformation($"Request  {context.Request.Path} took {stopWatch.ElapsedMilliseconds}ms to execute ");
        }



    }
}
