using FaceBookApplication.DTO.EndUserDTO;
using FaceBookApplication.Helper;
using FaceBookApplication.IRepository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterLoginController : Controller
    {
        private readonly IRegisterLogin _IRepository;
        public RegisterLoginController(IRegisterLogin IRepository)
        {
            _IRepository = IRepository;
        }
        
        [HttpPost]
        [Route("RegisterEndUser")]
        [SwaggerOperation(Description = "Example { }")]
        public async Task<MessageHelper> RegisterEndUser(CreateEndUserDTO objCreate)
        {
            try
            {
                var msg = await _IRepository.RegisterEndUser(objCreate);
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("LoginEndUser")]
        [SwaggerOperation(Description = "Example { }")]
        public async Task<MessageHelper> LoginEndUser(LoginEndUserDTO objLogin)
        {
            try
            {
                var msg = await _IRepository.LoginEndUser(objLogin);
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
