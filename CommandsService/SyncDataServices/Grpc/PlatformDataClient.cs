using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandsService.Models;
using Grpc.Net.Client;
using PlatformService;

namespace CommandsService.SyncDataServices.Grpc;

public class PlatformDataClient : IPlatformDataClient
{
    public IConfiguration _configuration { get; }
    private readonly IMapper _mapper;

    public PlatformDataClient(IConfiguration configuration, IMapper mapper)
    {
        _configuration = configuration;
        _mapper = mapper;
    }

    public IEnumerable<Platform>? ReturnAllPlatforms()
    {
        var grpcAddress = _configuration["GrpcPlatform"];

        Console.WriteLine($"--> Calling Grpc Service {grpcAddress}");

        if (grpcAddress == null)
            throw new ArgumentNullException($"{nameof(grpcAddress)}");

        var channel = GrpcChannel.ForAddress(grpcAddress);

        var client = new GrpcPlatform.GrpcPlatformClient(channel);

        var request = new GetAllRequest();

        if (request == null)
            throw new ArgumentNullException(nameof(request));

        try
        {
            var reply = client.GetAllPlatforms(request);
            return _mapper.Map<IEnumerable<Platform>>(reply.Platform) ?? null;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"--> Coult not call Grpc server {ex.Message}");
            return null;
        }


    }
}
