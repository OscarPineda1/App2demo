using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App2demo.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<App2demo.Models.Cliente> DataCliente { get; set; }
    public DbSet<App2demo.Models.Contacto> DataContacto { get; set; }
}
