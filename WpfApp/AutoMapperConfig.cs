using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using WpfApp.ViewModel;
namespace WpfApp
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Person, PersonViewModel>();
            Mapper.CreateMap<Group, GroupViewModel>();
            Mapper.CreateMap<State, StateViewModel>();
            Mapper.CreateMap<Group_Person, Group_PersonViewModel>();
            Mapper.CreateMap<Group,GroupViewModel>();

            Mapper.CreateMap<Expedition, ExpeditionViewModel>();
            Mapper.CreateMap<Day, DayViewModel>()
                .ForMember("Date", opt => opt.MapFrom(c => c.Date.ToShortDateString()));
            Mapper.CreateMap<Interval, IntervalViewModel>()
                .ForMember("TimeBegin", opt => opt.MapFrom(c => c.TimeBegin.ToShortTimeString()))
                .ForMember("TimeEnd", opt => opt.MapFrom(c => c.TimeEnd.ToShortTimeString()));

            Mapper.CreateMap<Meteor, MeteorViewModel>()
                .ForMember("Time", opt => opt.MapFrom(c => c.Time.ToLongTimeString()));
            Mapper.CreateMap<Magnitude, MagnitudeViewModel>();



            Mapper.CreateMap<ExpeditionViewModel, Expedition>();
            Mapper.CreateMap<IntervalViewModel, Interval>()
                .ForMember("TimeBegin", opt => opt.MapFrom(c => Convert.ToDateTime(c.TimeBegin)))
                .ForMember("TimeEnd", opt => opt.MapFrom(c => Convert.ToDateTime(c.TimeBegin)));
        }
    }
}
