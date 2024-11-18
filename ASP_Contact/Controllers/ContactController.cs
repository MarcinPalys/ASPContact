using ASP_Contact.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace ASP_Contact.Controllers
{
    public class ContactController : Controller
    {
        public static Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>();
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }
        [HttpGet]
        public IActionResult Create()
        {            
            Contact model = new Contact();
            model.Organizations = _contactService
                .GetOrganizations()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name })
                .ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
               _contactService.Add(contact);

                return RedirectToAction("Index");
            }
            else
            {
                return View(contact);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var contact = _contactService.FindById(id);
            if (contact == null)
            {
                return NotFound();
            }

            contact.Organizations = _contactService
                .GetOrganizations()
                .Select(o => new SelectListItem { Value = o.Id.ToString(), Text = o.Name })
                .ToList();

            return View(contact);
        }
        [HttpPost]
        public IActionResult Edit(Contact contact) 
        {
            if (ModelState.IsValid) 
            {
                _contactService.Update(contact);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Details(int id) 
        { 
            if(id ==  _contactService.FindById(id).id)
            {
                return View(_contactService.FindById(id));
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult Delete(int id)
        {
            if(id == _contactService.FindById(id).id)
            {
                _contactService.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
