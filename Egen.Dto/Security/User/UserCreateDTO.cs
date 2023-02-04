using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egen.Dto.Security.User
{
    [Serializable]
    public class UserCreateDTO
    {
        public string? Password { get; set; }
        public int? UserTypeId { get; set; }
        public int? RoleId { get; set; }
        public int? Status { get; set; }
    }
}
