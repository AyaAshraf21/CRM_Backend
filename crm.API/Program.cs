
using crm.API.Middleware;
using crm.Application.Behaviors;
using crm.Application.Common.Mapping;
using crm.Application.Features.Customers.Validators;
using crm.Application.Features.Governates.Queries.GetAllGovernates;
using crm.Application.Interfaces;
using crm.Domain.Entities;
using crm.Infrastructure;
using crm.Infrastructure.Data;
using crm.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace crm.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<CRMContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
            });
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(GetAllGovernatesHandler).Assembly);
            });

            builder.Services.AddValidatorsFromAssemblyContaining<CustomerQueryParametersValidator>();

            builder.Services.AddTransient(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<CRMContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddScoped<IGovernorateRepository, GovernorateRepository>();
            builder.Services.AddScoped<IAreaRepository, AreaRepository>();
            builder.Services.AddScoped<ITagRepository, TagRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IFollowupRepository, FollowupRepository>();
            builder.Services.AddScoped<IAnalyticsRepository, AnalyticsRepository>();
            builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            builder.Services.AddScoped<IJwtRepository, JwtRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            builder.Services.Configure<JwtSettings>(
                builder.Configuration.GetSection("Jwt"));

            // JWT Authentication
            builder.Services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme =
                        JwtBearerDefaults.AuthenticationScheme;

                    options.DefaultChallengeScheme =
                        JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    var jwtSettings = builder.Configuration
                        .GetSection("Jwt")
                        .Get<JwtSettings>();

                    options.TokenValidationParameters =
                        new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidIssuer = jwtSettings.Issuer,
                            ValidAudience = jwtSettings.Audience,

                            IssuerSigningKey =
                                new SymmetricSecurityKey(
                                    Encoding.UTF8.GetBytes(jwtSettings.Key)
                                )
                        };
                });

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            // Swagger
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Enter your JWT token."
                    });

                options.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                await IdentitySeeder.SeedRolesAsync(
                    scope.ServiceProvider);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
