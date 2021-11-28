
using System.Security.Claims;
using Data;
using Data.Impl;
using Blazor.Data;
using Blazor.Data.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Components.Authorization;

namespace DNPAssignment3Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<IFamilyService, FamilyService>();
            services.AddScoped<IUserService, ApiUserService>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            
            SetUpPolicies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
        
        private void SetUpPolicies(IServiceCollection services)
        {
            
            
            services.AddAuthorization(options =>
            {
                
                options.AddPolicy("IsLoggedIn", a => a.RequireAuthenticatedUser());
                
                
                options.AddPolicy("MustBeVIA", a => a.RequireAuthenticatedUser().RequireClaim("Domain", "via.dk"));
                options.AddPolicy("SecurityLevel4", a => a.RequireAuthenticatedUser().RequireClaim("Level", "4", "5"));
                options.AddPolicy("MustBeTeacher", a => a.RequireAuthenticatedUser().RequireClaim("Role", "Teacher"));
                options.AddPolicy("SecurityLevel2", a => a.RequireAuthenticatedUser().RequireAssertion(context =>
                {
                    Claim levelClaim = context.User.FindFirst(claim => claim.Type.Equals("Level"));
                    if (levelClaim == null) return false;
                    return int.Parse(levelClaim.Value) >= 2;
                }));
                
                
            });
        }
        
        
    }
}