using FaceBookApplication.DbContexts;
using FaceBookApplication.DTO.EndUserDTO;
using FaceBookApplication.Helper;
using FaceBookApplication.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookApplication.Repository
{
    public class EndUser : IEndUser
    {
        public readonly ReadDbContext _contextR;
        public readonly WriteDbContext _contextW;
        public EndUser(ReadDbContext contextR, WriteDbContext contextW)
        {
            _contextR = contextR;
            _contextW = contextW;
        }
        public async Task<MessageHelper> CreateEndUser(CreateEndUserDTO objCreate)
        {

            var duplicateEndUserNameCheck = (from a in _contextR.TblEndUser where a.StrEndUserName.Trim().ToLower() == objCreate.EndUserName.Trim().ToLower() select a.StrEndUserName).FirstOrDefault();

            if (duplicateEndUserNameCheck != null)
            {
                throw new Exception("UserName Already Exist");
            }

            var userObj = new Models.Write.TblEndUser
            {
                StrEndUserName = objCreate.EndUserName,
                StrEndUserGender = objCreate.EndUserGender,
                StrEndUserPhoneNo = objCreate.EndUserPhoneNo,
                StrEndUserPassword = objCreate.EndUserPassword,
                StrEndUserConfirmPassword = objCreate.EndUserConfirmPassword,
                IntEndUserRoleId = objCreate.EndUserRoleId,
                StrEndUserRoleName = objCreate.EndUserRoleName,
                IsActive = true
            };

            await _contextW.TblEndUser.AddAsync(userObj);
            await _contextW.SaveChangesAsync();

            var msg = new MessageHelper();
            msg.Message = "EndUser Created Successfully";
            msg.statuscode = 200;

            return msg;

        }
    }
}
