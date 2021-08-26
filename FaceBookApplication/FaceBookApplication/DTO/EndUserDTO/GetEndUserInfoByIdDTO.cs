using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookApplication.DTO.EndUserDTO
{
    public class GetEndUserInfoByIdDTO
    {
        public string EndUserName { get; set; }
        public string EndUserPhoneNo { get; set; }
        public string EndUserGender { get; set; }
        public string EndUserRoleName { get; set; }
    }
}
