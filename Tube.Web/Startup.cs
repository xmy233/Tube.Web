using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Tube.Web.Data;
using Tube.Web.Model;
using Tube.Web.Services;

namespace Tube.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration )
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //自定义注册服务
            //注册mvc框架
            services.AddMvc();

            //整个项目周期里只会出现最多一个WelcomeService实例
            // services.AddSingleton<IWelcomeService, WelcomeService>();

            //每次有方法请求IWelcomeService welcomeService参数都会生成一个实例
            // services.AddTransient<IWelcomeService, WelcomeService>();

            //每次http请求，web请求  都会生成一个实例，在web请求期间多次请求还是使用同一个参数实例
            // services.AddScoped<IWelcomeService, WelcomeService>();

            services.AddScoped<IRepository<Student>, EfCoreService>();

            //获取数据库连接字符串  从app.json中取
            //var connectionString = _configuration["ConnectionString:DefaultConnection"];
            //var connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IRepository<Student>, EfCoreService>();

            services.AddDbContext<IdentityDbContext>(options =>
            options.UseSqlServer(
                _configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("Tube.Web")));
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<IdentityDbContext>();
                }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env )
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Use(next =>
            //{
            //    return async HttpContext =>
            //    {
            //        if (HttpContext.Request.Path.StartsWithSegments("/first"))
            //        {
            //             await HttpContext.Response.WriteAsync("First!!!");
            //        }
            //        else
            //        {
            //            await next(HttpContext);
            //        }
            //    };
            //});
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            //app.UseFileServer();
            //app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath="/node_modules",
                FileProvider= new PhysicalFileProvider(Path.Combine(env.ContentRootPath,"node_modules"))
            });

            //app.UseMvcWithDefaultRoute();//默认路由
            app.UseMvc(builder =>
            {
                builder.MapRoute("Default","{controller=Home}/{action=Index}/{id?}");
            });
            //配置中间键
            //app.UseWelcomePage(new WelcomePageOptions
            //{
            //    Path = "/welcome"
            //});
            
        }
    }
}
