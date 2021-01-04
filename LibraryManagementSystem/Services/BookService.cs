using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Services
{
    public class BookService
    {
        LMSDBEntities context;
        public BookService()
        {
            context = new LMSDBEntities();
        }
        public List<Models.BookModel> DisplayData()
        {
            try
            {
                var data = context.Books.Select(a => new Models.BookModel()
                {
                    BookId = a.BookId,
                    BookName = a.BookName,
                    BookCategoryId = a.BookCategoryId,
                    AuthorId = a.AuthorId,
                    SubjectId = a.SubjectId,
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
        public void SaveData(Models.BookModel bookModel)
        {
            var data = new Book()
            {
                BookId = bookModel.BookId,
                BookName = bookModel.BookName,
                BookCategoryId = bookModel.BookCategoryId,
                AuthorId = bookModel.AuthorId,
                SubjectId = bookModel.SubjectId,
                Remarks = bookModel.Remarks
            };
            context.Books.Add(data);
            context.SaveChanges();
        }
        public void UpdateData(Models.BookModel bookModel)
        {
            try
            {
                Book data = new Book();
                data = context.Books.Where(a => a.BookId == bookModel.BookId).FirstOrDefault();

                data.BookId = bookModel.BookId;
                data.BookName = bookModel.BookName;
                data.BookCategoryId = bookModel.BookCategoryId;
                data.AuthorId = bookModel.AuthorId;
                data.SubjectId = bookModel.SubjectId;
                data.Remarks = bookModel.Remarks;
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
                Book data = new Book();
                data = context.Books.Where(a => a.BookId == id).FirstOrDefault();
                context.Books.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Models.BookModel GetData(int id)
        {
            try
            {
                var data = context.Books.Where(a => a.BookId == id).Select(a => new Models.BookModel()
                {
                    BookId = a.BookId,
                    BookName = a.BookName,
                    BookCategoryId = a.BookCategoryId,
                    AuthorId = a.AuthorId,
                    SubjectId = a.SubjectId,
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