using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsService.Models;
using CommandsService.SyncDataServices.Grpc;

namespace CommandsService.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder applicationBuilder)
    {
        using var serviceScoop = applicationBuilder.ApplicationServices.CreateScope();

        var grpcClient = serviceScoop.ServiceProvider.GetService<IPlatformDataClient>();

        if (grpcClient == null)
            throw new NullReferenceException(nameof(grpcClient));

        var platforms = grpcClient.ReturnAllPlatforms();

        SeedData(serviceScoop.ServiceProvider.GetService<ICommandRepo>(), platforms);

    }

    private static void SeedData(ICommandRepo? commandRepo, IEnumerable<Platform>? platforms)
    {
        if (commandRepo == null)
            throw new ArgumentNullException(nameof(commandRepo));

        if (platforms == null)
            return;

        Console.WriteLine("Seeding new platforms...");

        foreach (var plat in platforms)
        {
            if (commandRepo.ExternalPlatformExists(plat.ExternalId))
            {
                continue;
            }
            commandRepo.CreatePlatform(plat);
            commandRepo.SaveChanges();
        }

    }
}
