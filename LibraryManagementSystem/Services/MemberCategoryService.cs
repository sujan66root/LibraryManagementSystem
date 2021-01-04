using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Services
{
    public class MemberCategoryService
    {
        LMSDBEntities context;
        public MemberCategoryService()
        {
            context = new LMSDBEntities();
        }
        public List<Models.MemberCategoryModel> DisplayData()
        {
            try
            {
                var data = context.MemberCategories.Select(a => new Models.MemberCategoryModel()
                {
                    MemberCategoryId = a.MemberCategoryId,
                    MemberCategoryName = a.MemberCategoryName,
                    Remarks = a.Remarks
                }).ToList();
                return data;
            }
            catch (Exception)
            {
                 
                throw;
            }
        }
        public void SaveData(Models.MemberCategoryModel memberCategoryModel)
        {
            var data = new MemberCategory()
            {
                MemberCategoryId = memberCategoryModel.MemberCategoryId,
                MemberCategoryName = memberCategoryModel.MemberCategoryName,
                Remarks = memberCategoryModel.Remarks,
            };
            context.MemberCategories.Add(data);
            context.SaveChanges();
        }
        public void UpdateData(Models.MemberCategoryModel memberCategoryModel)
        {
            try
            {
                MemberCategory data = new MemberCategory();
                data = context.MemberCategories.Where(a => a.MemberCategoryId == memberCategoryModel.MemberCategoryId).FirstOrDefault();
                data.MemberCategoryName = memberCategoryModel.MemberCategoryName;
                data.Remarks = memberCategoryModel.Remarks;
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
                MemberCategory data = new MemberCategory();
                data = context.MemberCategories.Where(a => a.MemberCategoryId == id).FirstOrDefault();
                context.MemberCategories.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Models.MemberCategoryModel GetData(int id)
        {
            try
            {
                var data = context.MemberCategories.Where(a => a.MemberCategoryId == id).Select(a => new Models.MemberCategoryModel()
                {
                    MemberCategoryId = a.MemberCategoryId,
                    MemberCategoryName = a.MemberCategoryName,
                    Remarks = a.Remarks
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