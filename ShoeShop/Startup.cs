using DevExtreme.AspNet.Data.Aggregation;
using InventoryManagement.Application.Services;
using InventoryManagement.Application.Services.BranchesService;
using InventoryManagement.Application.Services.CampaignService;
using InventoryManagement.Application.Services.ColorService;
using InventoryManagement.Application.Services.CustomerInfoService;
using InventoryManagement.Application.Services.PaymentMethodRepository;
using InventoryManagement.Application.Services.PaymentMethodService;
using InventoryManagement.Application.Services.ProductPropertyService;
using InventoryManagement.Application.Services.ProductService;
using InventoryManagement.Application.Services.ProductTypeService;
using InventoryManagement.Application.Services.RolePermessionsService;
using InventoryManagement.Application.Services.RoleService;
using InventoryManagement.Application.Services.SalesService;
using InventoryManagement.Application.Services.UserService;
using InventoryManagement.Application.StartupUtilities;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Data;
using InventoryManagement.EntityFrameworkCore.EntityFrameworkCore;
using InventoryManagement.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using InventoryManagement.Interface.Devextreme.Aggreagators;
using InventoryManagement.Repositories;
using InventoryManagement.Repositories.IRepositories;
using InventoryManagement.Utils.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;
using System.Text;

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
            CustomAggregators.RegisterAggregator("ProductSellingPrice", typeof(ProductSellingPriceAggreagtor<>));
            CustomAggregators.RegisterAggregator("ProductPrice", typeof(ProductPriceAggregator<>));
            CustomAggregators.RegisterAggregator("TotalAmount", typeof(TotalAmountAggregator<>));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        //IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
        ClockSkew = TimeSpan.Zero,
        //ValidateLifetime = true,
        //ValidIssuer = "http://mfuatnuroglu.com",
        //ValidAudience = "http://mfuatnuroglu.com",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDFSDFIJFDSFSDFSDFSDFSDFSDFSDFDSFSDFSDIDF"))
    };
});
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });



            //services.AddControllersWithViews();
            services.Configure<TokenSettings>(Configuration.GetSection("TokenSettings"));
            services.AddDbContext<InventoryManagementDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ShopShoeDB")));
            ConfigureIoC(services);

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddAutoMapper(typeof(InventoryManagement.Application.AutoMapper.Profiles.BranchProfile).GetTypeInfo().Assembly);
            services.AddSwagger();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling =
            ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
        }

        private static void ConfigureIoC(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();


            services.AddTransient<IColorsRepository, ColorsRepository>();
            services.AddTransient<IBranchesRepository, BranchesRepository>();
            services.AddTransient<IProductRepository, ProductsRepository>();
            services.AddTransient<ISalesRepository, SalesRepository>();
            services.AddTransient<IPaymentMethodsRepository, PaymentMethodsRepository>();
            services.AddTransient<IRoleAndRolePermessionsRepository, RoleAndRolePermessionsRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IPaymentMethodService, PaymentMethodService>();
            services.AddTransient<IColorService, ColorService>();
            services.AddTransient<IBranchService, BranchService>();
            services.AddTransient<ISalesService, SalesService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICustomerInfoService, CustomerInfoService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRolePermessionsService, RolePermessionsService>();
            services.AddTransient<IProductTypeService, ProductTypeService>();
            services.AddTransient<IProductPropertyService, ProductPropertyService>();
            services.AddTransient<ICampaignService, CampaignService>();




            services.AddTransient(typeof(IService<,>), typeof(Service<,>));
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
                // This helps to return Error explanation through resoponse
                //app.UseDeveloperExceptionPage();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseExceptionHandler("/error");
            app.UseCors("MyPolicy");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.AddUseSwagger("v1.0.0");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
