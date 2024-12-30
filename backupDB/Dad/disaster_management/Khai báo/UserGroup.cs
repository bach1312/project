using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class UserGroup
    {
        public UserGroup()
        {
            Roles = new HashSet<UserRole>();
            Users = new HashSet<User>();
        }

        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
