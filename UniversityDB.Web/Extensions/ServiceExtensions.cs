using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityDB.BLL.DTO;
using UniversityDB.BLL.DTO.TeacherRanksDTO;
using UniversityDB.Web.Mappings;
using UniversityDB.BLL.Services;
using UniversityDB.DAL.Entities;
using UniversityDB.DAL.Entities.TeachersRanks;
using UniversityDB.BLL.Mappings;

namespace UniversityDB.Web.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Registers authentication services.
        /// </summary>
        /// <typeparam name="TSessionData">Session data type.</typeparam>
        /// <param name="services">Service collection.</param>
        /// <returns>Service collection.</returns>
        public static IServiceCollection AddServicesInMemory(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //services.AddScoped<IRootService, RootService>();
            //services.AddScoped<IAuthService, AuthService>();

            //Add admin services.
            services.AddScoped<DatabaseStudentService>();
            services.AddScoped<DatabaseGroupService>();
            services.AddScoped<DatabaseFacultyService>();
            services.AddScoped<DatabaseDisciplineService>();
            services.AddScoped<DatabaseTeacherService>();
            //services.AddScoped<IDatabaseAdminService<Student, StudentDTO>, DatabaseAdminService<Student, StudentDTO>>();
            //services.AddScoped<IDatabaseAdminService<Discipline, DisciplineDTO>, DatabaseAdminService<Discipline, DisciplineDTO>>();
            //services.AddScoped<IDatabaseAdminService<Faculty, FacultyDTO>, DatabaseAdminService<Faculty, FacultyDTO>>();
            //services.AddScoped<IDatabaseAdminService<Group, GroupDTO>, DatabaseAdminService<Group, GroupDTO>>();
            //services.AddScoped<IDatabaseAdminService<ScheduleItem, ScheduleItemDTO>, DatabaseAdminService<ScheduleItem, ScheduleItemDTO>>();

            //Add mapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            services.AddSingleton(mappingConfig.CreateMapper());
            services.AddScoped<CustomMapper>();

            //services.AddCors();

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.RequireHttpsMetadata = JwtOptions.RequireHttps;
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidIssuer = JwtOptions.Issuer,

            //            ValidateAudience = true,
            //            ValidAudience = JwtOptions.Audience,

            //            ValidateLifetime = false,

            //            IssuerSigningKey = JwtOptions.GetSymmetricSecurityKey(),
            //            ValidateIssuerSigningKey = true,
            //        };
            //    });

            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1", new OpenApiInfo { Title = "VirtualSports", Version = "v1" });
            //    var filePath = Path.Combine(AppContext.BaseDirectory, "VirtualSports.Web.xml");
            //    if (File.Exists(filePath))
            //    {
            //        options.IncludeXmlComments(filePath);
            //    }
            //    options.AddSecurityRequirement(
            //        new OpenApiSecurityRequirement
            //        {
            //            {
            //                new OpenApiSecurityScheme
            //                {
            //                    Reference = new OpenApiReference
            //                    {
            //                        Id = "Bearer",
            //                        Type = ReferenceType.SecurityScheme
            //                    },
            //                },
            //                new string[0]
            //            }
            //        });

            //    options.AddSecurityDefinition(
            //        "Bearer",
            //        new OpenApiSecurityScheme
            //        {
            //            Type = SecuritySchemeType.ApiKey,
            //            In = ParameterLocation.Header,
            //            Scheme = "Bearer",
            //            Name = "Authorization",
            //            Description = "JWT token",
            //            BearerFormat = "JWT"
            //        });
            //});

            //services
            //    .AddAuthentication("JwtAuthentication")
            //    .AddScheme<JwtBearerOptions, AuthenticationHandler>(
            //        "JwtAuthentication", null);

            return services;
        }
    }
}
