using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Spinit.Data;
using Spinit.Data.Models;
using Spinit.Data.Services.Infrastructure;
using Spinit.Data.Services.Repository;
using SpinIt.Data.APIConfiguration;
using SpinIt.RightAPI.Data.Models.DTOs.Tokens;

namespace SpinIt.RightAPI
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);
            var tokenValidationParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
                //ValidateLifetime = false,
                //RequireExpirationTime = false
            };

            

            services.AddSingleton(tokenValidationParams);




            // Startup.ConfigureServices method

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer((options) =>
            //{
            //    options.Authority = "https://localhost:44327";
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateLifetime = true,
            //        ValidateAudience = false
            //    };
            //});


            //services.AddIdentity<User, UserRole>(options => 
            //{
            //    options.Cookies.ApplicationCookie.LoginPath = new PathString("/Admin/Account/Login");
            //});

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                jwt.SaveToken = true;
                jwt.RequireHttpsMetadata = false;
                jwt.TokenValidationParameters = tokenValidationParams;
            });

            services.AddScoped<IApplicationUser, ApplicationUserRepository>();
            services.AddScoped<IRefreshToken, RefreshTokenRepository>();
            //services.AddScoped<IProduct, ProductRepository>();
            //   services.AddScoped<IProductCategory,ProductCategoryRepository>();
            //   services.AddScoped<IPurchaseOrder, PurchaseOrderRepository>();
            //   services.AddScoped<IOrderDetail, OrderDetailRepository>();
            services.AddScoped<ISpecialization, SpecializationRepository>();
            services.AddScoped<IClassRoom, ClassRoomRepository>();
            services.AddScoped<ITeacher, TeacherRepository>();
            services.AddScoped<ISubject,SubjectRepository>();
            services.AddScoped<IGroup,GroupRepository>();
            services.AddScoped<ISubGroup, SubGroupRepository>();
            services.AddScoped<ISeminar,SeminarRepository>();
            services.AddScoped<ILaboratory,LaboratoryRepository>();

            //services.AddScoped<IUserActivation, UserActivationResipotory>();
            //services.AddScoped<IMessageSender, MessageSenderRepository>();

            services.AddControllers().AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpinIt.RightAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpinIt.RightAPI v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(options => options.AllowAnyOrigin());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }
}
