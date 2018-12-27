using System;
using AddressBookWithPetapoco.DataServices;
using System.Collections.Generic;
using System.Linq;
using Services.Automapper;
using AddressBookWithPetapoco.Models;

namespace Services
{
    public class ContactServices
    {
        public class ContctService : IContactService
        {

            public AddressBookConnectionStringDB context { get; set; }


            public ContctService(AddressBookConnectionStringDB _context)
            {
                this.context = _context;
            }

            #region ContactTable Service(s)

            public void CreateContact(ContactsTable contact)
            {
                context.Insert(contact);
            }

            public void DeleteContact(int Id)
            {
                context.Execute("Delete From ContactsTable Where Id = @0", Id);
            }

            public void UpdateContact(ContactsTable contact)
            {
                context.Update(contact);
            }

            public Contact ContactDetails(int Id)
            {

                var sql = PetaPoco.Sql.Builder.Select("*").From("ContactsTable").Where("Id=@0", Id);

                return AutoMapperProfile.mapper.Map<ContactsTable, Contact>(context.Fetch<ContactsTable>(sql).FirstOrDefault());
            }

            public List<Contact> GetContacts()
            {
                var sql = PetaPoco.Sql.Builder.Select("*").From("ContactsTable");
                return AutoMapperProfile.mapper.Map<List<ContactsTable>, List<Contact>>(context.Fetch<ContactsTable>(sql));

            }

            /*using (var context = DataContextHelper.GetDataContext())
                {
                    var sql = PetaPoco.Sql.Builder.Select("*").From("ContactsTable");
                    var listOfContacts = context.Fetch<ContactsTable>(sql).ToList();
                    List<Contact> mappedContacts = new List<Contact>();
                    // Use AutoMapper here to map database object to our model
                    foreach (var item in listOfContacts)
                    {
                        mappedContacts.Add(new Contact { Address = item.Address,Email = item.Email});
                    }

                    return mappedContacts;
                }*/
            #endregion

        }

        public interface IContactService
        {
            List<Contact> GetContacts();
            void UpdateContact(ContactsTable contact);
            Contact ContactDetails(int Id);
            void CreateContact(ContactsTable contact);
            void DeleteContact(int Id);
        }
    }
}
