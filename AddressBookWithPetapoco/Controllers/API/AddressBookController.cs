using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactService;
using AddressBookWithPetapoco;
using ContactService.Models;
using Extensions;

namespace AddressBook.AddressBookAPI
{
    public class AddressBookController : ApiController
    {
        private IContactService ContactService;

        public AddressBookController(IContactService contactService)
        {
            this.ContactService = contactService;
        }

        public IEnumerable<Contact> GetContacts()
        {
            var Contacts = this.ContactService.GetContacts();
            return Contacts;
        }
        [HttpGet]
        public Contact GetContact([FromUri]int id)
        {
            var contact = this.ContactService.GetContact(id); ;
            return contact;
        }

        [HttpPost]
        public Contact Create(Contact Contact)
        {
            ContactService.DataServices.Contact contact = Contact.MapFrom<Contact, ContactService.DataServices.Contact>();
            return this.ContactService.CreateContact(contact);
        }

        [HttpDelete]
        public int Delete([FromUri]int id)
        {
            return this.ContactService.DeleteContact(id);
        }

        [HttpPut]
        public Contact Update(Contact Contact)
        {
            ContactService.DataServices.Contact contact = Contact.MapFrom<Contact, ContactService.DataServices.Contact>();
            return this.ContactService.UpdateContact(contact);
        }
    }
}