using AWSApp.Application.Interfaces.Auth;
using AWSApp.Application.Logic.Interfaces.Auth;
using AWSApp.Application.Logic.Services.Auth;
using AWSApp.Application.Services.Auth;
using AWSApp.Common.Interfaces;
using AWSApp.Common.Services;
using AWSApp.Data.DBContext;
using AWSApp.Data.Interfaces;
using AWSApp.Data.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Infrastructure.IoC
{
    public class APIDependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });



            services.AddSingleton(new ConnectionString(configuration.GetConnectionString("FSDADBConnection")));


            var connectionDict = new Dictionary<DatabaseConnectionName, string>
            {
                { DatabaseConnectionName.SWMasterApp, configuration.GetConnectionString("FSDADBConnection")   },
            };


            services.AddSingleton<IDictionary<DatabaseConnectionName, string>>(connectionDict);


            services.AddScoped<IDapperDb, DapperDb>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtToken, JwtToken>();
            services.AddScoped<IUtility,AWSApp.Common.Services.Utility>();
            services.AddScoped<ICaptchaService, CaptchaService>();

            services.AddScoped<IAESHelper, AESHelper>();
            services.AddScoped<IRSAHelper, RSAHelper>();
        }
    }
}
