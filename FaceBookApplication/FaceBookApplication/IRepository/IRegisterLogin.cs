using FaceBookApplication.DTO.EndUserDTO;
using FaceBookApplication.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookApplication.IRepository
{
    public interface IRegisterLogin
    {
        public Task<MessageHelper> RegisterEndUser(CreateEndUserDTO objCreate);
        public Task<MessageHelper> LoginEndUser(LoginEndUserDTO objLogin);

    }
}
