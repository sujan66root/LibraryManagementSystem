using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Services
{
    public class FineService
    {
        LMSDBEntities context;
        public FineService()
        {
            context = new LMSDBEntities();
        }
        public List<Models.FineModel> DisplayData()
        {
            try
            {
                var data = context.Fines.Select(a => new Models.FineModel()
                {
                    FineId = a.FineId,
                    LateDays = a.LateDays,
                    MemberCategoryId = a.MemberCategoryId,
                    Amount = a.Amount,
                    Remarks = a.Remarks
                }).ToList();
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public void SaveData(Models.FineModel fineModel)
        {
            var data = new Fine()
            {
                FineId = fineModel.FineId,
                LateDays = fineModel.LateDays,
                MemberCategoryId = fineModel.MemberCategoryId,
                Amount = fineModel.Amount,
                Remarks = fineModel.Remarks
            };
            context.Fines.Add(data);
            context.SaveChanges();
        }
        public void UpdateData(Models.FineModel fineModel)
        {
            try
            {
                Fine data = new Fine();
                data = context.Fines.Where(a => a.FineId == fineModel.FineId).FirstOrDefault();
                data.LateDays = fineModel.LateDays;
                data.MemberCategoryId = fineModel.MemberCategoryId;
                data.Amount = fineModel.Amount;
                data.Remarks = fineModel.Remarks;
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
                Fine data = new Fine();
                data = context.Fines.Where(a => a.FineId == id).FirstOrDefault();
                context.Fines.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Models.FineModel GetData(int id)
        {
            try
            {
                var data = context.Fines.Where(a => a.FineId == id).Select(a => new Models.FineModel()
                {
                    FineId = a.FineId,
                    LateDays = a.LateDays,
                    MemberCategoryId = a.MemberCategoryId,
                    Amount = a.Amount,
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
