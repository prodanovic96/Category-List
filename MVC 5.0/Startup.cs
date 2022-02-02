using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC_5._0.Data;
using Microsoft.EntityFrameworkCore;


namespace MVC_5._0
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Services are basically any functionality that you want to register so other parts of app can use it
        // We will be registering the services provided by the dot net core framework as well as custom services that we will
        // create
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // The pipline specifies how the app should respond to http request 
        // When app recives a request from the browser the request goes back throught the pipline
        // In the pipline you can add items that you want 
        // Pipline is made up of middlewares and mvc is a middleware itself
        // So if we want an app to be build using mvc we need to add that middleware 
        // Other examples could be authentication middleware, authorization, session, static files...
        // When your request go throught each middleware it can get modified by them and eventually it is either passed to
        // the next middleware and if that is the last middleware in the pipline the response is returned back to the server
        // 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();    // this is one middleware
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();      // middleware...
            app.UseStaticFiles();

            app.UseRouting();

            // Routing in MVC
            //  https://localhost:55555/Category/Index/3
            //  category is Controller    Index is Action    3 is id
            // Ako nemamo napisan Action onda se podrazumeva da je Index
            // Ako nemamo Id onda je on null

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
