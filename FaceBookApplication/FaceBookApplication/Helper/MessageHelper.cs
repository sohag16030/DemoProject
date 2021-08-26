using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FaceBookApplication.Helper
{
    public class MessageHelper
    {
        [DataMember]
        public string Message { get; set; }
        public int statuscode { get; set; }
        public TimeSpan Minutes { get; set; }
    }
}
