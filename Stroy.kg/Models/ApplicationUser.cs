using Microsoft.AspNetCore.Identity;

namespace Stroy.kg.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
