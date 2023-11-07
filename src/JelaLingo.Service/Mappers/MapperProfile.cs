using AutoMapper;
using JelaLingo.Domain.Entities;
using JelaLingo.Service.DTOs.Admins;
using JelaLingo.Service.DTOs.Courses;
using JelaLingo.Service.DTOs.Languages;
using JelaLingo.Service.DTOs.Lessons;
using JelaLingo.Service.DTOs.Topics;
using JelaLingo.Service.DTOs.UserLanguages;
using JelaLingo.Service.DTOs.Users;

namespace JelaLingo.Service.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // User
            CreateMap<User, UserForCreationDto>().ReverseMap();
            CreateMap<User, UserForResultDto>().ReverseMap();
            CreateMap<User, UserForUpdateDto>().ReverseMap();

            //Admin
            CreateMap<Admin, AdminForCreationDto>().ReverseMap();
            CreateMap<Admin, AdminForResultDto>().ReverseMap();
            CreateMap<Admin, AdminForUpdateDto>().ReverseMap();

            //Language
            CreateMap<Language, LanguageForCreationDto>().ReverseMap();
            CreateMap<Language, LanguageForResultDto>().ReverseMap();
            CreateMap<Language, LanguageForUpdateDto>().ReverseMap();

            //Course
            CreateMap<Course, CourseForCreationDto>().ReverseMap();
            CreateMap<Course, CourseForResultDto>().ReverseMap();
            CreateMap<Course, CourseForUpdateDto>().ReverseMap();

            //Topic
            CreateMap<Topic, TopicForCreationDto>().ReverseMap();
            CreateMap<Topic, TopicForResultDto>().ReverseMap();
            CreateMap<Topic, TopicForUpdateDto>().ReverseMap();

            //Lesson
            CreateMap<Lesson, LessonForCreationDto>().ReverseMap();
            CreateMap<Lesson, LessonForResultDto>().ReverseMap();
            CreateMap<Lesson, LessonForUpdateDto>().ReverseMap();

            //UserLanguage
            CreateMap<UserLanguage, UserLanguageForCreationDto>().ReverseMap();
            CreateMap<UserLanguage, UserLanguageForResultDto>().ReverseMap();

        }
    }
}
