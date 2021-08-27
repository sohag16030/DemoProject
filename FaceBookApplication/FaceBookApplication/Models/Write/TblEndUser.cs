using System;
using System.Collections.Generic;

#nullable disable

namespace FaceBookApplication.Models.Write
{
    public partial class TblEndUser
    {
        public TblEndUser()
        {
            TblPost = new HashSet<TblPost>();
        }

        public long IntEndUserId { get; set; }
        public string StrEndUserName { get; set; }
        public string StrEndUserPhoneNo { get; set; }
        public string StrEndUserGender { get; set; }
        public string StrEndUserPassword { get; set; }
        public string StrEndUserConfirmPassword { get; set; }
        public string StrEndUserRoleName { get; set; }
        public bool IsActive { get; set; }
        public DateTime DteLastActionDateTime { get; set; }

        public virtual ICollection<TblPost> TblPost { get; set; }
    }
}
