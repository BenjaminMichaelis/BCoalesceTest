using BCoalesceTest.Data.Coalesce;
using BCoalesceTest.Data.Models;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Cryptography;

namespace BCoalesceTest.Data;

[Coalesce]
public class AppDbContext
	: DbContext
	, IDataProtectionKeyContext
{
	public bool SuppressAudit { get; set; } = false;
	
	public AppDbContext() { }

	public AppDbContext(DbContextOptions options) : base(options) { }



	public DbSet<Widget> Widgets { get; set; }

	[InternalUse]
	public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		// Remove cascading deletes.
		foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
		{
			relationship.DeleteBehavior = DeleteBehavior.Restrict;
		}

	}
}
