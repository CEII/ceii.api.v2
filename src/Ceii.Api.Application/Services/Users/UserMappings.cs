using Ceii.Api.Application.Services.Users.ViewModels;
using Ceii.Api.Data.Entities.Users;
using Profile = AutoMapper.Profile;

namespace Ceii.Api.Application.Services.Users;

public class UserMappings : Profile
{
    public UserMappings()
    {
        CreateMap<User, UserVm>()
            .ForMember(vm => vm.Role,
                ent => ent.MapFrom(usr => usr.Role!.Name)
            );
        
        CreateMap<UserVm, User>()
            .ForMember(ent => ent.Role,
                vm => 
                    vm.MapFrom(usr => new Role { Name = usr.Name})
            );
    }
}