using System;
using System.Web.Mvc;

namespace FruitCorp.Web
{
    public class Global : EPiServer.Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
        }
    }
}