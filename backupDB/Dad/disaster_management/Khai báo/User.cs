using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class User
    {
        public User()
        {
            UserLogs = new HashSet<UserLog>();
            Groups = new HashSet<UserGroup>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<UserLog> UserLogs { get; set; }

        public virtual ICollection<UserGroup> Groups { get; set; }

        public User Clone()
        {
            return (User)this.MemberwiseClone();

        }
    }
}
