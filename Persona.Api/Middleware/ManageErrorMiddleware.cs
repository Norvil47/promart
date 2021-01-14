using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Persona.Infraestructura.SeekWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Persona.Api.Middleware
{
    public class ManageErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ManageErrorMiddleware> _logger;
        public ManageErrorMiddleware(RequestDelegate next, ILogger<ManageErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ManejadorExceptionAsincrono(context, ex, _logger);
            }

        }

        private async Task ManejadorExceptionAsincrono(HttpContext context, Exception exception, ILogger<ManageErrorMiddleware> logger)
        {
            object errores = null;
            switch (exception)
            {
                case ManageException me:
                    _logger.LogError(exception, "Manejador error");
                    errores = me.errores;
                    context.Response.StatusCode = (int)me.codigo;
                    break;
                case Exception e:
                    _logger.LogError(exception, "Error de servidor");
                    errores = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            context.Response.ContentType = "application/json";
            if (errores is not null)
            {
                var resultado = JsonConvert.SerializeObject(errores);
                await context.Response.WriteAsync(resultado);
            }
        }
    }
}
