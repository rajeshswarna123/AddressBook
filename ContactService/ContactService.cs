using ContactService.DataServices;
using ContactService.Models;
using Services.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions;

namespace ContactService
{
     public class ContactServices
    {
        public class ContctService : IContactService
        {

            public AddressBookDB context { get; set; }
            
            public ContctService(AddressBookDB _context)
            {
                this.context = _context;
            }

            #region Contact Service(s)

            public Models.Contact CreateContact(DataServices.Contact contact)
            {
                context.Insert(contact);
                return contact.MapTo<DataServices.Contact, Models.Contact>();
            }

            public int DeleteContact(int Id)
            {
                context.Execute("Delete From Contact Where Id = @0", Id);
                return Id;
            }

            public Models.Contact UpdateContact(DataServices.Contact contact)
            {
                context.Update(contact);
                return contact.MapTo<DataServices.Contact, Models.Contact>();
            }

            public Models.Contact GetContact(int Id)
            {
                var sql = PetaPoco.Sql.Builder.Select("*").From("Contact").Where("Id=@0", Id);
                return (context.FirstOrDefault<DataServices.Contact>(sql)).MapTo<DataServices.Contact, Models.Contact>();
            }

            public List<Models.Contact> GetContacts()
            {
                var sql = PetaPoco.Sql.Builder.Select("*").From("Contact");
                return (context.Fetch<DataServices.Contact>(sql)).MapToCollection<DataServices.Contact,Models.Contact>();
            }

            #endregion

        }
    }
}
