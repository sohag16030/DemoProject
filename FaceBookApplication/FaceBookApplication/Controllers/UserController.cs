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
    public class UserController : Controller
    {
        private readonly IEndUser _IRepository;
        public UserController(IEndUser IRepository)
        {
            _IRepository = IRepository;
        }
        [HttpPost]
        [Route("CreateEndUser")]
        [SwaggerOperation(Description = "Example { }")]
        public async Task<MessageHelper> CreateEndUser(CreateEndUserDTO objCreate)
        {
            try
            {
                var msg = await _IRepository.CreateEndUser(objCreate);
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
