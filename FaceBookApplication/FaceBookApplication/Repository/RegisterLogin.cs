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
    public class RegisterLogin : IRegisterLogin
    {
        public readonly ReadDbContext _contextR;
        public readonly WriteDbContext _contextW;
        public RegisterLogin(ReadDbContext contextR, WriteDbContext contextW)
        {
            _contextR = contextR;
            _contextW = contextW;
        }

        public async Task<MessageHelper> LoginEndUser(LoginEndUserDTO objLogin)
        {
            var endUserCheck = (from a in _contextR.TblEndUser 
                                where a.StrEndUserName.Trim().ToLower() == objLogin.EndUserName.Trim().ToLower()
                                && a.StrEndUserPassword == objLogin.EndUserPassword
                                && a.StrEndUserRoleName ==objLogin.EndUserRoleName 
                                && a.IsActive == true select a).FirstOrDefault();

            if (endUserCheck == null)
            {
                throw new Exception("Please Registertion");
            }

            var msg = new MessageHelper();
            msg.Message = "Login Successful";
            msg.statuscode = 200;

            return msg;

        }

        public async Task<MessageHelper> RegisterEndUser(CreateEndUserDTO objCreate)
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
            msg.Message = "Registration Successful";
            msg.statuscode = 200;

            return msg;
        }
    }
}
