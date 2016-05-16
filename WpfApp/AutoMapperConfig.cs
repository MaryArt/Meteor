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
            

            Mapper.CreateMap<Expedition, ExpeditionViewModel>();
            Mapper.CreateMap<Day, DayViewModel>()
                .ForMember("Date", opt => opt.MapFrom(c => c.Date.ToShortDateString()));

            Mapper.CreateMap<Meteor, MeteorViewModel>()
                .ForMember("Time", opt => opt.MapFrom(c => c.Time.ToLongTimeString()));
        }
    }
}
