using ContactService;
using ContactService.DataServices;
using System.Web.Mvc;
using static ContactService.ContactServices;
using Extensions;
using ContactService.Models;
using PagedList;


namespace AddressBook.Controllers
{
    public class AddressBookController : Controller
    {

        // GET: AddressBook
        public ActionResult Index()
        {
            return View();
        }

    }
}