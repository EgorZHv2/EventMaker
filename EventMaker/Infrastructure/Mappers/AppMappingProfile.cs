using AutoMapper;
using EventMaker.Data.Entities;
using EventMaker.Models.ViewModels;
using EventMaker.Models.ViewModels.OrganizerProfileView;

namespace EventMaker.Infrastructure.Mappers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<CreateEventViewModel, Event>().ReverseMap();
               
            CreateMap<Event, EventViewModel>().ReverseMap();
            CreateMap<Event, DetailedEventViewModel>().ReverseMap();

            CreateMap<CreateDirectionViewModel, Direction>().ReverseMap();
            CreateMap<DirectionViewModel, Direction>().ReverseMap();

            CreateMap<Country, CountryViewModel>().ReverseMap();
            CreateMap<CreateCountryViewModel, Country>().ReverseMap();

            CreateMap<Activity, ActivityViewModel>().ReverseMap();
            CreateMap<CreateActivityViewModel, Activity>().ReverseMap();

            CreateMap<User, OrganizerProfileViewModel>().ReverseMap();
            CreateMap<User, JuriViewModel>().ReverseMap();
            CreateMap<User, MemberViewModel>().ReverseMap();

            CreateMap<City, CityViewModel>().ReverseMap();
            CreateMap<CreateCityViewModel, City>().ReverseMap();

            

          


        }
    }
}
