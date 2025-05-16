using Microsoft.AspNetCore.Identity;
using ChatApplication.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ChatApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
    }
}
