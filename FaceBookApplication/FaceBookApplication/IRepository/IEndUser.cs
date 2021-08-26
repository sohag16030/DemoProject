using FaceBookApplication.DTO.EndUserDTO;
using FaceBookApplication.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookApplication.IRepository
{
    public interface IEndUser
    {
        public Task<MessageHelper> CreateEndUser(CreateEndUserDTO objCreate);
    }
}
