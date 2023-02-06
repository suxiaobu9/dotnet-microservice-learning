using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsService.Models;

namespace CommandsService.Data;

public class CommandRepo : ICommandRepo
{
    private readonly AppDbContext _context;

    public CommandRepo(AppDbContext context)
    {
        _context = context;
    }

    public void CreateCommand(int platformId, Command? command)
    {

        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        command.PlatformId = platformId;
        _context.Command.Add(command);
    }

    public void CreatePlatform(Platform? plat)
    {
        if (plat == null)
        {
            throw new ArgumentNullException(nameof(plat));
        }

        _context.Platforms.Add(plat);
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        return _context.Platforms.ToArray();
    }

    public Command? GetCommand(int platformId, int commandId)
    {
        return _context.Command.FirstOrDefault(x => x.PlatformId == platformId && x.Id == commandId);
    }

    public IEnumerable<Command> GetCommandsForPlatform(int platformId)
    {
        return _context.Command
            .Where(x => x.PlatformId == platformId)
            .OrderBy(x => x.Platform.Name)
            .ToArray();
    }

    public bool PlatformExits(int platformId)
    {
        return _context.Platforms.Any(x => x.Id == platformId);
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }
}
