
using Microsoft.EntityFrameworkCore;
using Serilog;
using static SqlIntegrationAPI.ApiUtilities.ApiCommonCode;
using SqlIntegrationAPI.Data;
using SqlIntegrationAPI.Mappings;
using SqlIntegrationAPI.Middlewares;
using SqlIntegrationAPI.Repositories;
using Microsoft.AspNetCore.Identity;
using SqlIntegrationAPI.Models.Domains.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CommonCode.Jwt;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SqlIntegrationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(LogFile, rollingInterval: RollingInterval.Minute)
                .MinimumLevel.Error()
                .CreateBootstrapLogger();

            // Add services to the container.
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Get the connection string from configuration/User-Secrets
            string erp_SQL_ConnStr = builder.Configuration.GetValue("ERP_SQL_ConnStr", Emp);

            //string erp_SQL_ConnStr = "Data Source=10.10.1.138;Initial Catalog=ERP_SQL_Integration;User ID=sa;Password='=*fj9*N*uLBRNZV';Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

            if (string.IsNullOrEmpty(erp_SQL_ConnStr))
            {
                throw new InvalidOperationException("Connection string 'ERP_SQL_ConnStr' not found or is empty.");
            }
            builder.Services.AddDbContext<ErpSqlDbContext>(options =>
            options.UseSqlServer(erp_SQL_ConnStr, sqlOptions =>
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null)));

            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ErpSqlDbContext>();

            //CORS: localhost:4200, localhost:4100
            builder.Services.AddCors(options => {
                options.AddDefaultPolicy(policyBuilder =>
                {
                    policyBuilder
                    .WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>()[0])
                    .WithHeaders("Authorization", "origin", "accept", "content-type")
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    ;
                });

                options.AddPolicy("7182Client", policyBuilder =>
                {
                    policyBuilder
                    .WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>()[0])
                    .WithHeaders("Authorization", "origin", "accept")
                    .WithMethods("GET")
                    ;
                });
            });


            builder.Services.AddScoped<IServiceRepository, ServiceRepository>();

            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

            builder.Services.AddIdentity<AppUser, AppRole>(options =>
                {
                    options.Password.RequiredLength = 8;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireDigit = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_";
                }
            )
            .AddEntityFrameworkStores<ErpSqlDbContext>()
            .AddUserStore<UserStore<AppUser, AppRole, ErpSqlDbContext, Guid>>()
            .AddRoleStore<RoleStore<AppRole, ErpSqlDbContext, Guid>>()
            .AddDefaultTokenProviders();

            builder.Services.AddTransient<IJwtService, JwtService>();

            //var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            //var key = builder.Configuration.GetSection(jwtSettings["Secret"]);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
