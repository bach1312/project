using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            Groups = new HashSet<UserGroup>();
        }

        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<UserGroup> Groups { get; set; }
    }
}
