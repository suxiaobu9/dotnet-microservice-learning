using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandsService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Platform> Platforms { get; set; } = null!;
    public DbSet<Command> Command { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Platform>()
            .HasMany(x => x.Commands)
            .WithOne(x => x.Platform!)
            .HasForeignKey(x => x.PlatformId);

        modelBuilder
            .Entity<Command>()
            .HasOne(x => x.Platform)
            .WithMany(x => x.Commands)
            .HasForeignKey(x => x.PlatformId);

    }
}
