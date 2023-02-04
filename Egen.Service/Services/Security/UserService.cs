using Egen.IRepository.Interfaces.Security;
using Egen.IService.Interfaces.Security;
using Egen.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Egen.Dto.Security;
using Egen.Service.Infrastructure;
using Egen.IService.Infrastructure;

namespace Egen.Service.Services.Security
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork) : base(userRepository, unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
