using System;
using System.Collections.Generic;

#nullable disable

namespace FaceBookApplication.Models.Write
{
    public partial class TblPost
    {
        public long IntPostId { get; set; }
        public long IntEndUserId { get; set; }
        public string StrPostDescription { get; set; }
        public DateTime DtePostDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime DteLastActionDateTime { get; set; }

        public virtual TblEndUser IntEndUser { get; set; }
    }
}
