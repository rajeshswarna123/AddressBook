using Autofac;
using Autofac.Core;
using ContactService;
using ContactService.DataServices;
using static ContactService.ContactServices;

namespace AddressBookWithPetapoco
{
    public class AutoFacModule : Module
    {
        private string __ConnectionString;

        public AutoFacModule(string ConnectionString)
        {
            __ConnectionString = ConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContctService>().As<IContactService>();
            builder.Register(c => new AddressBookDB(__ConnectionString));
            base.Load(builder);
        }
    }
}