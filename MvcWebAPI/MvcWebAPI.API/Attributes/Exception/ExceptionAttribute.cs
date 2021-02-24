using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace MvcWebAPI.API.Attributes.Exception
{
    public class ExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage errorMessage = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            errorMessage.ReasonPhrase = actionExecutedContext.Exception.Message;
            actionExecutedContext.Response = errorMessage;
            base.OnException(actionExecutedContext);
        }
    }
}