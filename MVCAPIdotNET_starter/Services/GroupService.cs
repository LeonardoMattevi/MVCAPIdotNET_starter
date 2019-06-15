
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
    public class GroupService
    {
        private bool MineDbContext = true;
        private AppDbContext CtxDB;
        private Guid OrganizationId;
        private GroupService() { }
        public GroupService(Guid organizationId)
        {
            OrganizationId = organizationId;
            CtxDB = new AppDbContext();
        }
        private static IQueryable<Group> GetContextualGroups(AppDbContext ctxDB, Guid organizationId)
        {
            // TODO: make Where with OrganizationId taked from configuration file
            return ctxDB.Groups.Where(g => g.OrganizationId == organizationId && g.DeletedDate != null);
        }
        private static Group GetGroup(AppDbContext ctxDB, Guid organizationAPP, Guid GroupId)
        {
            return GetContextualGroups(ctxDB, organizationAPP).FirstOrDefault(s => s.Id == GroupId);
        }
        public List<DtoGroup> GetList()
        {
            return Mapper.Map<List<DtoGroup>>(GetContextualGroups(CtxDB, OrganizationId).ToList());
        }
        public DtoGroup Get(Guid GrouplId)
        {
            Group group = GetContextualGroups(CtxDB, OrganizationId).FirstOrDefault(s => s.Id == GrouplId);
            return Mapper.Map<DtoGroup>(group);
        }
        public void Remove(Guid GroupId)
        {
            Group oldGroup = GetGroup(CtxDB, OrganizationId, GroupId);
            // TODO: Phisical deleate with cascade
            // CtxDB.Groups.Remove(oldGroup);

            oldGroup.DeletedDate = DateTime.UtcNow;

            CtxDB.Entry(oldGroup).State = EntityState.Modified;
            CtxDB.SaveChanges();
        }
        public void Update(DtoGroup Group, List<Position> Positions = null)
        {
            Group oldGroup = GetGroup(CtxDB, OrganizationId, Group.Id);
            oldGroup.Name = Group.Name;
            oldGroup.Description = Group.Description;
            oldGroup.LastModifiedDate = DateTime.UtcNow;

            CtxDB.Entry(oldGroup).State = EntityState.Modified;
            CtxDB.SaveChanges();
        }
        public void Insert(DtoGroup Group)
        {
            Group newGroup = new Group
            {
                Name = Group.Name,
                Description = Group.Description,
                OrganizationId = OrganizationId,
                CreatedDate = DateTime.UtcNow
            };
            CtxDB.Groups.Add(newGroup);
            CtxDB.SaveChanges();
        }
        public bool Exists(Guid id)
        {
            Group oldGroup = GetGroup(CtxDB, OrganizationId, id);
            return (oldGroup != null);
        }
        public void Dispose()
        {
            if(MineDbContext)
                CtxDB.Dispose();
        }
    }
}