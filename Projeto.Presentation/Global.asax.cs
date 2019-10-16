using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper; //importando..
using Projeto.Presentation.Mappings; //importando..

namespace Projeto.Presentation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //inicializando o automapper..
            Mapper.Initialize(cfg => { cfg.AddProfile<AutoMapperConfig>(); });

        }
    }
}
