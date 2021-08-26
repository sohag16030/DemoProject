using System;
using System.Collections.Generic;

#nullable disable

namespace FaceBookApplication.Models.Read
{
    public partial class TblEndUser
    {
        public TblEndUser()
        {
            TblPost = new HashSet<TblPost>();
        }

        public long IntEndUserId { get; set; }
        public string StrEndUserName { get; set; }
        public string StrEndUserPassword { get; set; }
        public string StrEndUserConfirmPassword { get; set; }
        public long IntEndUserRoleId { get; set; }
        public string StrEndUserRoleName { get; set; }
        public bool IsActive { get; set; }
        public DateTime DteLastActionDateTime { get; set; }

        public virtual TblEndUserType IntEndUserRole { get; set; }
        public virtual ICollection<TblPost> TblPost { get; set; }
    }
}
