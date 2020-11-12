﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Primitives;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenIddict.Abstractions;
using KU.Repositories;
using KU.Services.Implementations;
using KU.Services.Interfaces;
using KU.Services.ViewModels;
using KU.WebAPI.Helpers;
using Swashbuckle.AspNetCore.Swagger;
using Newtonsoft.Json.Serialization;


namespace KU.WebAPI
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

            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            IConfigurationSection configurationSection = Configuration.GetSection("AppConfig").GetSection("FilePath");



            // add ApplicationDbContext
            services.AddDbContext<Repositories.ApplicationDbContext>(options =>
            {
                //options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"], b => b.MigrationsAssembly("TCIT.WebAPI"));
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"], b => b.MigrationsAssembly("KU.WebAPI"));
                options.UseOpenIddict();
            });

            // add identity
            
            services.AddIdentity<Repositories.Models.ApplicationUser, Repositories.Models.ApplicationRole>()
                .AddEntityFrameworkStores<Repositories.ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Configure Identity options and password complexity here
            services.Configure<IdentityOptions>(options =>
            {
                // User settings
                options.User.RequireUniqueEmail = true;


                //    //// Password settings
                options.Password.RequireDigit = true;
                //options.Password.RequiredLength = 8;
                //options.Password.RequireNonAlphanumeric = false;
                //options.Password.RequireUppercase = true;
                //options.Password.RequireLowercase = false;
          

                //    //// Lockout settings
                 //  options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                  // options.Lockout.MaxFailedAccessAttempts = 10;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

        
                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });



            // Register the OpenIddict services.
            services.AddOpenIddict()
                .AddCore(options =>
                {
                    options.UseEntityFrameworkCore().UseDbContext<ApplicationDbContext>();
                })
                .AddServer(options =>
                {
                    options.UseMvc();
                    options.EnableTokenEndpoint("/connect/token");
                    options.AllowPasswordFlow();
                    options.AllowRefreshTokenFlow();
                    options.AcceptAnonymousClients();
                    options.DisableHttpsRequirement(); // Note: Comment this out in production
                    options.RegisterScopes(
                        OpenIdConnectConstants.Scopes.OpenId,
                        OpenIdConnectConstants.Scopes.Email,
                        OpenIdConnectConstants.Scopes.Phone,
                        OpenIdConnectConstants.Scopes.Profile,
                        OpenIdConnectConstants.Scopes.OfflineAccess,
                        OpenIddictConstants.Scopes.Roles);

//options.UseRollingTokens(); //Uncomment to renew refresh tokens on every refreshToken request
                    // Note: to use JWT access tokens instead of the default encrypted format, the following lines are required:
                   //  options.UseJsonWebTokens();
                })
                .AddValidation(); //Only compatible with the default token format. For JWT tokens, use the Microsoft JWT bearer handler.

            // Add cors
          //services.AddCors();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    ;
                
            }));
   



        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            // augustine - for model fields in case sensitive
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });



            // Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Khalifa LIMS API", Version = "v1" });
                c.OperationFilter<AuthorizeCheckOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "password",
                    TokenUrl = "/connect/token",
                    Description = "Note: Leave client_id and client_secret blank"
                });
            });

            //Add Policies ----missing

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireManagerOnly", policy =>
                      policy.RequireRole("Manager", "Administrator"));
            });



            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // SMTP Configurations
            services.Configure<SmtpConfig>(Configuration.GetSection("SmtpConfig"));

            // Business Services
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IFormService, FormService>();

            //services.AddScoped<ICustomerService, CustomerService>();

            // Create the User Module Separately
            services.AddScoped<IUserService, UserService > ();

            // Repositories
            services.AddScoped<IUnitOfWork, HttpUnitOfWork>();


        }

  

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddFile("Logs/log-{Date}.log");



            Utilities.ConfigureLogger(loggerFactory);
            EmailTemplates.Initialize(env);

    


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }
            else
            {
                app.UseExceptionHandler("/Error");
              

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

                //augusine
              //  app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
           

            //Configure Cors
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());


            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
          
            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Khalifa LIMS API V1");
                c.RoutePrefix = string.Empty;  // Set Swagger UI at apps root
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseMvc();
        }
    }
}
