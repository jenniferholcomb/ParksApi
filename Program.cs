using ParksApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer; 
using Microsoft.IdentityModel.Tokens;
//using Microsoft.AspNetCore.Identity;
using System.Text;

namespace TravelApi
{
    class Program
    {
        public IConfiguration Configuration { get; }

        public Program(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Jwt:Audience"], // can be set to anything
                    ValidIssuer = builder.Configuration["Jwt:Issuer"], // can be set to anything
                    ClockSkew = TimeSpan.Zero,// It forces tokens to expire exactly at token expiration time instead of 5 minutes later
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            //builder.Services.AddAuthorization();
            //builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();
            builder.Services.AddDbContext<ParksApiContext>(
                            dbContextOptions => dbContextOptions
                                .UseMySql(
                                builder.Configuration["ConnectionStrings:DefaultConnection"], 
                                ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                                )
                            )
                            );

            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<ITokenService, TokenService>();

            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.Use(async (context, next) =>    
            {
                var token = context.Session.GetString("Token"); 
                if (!string.IsNullOrEmpty(token))  
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + token);
                }
                await next();
            });

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run();

            // if (app.Environment.IsDevelopment())
            // {
            //     app.UseSwagger();
            //     app.UseSwaggerUI();
            // }
            // else
            // {
            //     app.UseHttpsRedirection();
            // }

            // app.UseAuthentication();
            // app.UseAuthorization();

            // app.MapControllers();
        }
    }
}

