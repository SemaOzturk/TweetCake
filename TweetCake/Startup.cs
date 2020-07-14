using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
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
using TweetCake.Application;
using TweetCake.Application.Hubs;
using TweetCake.Application.Services;
using TweetCake.DAL;
using TweetCake.DAL.Entities;
using TweetCake.Shared.Models;

namespace TweetCake
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
            services.AddControllers();
            services.AddScoped<TweetCakeDbContext>();
            services.AddDbContext<TweetCakeDbContext>(options => options.UseSqlServer("Data Source=.;Initial Catalog=TweetCake;Integrated Security=True"));

            services.AddSignalR();
            services.AddMediatR(typeof(Startup));

            services.AddScoped<IRepository<Tweet>, Repository<Tweet>>();
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<UserFriend>, Repository<UserFriend>>();
            services.AddScoped<IRepository<Mention>, Repository<Mention>>();
            services.AddScoped<IRepository<Message>, Repository<Message>>();
            services.AddScoped<IRepository<Tag>, Repository<Tag>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITweetService, TweetService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });
            services.AddAuthorization(config =>
            {
                config.AddPolicy(Policies.Admin,Policies.AdminPolicy());
                config.AddPolicy(Policies.User,Policies.UserPolicy());
            });
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "TweetCake"); });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseRouting();

            //app.UseAuthorization();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationHub>("/notificationhub");
            });

            app.UseEndpoints(x =>
            {
                x.MapHub<ChatHub>("/chathub");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserCreateModel, User>();

        }
    }
}
