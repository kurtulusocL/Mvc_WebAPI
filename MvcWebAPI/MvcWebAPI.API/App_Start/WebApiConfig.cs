﻿using MvcWebAPI.API.Attributes.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MvcWebAPI.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            //config.Formatters.Remove(config.Formatters.XmlFormatter);


            config.Filters.Add(new ExceptionAttribute());
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
