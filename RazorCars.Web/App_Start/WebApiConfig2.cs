﻿using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RazorCars.Web
{
    public static class WebApiConfig2   
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

//            var formatters = GlobalConfiguration.Configuration.Formatters;
//            formatters.Insert(0, new EmberJsonMediaTypeFormatter());
//            var jsonFormatter = formatters.OfType<EmberJsonMediaTypeFormatter>().First();
//            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
//            jsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling = ReferenceLoopHandling.Ignore;
//            // Web API configuration and services
//            // Configure Web API to use only bearer token authentication.
//            config.SuppressDefaultHostAuthentication();
//            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
//            config.MapHttpAttributeRoutes(); 
//.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
        }
    }
}