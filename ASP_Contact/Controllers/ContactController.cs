using ASP_Contact.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ASP_Contact.Controllers
{
    public class ContactController : Controller
    {
        public static Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>();
        public IActionResult Index()
        {
            return View(_contacts);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                int id = _contacts.Keys.Count != 0 ? _contacts.Keys.Max() : 0;
                contact.id = id + 1;
                _contacts.Add(contact.id, contact);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            if (_contacts.Keys.Contains(id))
            {
                return View(_contacts[id]);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(Contact contact) 
        {
            if (ModelState.IsValid) 
            {
                _contacts[contact.id] = contact;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Details(int id) 
        { 
            if(_contacts.Keys.Contains(id))
            {
                return View(_contacts[id]);
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult Delete(int id)
        {
            if(_contacts.Keys.Contains(id))
            {
                _contacts.Remove(id);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
