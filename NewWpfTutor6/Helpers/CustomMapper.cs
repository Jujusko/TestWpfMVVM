using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NewWpfTutor6.DBModel;
using NewWpfTutor6.UIModels;

namespace NewWpfTutor6.Helpers
{
    public class CustomMapper
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
                InitializeInstance();
            return _instance;
        }

        private static void InitializeInstance()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserUI, User>().ReverseMap();
                cfg.CreateMap<TranzactionUI, Tranzaction>().ReverseMap();
            }));
        }
    }
}
