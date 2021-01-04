using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Services
{
    public class AuthorService
    {
        LMSDBEntities context;
        public AuthorService()
        {
            context = new LMSDBEntities();
        }
        public List<Models.AuthorModel> DisplayData()
        {
            try
            {
                var data = context.Authors.Select(a => new Models.AuthorModel()
                {
                    AuthorId = a.AuthorId,
                    AuthorName = a.AuthorName,
                    Description = a.Description,
                }).ToList();
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public void SaveData(Models.AuthorModel authorModel)
        {
            var data = new Author()
            {
                AuthorId = authorModel.AuthorId,
                AuthorName = authorModel.AuthorName,
                Description = authorModel.Description,
            };
            context.Authors.Add(data);
            context.SaveChanges();
        }
        public void UpdateData(Models.AuthorModel authorModel)
        {
            try
            {
                Author data = new Author();
                data = context.Authors.Where(a => a.AuthorId == authorModel.AuthorId).FirstOrDefault();
                data.AuthorName = authorModel.AuthorName;
                data.Description = authorModel.Description;
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
                Author data = new Author();
                data = context.Authors.Where(a => a.AuthorId == id).FirstOrDefault();
                context.Authors.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Models.AuthorModel GetData(int id)
        {
            try
            {
                var data = context.Authors.Where(a => a.AuthorId == id).Select(a => new Models.AuthorModel()
                {
                    AuthorId = a.AuthorId,
                    AuthorName = a.AuthorName,
                    Description = a.Description
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