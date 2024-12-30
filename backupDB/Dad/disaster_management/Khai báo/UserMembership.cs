using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.Models
{
    public class UserMembership
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }

        public UserMembership Clone()
        {
            return (UserMembership)MemberwiseClone();
        }
    }
}
