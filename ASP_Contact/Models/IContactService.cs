using System.Net;

namespace ASP_Contact.Models
{
    public interface IContactService
    {
        int Add(Contact book);
        void Delete(int id);
        void Update(Contact book);
        List<Contact> FindAll();
        Contact? FindById(int id);
        List<OrganizationEntity> GetOrganizations();
    }
}
