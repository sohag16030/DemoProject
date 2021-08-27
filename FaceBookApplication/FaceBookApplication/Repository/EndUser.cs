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

            var duplicateEndUserNameCheck = (from a in _contextR.TblEndUser
                                             where a.StrEndUserName.Trim().ToLower() == objCreate.EndUserName.Trim().ToLower()
                                             && a.StrEndUserPhoneNo.Trim().ToLower() == objCreate.EndUserPhoneNo.Trim().ToLower()
                                             select a.StrEndUserName).FirstOrDefault();

            if (duplicateEndUserNameCheck != null)
            {
                throw new Exception("User Already Exist");
            }

            var userObj = new Models.Write.TblEndUser
            {
                StrEndUserName = objCreate.EndUserName,
                StrEndUserGender = objCreate.EndUserGender,
                StrEndUserPhoneNo = objCreate.EndUserPhoneNo,
                StrEndUserPassword = objCreate.EndUserPassword,
                StrEndUserConfirmPassword = objCreate.EndUserConfirmPassword,
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

        public async Task<GetEndUserByIdDTO> GetEndUserById(long enduserId)
        {
            var data = ((from a in _contextR.TblEndUser
                         where a.IntEndUserId == enduserId && a.IsActive == true
                         select new GetEndUserByIdDTO
                         {
                             EndUserName = a.StrEndUserName,
                             EndUserPhoneNo = a.StrEndUserPhoneNo,
                             EndUserGender = a.StrEndUserGender,
                             EndUserRoleName = a.StrEndUserRoleName

                         }).FirstOrDefault());
            if (data == null)
                throw new Exception("User not found");
            return data;
        }
        public async Task<MessageHelper> EditEndUserById(EditEndUserByIdDTO objEdit)
        {
            var data = _contextW.TblEndUser.Where(x => x.IntEndUserId == objEdit.EndUserId && x.IsActive == true).FirstOrDefault();

            if (data == null)
                throw new Exception("EndUser Info Edit Data Not Found");

            data.StrEndUserName = objEdit.EndUserName;
            data.StrEndUserPhoneNo = objEdit.EndUserPhoneNo;
            data.StrEndUserGender = objEdit.EndUserGender;

            _contextW.TblEndUser.Update(data);
            await _contextW.SaveChangesAsync();

            var msg = new MessageHelper();
            msg.Message = "Updated Successfully";
            msg.statuscode = 200;
            return msg;
        }
        public async Task<EndUserLandingPagination> EndUserLandingPasignation(string search, long PageNo, long PageSize, string viewOrder)
        {

            IQueryable<GetEndUserLandingDTO> data = await Task.FromResult(from a in _contextR.TblEndUser
                                                                          where a.IsActive == true
                                                                          && (search == null
                                                                          || a.StrEndUserName.ToLower().Contains(search.ToLower()) || a.StrEndUserPhoneNo.ToLower().Contains(search.ToLower()))
                                                                          select new GetEndUserLandingDTO
                                                                          {
                                                                              EndUserId = a.IntEndUserId,
                                                                              EndUserName = a.StrEndUserName,
                                                                              EndUserPhoneNo = a.StrEndUserPhoneNo,
                                                                              EndUserGender = a.StrEndUserGender

                                                                          });
            EndUserLandingPagination itm = new EndUserLandingPagination();

            if (data == null)
                throw new Exception("Data Not Found");

            else
            {
                if (viewOrder.ToUpper() == "ASC")
                    data = data.OrderBy(o => o.EndUserId);
                else if (viewOrder.ToUpper() == "DESC")
                    data = data.OrderByDescending(o => o.EndUserId);
            }

            if (PageNo <= 0)
                PageNo = 1;
            var itemdata = PagingList<GetEndUserLandingDTO>.CreateAsync(data, PageNo, PageSize);

            long index = (int)(1 + ((PageNo - 1) * PageSize));
            foreach (var itms in itemdata)
            {
                itms.SL = index++;
            }

            itm.data = itemdata;
            itm.currentPage = PageNo;
            itm.totalCount = data.Count();
            itm.pageSize = PageSize;

            return itm;
        }
    }
}
