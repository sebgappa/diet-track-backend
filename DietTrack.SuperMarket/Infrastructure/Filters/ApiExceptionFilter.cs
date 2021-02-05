using DietTrack.SuperMarket.Core.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace DietTrack.SuperMarket.Infrastructure.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is CommandValidationException || context.Exception is QueryValidationException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            base.OnException(context);
        }
    }
}
