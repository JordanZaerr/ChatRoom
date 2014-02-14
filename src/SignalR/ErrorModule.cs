using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;

namespace ChatRoom
{
    public class ErrorModule : HubPipelineModule
    {
        protected override void OnIncomingError(ExceptionContext exceptionContext, IHubIncomingInvokerContext invokerContext)
        {
            Console.WriteLine(exceptionContext.Error);

            //exceptionContext.Result = "Change the return value, nulls error";
            base.OnIncomingError(exceptionContext, invokerContext);
        }
    }
}