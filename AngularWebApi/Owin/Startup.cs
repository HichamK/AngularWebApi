using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(AngularWebApi.Owin.Startup))]

namespace AngularWebApi.Owin
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseCors(CorsOptions.AllowAll);

            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions()
            {
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(3),
                Provider = new OAuthAuthorizationProvider(),
                TokenEndpointPath = new PathString("/token"),
                AllowInsecureHttp = true,
            };

            appBuilder.UseOAuthAuthorizationServer(option);
            appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}