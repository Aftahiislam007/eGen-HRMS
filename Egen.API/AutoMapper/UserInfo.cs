using AutoMapper;
using Egen.Dto.Security.User;
using Egen.Model.Security;

namespace Egen.API.AutoMapper
{
    public class UserInfo : Profile
    {
        public UserInfo()
        {
            CreateMap<UserDTO, User>();
            CreateMap<UserCreateDTO, User>();
        }
    }
}
