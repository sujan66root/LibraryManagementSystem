using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Services
{
    public class MemberService
    {
        LMSDBEntities context;
        public MemberService()
        {
            context = new LMSDBEntities();
        }
        public List<Models.MemberModel> DisplayData()
        {
            try
            {
                var data = context.Members.Select(a => new Models.MemberModel()
                {
                    MemberId = a.MemberId,
                    MemberName = a.MemberName,
                    MemberCategoryId = a.MemberCategoryId,
                    MemberAddress = a.MemberAddress,
                    ContactNo = a.ContactNo,
                    EmailAddress = a.EmailAddress,
                    Username = a.Username,
                    Password = a.Password,
                    Status = a.Status
                }).ToList();
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public void SaveData(Models.MemberModel memberModel)
        {
            var data = new Member()
            {
                MemberId = memberModel.MemberId,
                MemberName = memberModel.MemberName,
                MemberCategoryId = memberModel.MemberCategoryId,
                MemberAddress = memberModel.MemberAddress,
                ContactNo = memberModel.ContactNo,
                EmailAddress = memberModel.EmailAddress,
                Username = memberModel.Username,
                Password = memberModel.Password,
                Status = memberModel.Status
            };
            context.Members.Add(data);
            context.SaveChanges();
        }
        public void UpdateData(Models.MemberModel memberModel)
        {
            try
            {
                Member data = new Member();
                data = context.Members.Where(a => a.MemberId == memberModel.MemberId).FirstOrDefault();
                data.MemberName = memberModel.MemberName;
                data.MemberCategoryId = memberModel.MemberCategoryId;
                data.MemberAddress = memberModel.MemberAddress;
                data.ContactNo = memberModel.ContactNo;
                data.EmailAddress = memberModel.EmailAddress;
                data.Username = memberModel.Username;
                data.Password = memberModel.Password;
                data.Status = memberModel.Status;
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteData(int id)
        {
            try
            {
                Member data = new Member();
                data = context.Members.Where(a => a.MemberId == id).FirstOrDefault();
                context.Members.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Models.MemberModel GetData(int id)
        {
            try
            {
                var data = context.Members.Where(a => a.MemberId == id).Select(a => new Models.MemberModel()
                {
                    MemberId = a.MemberId,
                    MemberName = a.MemberName,
                    MemberCategoryId = a.MemberCategoryId,
                    MemberAddress = a.MemberAddress,
                    ContactNo = a.ContactNo,
                    EmailAddress = a.EmailAddress,
                    Username = a.Username,
                    Password = a.Password,
                    Status = a.Status
                }).FirstOrDefault();
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}