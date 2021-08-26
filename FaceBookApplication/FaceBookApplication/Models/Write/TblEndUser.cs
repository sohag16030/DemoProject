using System;
using System.Collections.Generic;

#nullable disable

namespace FaceBookApplication.Models.Write
{
    public partial class TblEndUser
    {
        public long EndUserId { get; set; }
        public string EndUserName { get; set; }
        public string EndUserPassword { get; set; }
        public string EndUserConfirmPassword { get; set; }
        public long EndUserRoleId { get; set; }
        public string EndUserRoleName { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastActionDateTime { get; set; }
    }
}
