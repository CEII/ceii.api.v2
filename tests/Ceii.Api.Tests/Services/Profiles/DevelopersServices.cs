using AutoMapper;
using Ceii.Api.Application.Repositories;

namespace Ceii.Api.Application.Services.Developers;

public class DevelopersServices
{
    private readonly DeveloperRespository _respository;

    private readonly IMapper _mapper;

    public DevelopersServices(IMapper mapper, DeveloperRespository repository)
    {
        _mapper = mapper;
        _respository = repository;
    }
} 