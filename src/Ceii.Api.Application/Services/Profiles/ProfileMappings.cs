using AutoMapper;
using Ceii.Api.Application.Services.Profiles.ViewModels;
using UserProfile = Ceii.Api.Data.Entities.Users.Profile;

namespace Ceii.Api.Application.Services.Profiles;

public class ProfileMappings : Profile
{
    public ProfileMappings()
    {
        CreateMap<UserProfile, ProfileVm>();
        CreateMap<ProfileVm, UserProfile>();
    }
}