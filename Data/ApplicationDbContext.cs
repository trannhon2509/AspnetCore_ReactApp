using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using AspnetCore_ReactApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace AspnetCore_ReactApp.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (entityType.GetTableName().StartsWith("AspNet"))
            {
                entityType.SetTableName(entityType.GetTableName().Substring(6));
            }
        }
       

    }
}
