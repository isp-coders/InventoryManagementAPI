using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InventoryManagement.Application.Services.BranchesService;
using InventoryManagement.Application.Services.ColorService;
using InventoryManagement.Application.Services.PaymentMethodRepository;
using InventoryManagement.Application.Services.PaymentMethodService;
using InventoryManagement.Application.Services.ProductService;
using InventoryManagement.Application.Services.SalesService;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using InventoryManagement.Data;
using InventoryManagement.Repositories;
using InventoryManagement.Repositories.IRepositories;

namespace InventoryManagement
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
            services.AddDbContext<InventoryManagementDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ShopShoeDB")));
            ConfigureIoC(services);

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling =
            Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("LKSJDFKLLKSJDFKLLKSJDFKL"));
            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "yourdomain.com",
                ValidAudience = "yourdomain.com",
                IssuerSigningKey = key
            };
        });
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });
        }

        private static void ConfigureIoC(IServiceCollection services)
        {
            services.AddTransient<IColorsRepository, ColorsRepository>();
            services.AddTransient<IBranchesRepository, BranchesRepository>();
            services.AddTransient<IProductRepository, ProductsRepository>();
            services.AddTransient<ISalesRepository, SalesRepository>();
            services.AddTransient<IPaymentMethodsRepository, PaymentMethodsRepository>();


            services.AddTransient<IPaymentMethodService, PaymentMethodService>();
            services.AddTransient<IColorService, ColorService>();
            services.AddTransient<IBranchService, BranchService>();
            services.AddTransient<ISalesService, SalesService>();
            services.AddTransient<IProductService, ProductService>();


            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
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
                // This helps to return Error explanation through resoponse
                app.UseDeveloperExceptionPage();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseCors("MyPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
