using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Services
{
    public class BookIssueReturnService
    {
        LMSDBEntities context;
        public BookIssueReturnService()
        {
            context = new LMSDBEntities();
        }
        public List<Models.BookIssueReturnModel> DisplayData()
        {
            try
            {
                var data = context.BookIssueReturns.Select(a => new Models.BookIssueReturnModel()
                {
                    BookIssueReturnId = a.BookIssueReturnId,
                    MemberId = a.MemberId,
                    AssesionId = a.AssesionId,
                    IssueDate = a.IssueDate,
                    DueDate = a.DueDate,
                    ReturnDate = a.ReturnDate,
                    LateDays = a.LateDays,
                    FineAmount = a.FineAmount,
                    Status = a.Status,
                    MemberCategoryId = a.MemberCategoryId,
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
        public void SaveData(Models.BookIssueReturnModel bookIssueReturnModel)
        {
            var data = new BookIssueReturn()
            {
                BookIssueReturnId = bookIssueReturnModel.BookIssueReturnId,
                MemberId = bookIssueReturnModel.MemberId,
                AssesionId = bookIssueReturnModel.AssesionId,
                IssueDate = bookIssueReturnModel.IssueDate,
                DueDate = bookIssueReturnModel.DueDate,
                ReturnDate = bookIssueReturnModel.ReturnDate,
                LateDays = bookIssueReturnModel.LateDays,
                FineAmount = bookIssueReturnModel.FineAmount,
                Status = bookIssueReturnModel.Status,
                MemberCategoryId = bookIssueReturnModel.MemberCategoryId,
                Remarks = bookIssueReturnModel.Remarks
            };
            context.BookIssueReturns.Add(data);
            context.SaveChanges();
        }
        public void UpdateData(Models.BookIssueReturnModel bookIssueReturnModel)
        {
            try
            {
                BookIssueReturn data = new BookIssueReturn();
                data = context.BookIssueReturns.Where(a => a.BookIssueReturnId == bookIssueReturnModel.BookIssueReturnId).FirstOrDefault();
                data.BookIssueReturnId = bookIssueReturnModel.BookIssueReturnId;
                data.MemberId = bookIssueReturnModel.MemberId;
                data.AssesionId = bookIssueReturnModel.AssesionId;
                data.IssueDate = bookIssueReturnModel.IssueDate;
                data.DueDate = bookIssueReturnModel.DueDate;
                data.ReturnDate = bookIssueReturnModel.ReturnDate;
                data.LateDays = bookIssueReturnModel.LateDays;
                data.FineAmount = bookIssueReturnModel.FineAmount;
                data.Status = bookIssueReturnModel.Status;
                data.MemberCategoryId = bookIssueReturnModel.MemberCategoryId;
                data.Remarks = bookIssueReturnModel.Remarks;
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
                BookIssueReturn data = new BookIssueReturn();
                data = context.BookIssueReturns.Where(a => a.BookIssueReturnId == id).FirstOrDefault();
                context.BookIssueReturns.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Models.BookIssueReturnModel GetData(int id)
        {
            try
            {
                var data = context.BookIssueReturns.Where(a => a.BookIssueReturnId == id).Select(a => new Models.BookIssueReturnModel()
                {
                    BookIssueReturnId = a.BookIssueReturnId,
                    MemberId = a.MemberId,
                    AssesionId = a.AssesionId,
                    IssueDate = a.IssueDate,
                    DueDate = a.DueDate,
                    ReturnDate = a.ReturnDate,
                    LateDays = a.LateDays,
                    FineAmount = a.FineAmount,
                    Status = a.Status,
                    MemberCategoryId = a.MemberCategoryId,
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