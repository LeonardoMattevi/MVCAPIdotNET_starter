
using AutoMapper;
using MVCAPIdotNET_starter.Code.Manager;
using MVCAPIdotNET_starter.Models.Domain.Authentication;
using MVCAPIdotNET_starter.Models.Domain.DB;
using MVCAPIdotNET_starter.Models.Dto.Authentication;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAPIdotNET_starter.Services
{
    public class SubjectService
    {
        private AppDbContext CtxDB;
        private Guid OrganizationId;
        private SubjectService() { }
        public SubjectService(Guid organizationAPP)
        {
            OrganizationId = organizationAPP;
            CtxDB = new AppDbContext();
        }
        private static IQueryable<Subject> GetContextualSubjects(AppDbContext ctxDB, Guid organizationId)
        {
            return ctxDB.Subjects.Where(s => s.OrganizationId == organizationId && s.DeletedDate != null);
        }
        private static Subject GetSubject(AppDbContext ctxDB, Guid organizationId, Guid subjectId)
        {
            return GetContextualSubjects(ctxDB, organizationId).FirstOrDefault(s => s.Id == subjectId);
        }
        public List<DtoSubject> GetList()
        {
            return Mapper.Map<List<DtoSubject>>(GetContextualSubjects(CtxDB, OrganizationId).ToList());
        }
        public DtoSubject Get(Guid SubjectlId)
        {
            Subject subject = GetContextualSubjects(CtxDB, OrganizationId).FirstOrDefault(s => s.Id == SubjectlId);
            return Mapper.Map<DtoSubject>(subject);
        }
        public void Remove(Guid subjectId)
        {
            Subject oldSubject = GetSubject(CtxDB, OrganizationId, subjectId);
            //CtxDB.Subjects.Remove(oldSubject);
            oldSubject.DeletedDate = DateTime.UtcNow;

            CtxDB.Entry(oldSubject).State = EntityState.Modified;
            CtxDB.SaveChanges();
        }
        public void Update(DtoSubject subject, List<Position> Positions = null)
        {
            Subject oldSubject = GetSubject(CtxDB, OrganizationId, subject.Id);
            oldSubject.Name = subject.Name;
            oldSubject.LastName = subject.Surname;
            oldSubject.Email = subject.Email;
            oldSubject.LastModifiedDate = DateTime.UtcNow;

            CtxDB.Entry(oldSubject).State = EntityState.Modified;
            CtxDB.SaveChanges();
        }
        public void Insert(DtoSubject subject)
        {
            Subject newSubject = new Subject
            {
                Name = subject.Name,
                LastName = subject.Surname,
                Email = subject.Email,
                OrganizationId = OrganizationId,
                CreatedDate = DateTime.UtcNow
            };
            CtxDB.Subjects.Add(newSubject);
            CtxDB.SaveChanges();
        }
        public bool Exists(Guid id)
        {
            Subject oldSubject = GetSubject(CtxDB, OrganizationId, id);
            return (oldSubject != null);
        }
        public void Dispose()
        {
            CtxDB.Dispose();
        }
    }
}