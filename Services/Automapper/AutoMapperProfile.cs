using AddressBookWithPetapoco.Models;
using AddressBookWithPetapoco.DataServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Automapper
{
    public static class AutoMapperProfile 
    {
           static MapperConfiguration config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContactsTable, Contact>();
            });
            
        public static IMapper mapper = config.CreateMapper();
    }
}