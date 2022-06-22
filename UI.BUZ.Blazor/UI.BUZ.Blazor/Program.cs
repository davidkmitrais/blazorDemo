using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UI.BUZ.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddOidcAuthentication(options =>
            {
                // Configure your authentication provider options here.
                // For more information, see https://aka.ms/blazor-standalone-auth
                builder.Configuration.Bind("oidc", options.ProviderOptions);
            });


            //builder.Services.AddAuthorizationCore();
            //builder.Services.AddScoped<AuthenticationStateProvider, TestAuthStateProvider>();

            //.AddAccountClaimsPrincipalFactory<ArrayClaimsPrincipalFactory<RemoteUserAccount>>(); ;

            //string identityServerUrl = builder.Configuration.GetSection("oidc")["Authority"];

            //// We register a named HttpClient here for the API
            //builder.Services.AddHttpClient("identity")
            //    .AddHttpMessageHandler(sp =>
            //    {
            //        var handler = sp.GetService<AuthorizationMessageHandler>()
            //            .ConfigureHandler(
            //                authorizedUrls: new[] { identityServerUrl },
            //                scopes: new[] { "openid", "profile", "offline_access", "APIAccess" });
            //        return handler;
            //    });

            // we use the api client as default HttpClient
            //builder.Services.AddScoped(
            //  sp => sp.GetService<IHttpClientFactory>().CreateClient("identity"));

            //        builder.Services.AddAuthentication(options =>
            //            {
            //                options.DefaultScheme = "Cookies";
            //                options.DefaultChallengeScheme = "Oidc";
            //                options.DefaultAuthenticateScheme = "Cookies"; // <-- add this line
            //            })
            //.AddCookie("Cookies", options =>
            //{
            //})
            //.AddOpenIdConnect("oidc", options =>
            //{
            //    options.SignInScheme = "Cookies"; // <-- add this line
            //})
            ;

            await builder.Build().RunAsync();
        }
    }
}
