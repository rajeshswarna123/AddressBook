using AddressBookWithPetapoco.DataServices;
using AddressBookWithPetapoco.Models;
using Autofac;
using Autofac.Core;
using static Services.ContactServices;

namespace AddressBookWithPetapoco
{
    //The class inherits from Module and overrides the load method.
    //The Load method takes an instance of ContainerBuilder.
    public class DataModule: Module
    {
        private string __ConnectionString;
        public DataModule(string ConnectionString)
        {
            __ConnectionString = ConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContctService>().As<IContactService>();
            builder.Register(c => new AddressBookConnectionStringDB(__ConnectionString));
            base.Load(builder);
        }
    }
}