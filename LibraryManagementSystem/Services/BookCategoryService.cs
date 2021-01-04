using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Services
{
    public class BookCategoryService
    {
        LMSDBEntities context;
        public BookCategoryService()
        {
            context = new LMSDBEntities();
        }
        public List<Models.BookCategoryModel> DisplayData()
        {
            try
            {
                var data = context.BookCategories.Select(a => new Models.BookCategoryModel()
                {
                    BookCategoryId = a.BookCategoryId,
                    BookCategoryName = a.BookCategoryName,
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
        public void SaveData(Models.BookCategoryModel bookCategoryModel)
        {
            var data = new BookCategory()
            {
                BookCategoryId = bookCategoryModel.BookCategoryId,
                BookCategoryName = bookCategoryModel.BookCategoryName,
                Description = bookCategoryModel.Description,

            };
            context.BookCategories.Add(data);
            context.SaveChanges();
        }
        public void UpdateData(Models.BookCategoryModel bookCategoryModel)
        {
            try
            {
                BookCategory data = new BookCategory();
                data = context.BookCategories.Where(a => a.BookCategoryId == bookCategoryModel.BookCategoryId).FirstOrDefault();
                data.BookCategoryId = bookCategoryModel.BookCategoryId;
                data.BookCategoryName = bookCategoryModel.BookCategoryName;
                data.Description = bookCategoryModel.Description;
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
                BookCategory data = new BookCategory();
                data = context.BookCategories.Where(a => a.BookCategoryId == id).FirstOrDefault();
                context.BookCategories.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Models.BookCategoryModel GetData(int id)
        {
            try
            {
                var data = context.BookCategories.Where(a => a.BookCategoryId == id).Select(a => new Models.BookCategoryModel()
                {
                    BookCategoryId = a.BookCategoryId,
                    BookCategoryName = a.BookCategoryName,
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