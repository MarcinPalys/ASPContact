
namespace ASP_Contact.Models
{
    public class ContactMapper
    {
        public static ContactEntity ToEntity(Contact contact)
        {
            return new ContactEntity()
            {
                id = contact.id,
                name = contact.name,
                dateOfBirth = contact.dateOfBirth,
                phone = contact.phone,
                email = contact.email,
                surname = contact.surname,
                Priority = contact.Priority              
            };
        }
        public static Contact FromEntity(ContactEntity entity) 
        {
            return new Contact()
            {
                id = entity.id,
                name = entity.name,
                dateOfBirth = entity.dateOfBirth,
                phone = entity.phone,
                email = entity.email,
                surname = entity.surname,
                Priority = entity.Priority
            };
        }
    }
}
