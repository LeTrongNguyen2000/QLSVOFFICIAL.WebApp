using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using QLSVOFFICIAL.Application.Catalog.Checkin;
using QLSVOFFICIAL.Application.System.Users;
using System;
using QLSVOFFICIAL.Data.EF;
using QLSVOFFICIAL.Data.Models;

namespace QLSVOFFICIAL.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            {
                //In-Memory
                services.AddDistributedMemoryCache();
                services.AddSession(options => {
                    options.IdleTimeout = TimeSpan.FromMinutes(10);
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                });
                services.AddHttpClient();
                services.AddControllersWithViews();
                services.AddSingleton<QLSVContext>();

                //Declare thì mới chạy được token
                services.AddIdentity<AppUser, AppRole>()
                    .AddEntityFrameworkStores<QLSVContext>()
                    .AddDefaultTokenProviders();
                    
                // Add framework services.
                services.AddMvc();
                //Cơ chế điều khiển vòng đời, mỗi lần request object sẽ tạo mới
                //services.AddTransient<>; // Những phần tử nào sử dụng I đều được trả về intern của class 

                //Declare DI
                //Đối với IPuclicStudentCheckinService chúng ta phải khởi tạo những cái gì

                //Cơ chế điều khiển vòng đời, mỗi lần request object sẽ tạo mới
                //Với mỗi IPuclicStudentCheckinService sẽ khởi tạo tk PuclicStudentCheckinService
                services.AddTransient<IPublicStudentCheckinService, PublicStudentCheckinService>();
                services.AddTransient<IManageStudentCheckinService, ManageStudentCheckinService>();
                services.AddTransient<IUserService, UserService>();

                services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
                services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
                services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
                

                services.AddControllersWithViews();

                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "My API: QLSVOFFICIAL",
                        Version = "v 1.0"
                    });

                    // your custom config

                    // this will group actions by localized name set in controller's
                    // DisplayAttribute
                    //options.TagActionsBy(GetSwaggerTags);

                    // this will add localized description to actions set in action's DisplayAttribute
                   // options.OperationFilter<DisplayOperationFilter>();
                });
            }
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger/json", "Swagger QLSVOFFICAIL.WebApp V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
