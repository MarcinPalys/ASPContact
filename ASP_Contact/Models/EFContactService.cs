
using ASP_Contact.Models.EF;

namespace ASP_Contact.Models
{
    public class EFContactService : IContactService
    {
        private AppDbContext _context;
        public EFContactService(AppDbContext context)
        {
            _context = context;
        }
        public int Add(Contact book)
        {
            _context.Contacts.Add(book);

        public void Delete(int id)
        {
                _context.Contacts.Remove(book);
        }

        public List<Contact> FindAll()
        {
                _context.Contacts.ToList();
        }

        public Contact? FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Contact book)
        {
            _context.Contacts.Update(book);
        }
    }
}
