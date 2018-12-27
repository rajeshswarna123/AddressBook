using AutoMapper;
using ContactService.DataServices;
using ContactService.Models;


namespace Services.Automapper
{
    public static class AutoMapperProfile 
    {
           static MapperConfiguration config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContactService.DataServices.Contact, ContactService.Models.Contact>();
            });
            
        public static IMapper mapper = config.CreateMapper();
    }
}