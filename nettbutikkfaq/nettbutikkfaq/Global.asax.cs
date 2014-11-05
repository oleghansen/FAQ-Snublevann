using nettbutikkfaq.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace nettbutikkfaq
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer<DatabaseContext>(new DbInitializer());

            using (var db = new DatabaseContext())
            {
                {
                    db.Database.Initialize(true);
                }
            }
        }
    }
}
