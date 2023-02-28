using Data.UoW.Interface;
using Data.UoW.Realization;
using AutoMapper;
using Business.Automapper;
using Business.Interfaces;
using Business.Services;
using FluentValidation;
using Business.Validators;

namespace BookLibrary.Configurations
{
    public static class ServiceExtentions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IRatingService, RatingService>();

        }

        public static void ConfigureMapping(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<BookRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<ReviewRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<RatingRequestValidator>();
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsDefault", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader().
                    WithExposedHeaders("content-disposition"));
            });
        }


    }
}


  	