﻿using System;
using FubuMVC.Core;

namespace ChatRoom
{
    public class Global : System.Web.HttpApplication
    {
        private FubuRuntime _runtime;

        protected void Application_Start(object sender, EventArgs e)
        {
            _runtime = FubuApplication
                .BootstrapApplication<ChatRoomAppSource>();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            _runtime.Dispose();
        }
    }
}