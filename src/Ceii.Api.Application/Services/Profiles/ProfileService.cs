using AutoMapper;
using Ceii.Api.Application.Contracts.Profiles;
using UserProfile = Ceii.Api.Data.Entities.Users.Profile;
using Ceii.Api.Application.Services.Profiles.ViewModels;

namespace Ceii.Api.Application.Services.Profiles;

public class ProfileService
{
    private readonly IProfileRepository _repository;
    private readonly IMapper _mapper;

    public ProfileService(IMapper mapper ,IProfileRepository repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IList<ProfileVm>> GetAll()
    {
        var profiles = await _repository.GetAll();
        return _mapper.Map<IList<UserProfile>, IList<ProfileVm>>(profiles);
    }

    public async Task<ProfileVm> Insert(UserProfile p)
    {
        var profile = await _repository.Insert(p);
        return _mapper.Map<UserProfile, ProfileVm>(profile);
    }
}