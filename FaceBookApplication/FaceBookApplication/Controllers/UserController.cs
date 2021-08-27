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
        [Route("Admin/CreateEndUser")]
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
        [HttpGet]
        [Route("Admin/GetEndUserById")]
        [SwaggerOperation(Description = "Example { }")]
        public async Task<IActionResult> GetEndUserById(long enduserId)
        {
            try
            {
                var dt = await _IRepository.GetEndUserById(enduserId);
                if (dt == null)
                {
                    return NotFound();
                }
                return Ok(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("Admin/EditEditEndUserById")]
        [SwaggerOperation(Description = "Example { ")]
        public async Task<MessageHelper> EditEndUserById(EditEndUserByIdDTO objEdit)
        {
            try
            {
                var msg = await _IRepository.EditEndUserById(objEdit);
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("EndUserLandingPasignation")]
        [SwaggerOperation(Description = "Example { }")]
        public async Task<IActionResult> EndUserLandingPasignation(string search, long PageNo, long PageSize, string viewOrder)
        {
            try
            {
                var dt = await _IRepository.EndUserLandingPasignation(search, PageNo, PageSize, viewOrder);
                if (dt == null)
                {
                    return NotFound();
                }
                return Ok(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
