using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleHttpHandler
{
    public class SimpleHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            response.Write("<html><body><h1>Wow.. We created our first handler");
            response.Write("</h1></body></html>");
        }
    }
}