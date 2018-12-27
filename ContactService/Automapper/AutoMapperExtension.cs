using ContactService.DataServices;
using Services.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Extensions
{
    public static class AutoMapperExtension
    {
        public static List<TDest> MapToCollection<TSource, TDest>(this List<TSource> Contacts)
        {
            return AutoMapperProfile.mapper.Map<List<TSource>, List<TDest>>(Contacts);
        }

        public static TDest MapTo<TSource, TDest>(this TSource Contact)
        {
            return AutoMapperProfile.mapper.Map<TSource,TDest>(Contact);
        }

        public static TDest MapFrom<TSource, TDest>(this TSource Contact)
        {
            return AutoMapperProfile.mapper.Map<TSource, TDest>(Contact);
        }
    }
}
