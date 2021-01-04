using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Services
{
    public class SubjectService
    {
        LMSDBEntities context;
        public SubjectService()
        {
            context = new LMSDBEntities();
        }
        public List<Models.SubjectModel> DisplayData()
        {
            try
            {
                var data = context.Subjects.Select(a => new Models.SubjectModel()
                {
                    SubjectId = a.SubjectId,
                    SubjectName = a.SubjectName,
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
        public void SaveData(Models.SubjectModel subjectModel)
        {
            var data = new Subject()
            {
                SubjectId = subjectModel.SubjectId,
                SubjectName = subjectModel.SubjectName,
                Remarks = subjectModel.Remarks
            };
            context.Subjects.Add(data);
            context.SaveChanges();
        }
        public void UpdateData(Models.SubjectModel subjectModel)
        {
            try
            {
                Subject data = new Subject();
                data = context.Subjects.Where(a => a.SubjectId == subjectModel.SubjectId).FirstOrDefault();
                data.SubjectName = subjectModel.SubjectName;
                data.Remarks = subjectModel.Remarks;
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
                Subject data = new Subject();
                data = context.Subjects.Where(a => a.SubjectId == id).FirstOrDefault();
                context.Subjects.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Models.SubjectModel GetData(int id)
        {
            try
            {
                var data = context.Subjects.Where(a => a.SubjectId == id).Select(a => new Models.SubjectModel()
                {
                    SubjectId = a.SubjectId,
                    SubjectName = a.SubjectName,
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