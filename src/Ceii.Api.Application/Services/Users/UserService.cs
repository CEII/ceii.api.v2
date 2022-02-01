using AutoMapper;
using Ceii.Api.Application.Contracts.Users;
using Ceii.Api.Application.Services.Users.ViewModels;
using Ceii.Api.Data.Entities.Users;

namespace Ceii.Api.Application.Services.Users;

public class UserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IList<UserVm>> GetAll()
    {   
        var users = await _repository.GetAll();

        return _mapper.Map<IList<User>, IList<UserVm>>(users);
    }

    public async Task<UserVm> GetById(string id)
    {
        var user = await _repository.GetById(id);

        return _mapper.Map<User, UserVm>(user);
    }
}