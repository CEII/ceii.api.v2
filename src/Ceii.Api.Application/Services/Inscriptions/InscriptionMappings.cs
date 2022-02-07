using AutoMapper;
using Ceii.Api.Application.Services.Inscriptions.ViewModels;
using Ceii.Api.Data.Entities.Inscriptions;

namespace Ceii.Api.Application.Services.Inscriptions;

public class InscriptionMappings : Profile
{
    public InscriptionMappings()
    {
        CreateMap<Inscription, InscriptionVm>();
        CreateMap<InscriptionVm, Inscription>();
    }
}