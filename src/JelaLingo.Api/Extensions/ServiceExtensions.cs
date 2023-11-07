using JelaLingo.Data.IRepositories;
using JelaLingo.Data.Repositories;
using JelaLingo.Service.Services.Users;
using JelaLingo.Service.Services.Admins;
using JelaLingo.Service.Services.Topics;
using JelaLingo.Service.Services.Courses;
using JelaLingo.Service.Interfaces.Users;
using JelaLingo.Service.Services.Lessons;
using JelaLingo.Service.Interfaces.Topics;
using JelaLingo.Service.Interfaces.Admins;
using JelaLingo.Service.Interfaces.Courses;
using JelaLingo.Service.Interfaces.Lessons;
using JelaLingo.Service.Services.Languages;
using JelaLingo.Service.Interfaces.Languages;
using JelaLingo.Service.Services.UserLanguages;
using JelaLingo.Service.Interfaces.UserLanguages;

namespace JelaLingo.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IUserLanguageService, UserLanguageService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
