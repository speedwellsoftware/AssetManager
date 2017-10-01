using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssetManager.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssetManager.Startup))]
namespace AssetManager
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }

        public void ConfigureServices(IServiceCollection services)
        {

        }
    }
}