using AutoMapper;
using Ceii.Api.Application.Services.Developers.ViewModels;
using Ceii.Api.Data.Entities.Developer;

namespace Ceii.Api.Application.Services.Developers;

public class DeveloperMappings : Profile
{
    public DeveloperMappings()
    {
        CreateMap<Developer, DeveloperVm>();
        CreateMap<DeveloperVm, Developer>();
    }
}