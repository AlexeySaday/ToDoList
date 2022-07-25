using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore; 
using WorkSourcer.AuthPer;
using WorkSourcer.Models;

namespace WorkSourcer.DataContext
{
    public class ApplicationDbContext:IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions option) : base(option) { }
        public DbSet<ToDo> toDo { get; set; }
    }
}
