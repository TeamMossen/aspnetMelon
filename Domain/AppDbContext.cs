global using Domain.Models;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.AspNetCore.Identity;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Domain;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}