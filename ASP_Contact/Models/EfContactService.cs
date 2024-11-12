
namespace ASP_Contact.Models
{
    public class EfContactService : IContactService
    {
        private readonly AppDbContext _context;
        public EfContactService(AppDbContext context)
        {
            _context = context;
        }
        public int Add(Contact contact)
        {
            var e = _context.Contacts.Add(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
            return e.Entity.id;
        }

        public void Delete(int id)
        {
            ContactEntity? find = _context.Contacts.Find(id);
            if (find != null)
            {
                _context.Contacts.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Contact> FindAll()
        {
            return _context.Contacts.Select(e => ContactMapper.FromEntity(e)).ToList();
        }

        public Contact? FindById(int id)
        {
            return ContactMapper.FromEntity(_context.Contacts.Find(id));
        }

        public List<OrganizationEntity> GetOrganizations()
        {
            return _context.Organizations.ToList();
        }

        public void Update(Contact contact)
        {
            _context.Contacts.Update(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
        }
    }
}
