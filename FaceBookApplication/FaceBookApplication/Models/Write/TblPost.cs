using System;
using System.Collections.Generic;

#nullable disable

namespace FaceBookApplication.Models.Write
{
    public partial class TblPost
    {
        public long PostId { get; set; }
        public string PostDescription { get; set; }
        public DateTime PostDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastActionDateTime { get; set; }
    }
}
