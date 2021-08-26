using System;
using System.Collections.Generic;

#nullable disable

namespace FaceBookApplication.Models.Read
{
    public partial class TblEndUserType
    {
        public TblEndUserType()
        {
            TblEndUser = new HashSet<TblEndUser>();
        }

        public long IntEndUserRoleId { get; set; }
        public string StrEndUserRoleName { get; set; }

        public virtual ICollection<TblEndUser> TblEndUser { get; set; }
    }
}
