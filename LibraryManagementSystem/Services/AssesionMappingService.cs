using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Services
{
    public class AssesionMappingService
    {
        LMSDBEntities context;
        public AssesionMappingService()
        {
            context = new LMSDBEntities();
        }
        public List<Models.AssesionMappingModel> DisplayData()
        {
            try
            {
                var data = context.AssesionMappings.Select(a => new Models.AssesionMappingModel()
                {
                    AssesionId = a.AssesionId,
                    BookId = a.BookId,
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
        public void SaveData(Models.AssesionMappingModel assesionMappingModel)
        {
            var data = new AssesionMapping()
            {
                AssesionId = assesionMappingModel.AssesionId,
                BookId = assesionMappingModel.BookId,
                Status = assesionMappingModel.Status
            };
            context.AssesionMappings.Add(data);
            context.SaveChanges();
        }
        public void UpdateData(Models.AssesionMappingModel assesionMappingModel)
        {
            try
            {
                AssesionMapping data = new AssesionMapping();
                data = context.AssesionMappings.Where(a => a.AssesionId == assesionMappingModel.AssesionId).FirstOrDefault();
                data.BookId = assesionMappingModel.BookId;
                data.Status = assesionMappingModel.Status;
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
                AssesionMapping data = new AssesionMapping();
                data = context.AssesionMappings.Where(a => a.AssesionId == id).FirstOrDefault();
                context.AssesionMappings.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Models.AssesionMappingModel GetData(int id)
        {
            try
            {
                var data = context.AssesionMappings.Where(a => a.AssesionId == id).Select(a => new Models.AssesionMappingModel()
                {
                    AssesionId = a.AssesionId,
                    BookId = a.BookId,
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