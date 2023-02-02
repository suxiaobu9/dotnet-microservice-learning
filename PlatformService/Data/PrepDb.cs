using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateAsyncScope();

        SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());

    }

    private static void SeedData(AppDbContext? context)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));

        Console.WriteLine("--> Attempting to apply migrations...");
        try
        {
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not run migrations: {ex.Message}");
        }

        if (context.Platforms.Any())
        {
            Console.WriteLine("--> We already have data");
            return;
        }

        Console.WriteLine("--> Seeding Data...");

        context.Platforms.AddRange(
            new Platform { Name = ".Net", Publisher = "Microsoft", Cost = "Free" },
            new Platform { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
            new Platform { Name = "Kubernetes", Publisher = "Cloud Native Computing ", Cost = "Free" }
            );

        context.SaveChanges();
    }
}
