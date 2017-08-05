using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Platform.DataAccess.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string Zipcode { get; set; }
        public string Country {get;set;}
        public string CreditCardIdentifier { get;set;}
    }
}
