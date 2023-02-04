using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egen.Model.Security
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string LoginId { get; set; } = string.Empty;
        public string? Password { get; set; }
        public int? UserTypeId { get; set; }
        public int? RoleId { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
