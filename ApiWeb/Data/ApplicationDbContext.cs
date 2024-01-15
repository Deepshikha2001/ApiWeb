using ApiWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)

        {
        }
        public DbSet<EmployeeContact> EmployeeContacts { get; set; }
    }
}