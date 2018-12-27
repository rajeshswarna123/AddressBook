using ContactService.DataServices;
using ContactService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactService
{
    public interface IContactService
    {
        List<Models.Contact> GetContacts();
        Models.Contact UpdateContact(DataServices.Contact contact);
        Models.Contact GetContact(int Id);
        Models.Contact CreateContact(DataServices.Contact contact);
        int DeleteContact(int Id);
    }
}
