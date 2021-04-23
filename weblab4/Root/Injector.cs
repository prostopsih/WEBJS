using BLL.Infrastructure;
using BLL.Services;
using DAL.Context;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Root.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using BLL.Abstractions.Services;
using CloudinaryDotNet;
using DAL.Abstractions.Repositories;
using BLL.Abstractions;
using BLL.Abstractions.Infrastructure;

namespace Root
{
    public static class Injector
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MainProfile));


            services.AddScoped<DbContext, TouristicBaseContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<IMediaRepository, MediaRepository>();


            services.AddScoped<IUnit, Unit>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITourService, TourService>();
            services.AddScoped<IMediaService, MediaService>();
        }

        public static void AddCloudinary(IServiceCollection services, string cloudinary_url)
        {
            services.AddScoped(x => new Cloudinary(cloudinary_url));
        }

        public static void AddDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TouristicBaseContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
