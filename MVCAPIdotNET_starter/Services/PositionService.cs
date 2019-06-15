
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
    public class PositionService
    {
        private AppDbContext CtxDB;
        private Guid CurrentOrganizationId;
        private PositionService() { }
        public PositionService(Guid organizationAPP)
        {
            CurrentOrganizationId = organizationAPP;
            CtxDB = new AppDbContext();
        }
        private static IQueryable<Position> GetContextualPositions(AppDbContext ctxDB, Guid organizationId)
        {
            return ctxDB.Positions.Where(p => p.OrganizationId == organizationId && p.DeletedDate != null);
        }
        private static Position GetPosition(AppDbContext ctxDB, Guid organizationId, Guid positionId)
        {
            return GetContextualPositions(ctxDB, organizationId).FirstOrDefault(s => s.Id == positionId);
        }
        public List<DtoPosition> GetList()
        {
            return Mapper.Map<List<DtoPosition>>(GetContextualPositions(CtxDB, CurrentOrganizationId).ToList());
        }
        public List<DtoPosition> GetliteList()
        {
            return GetContextualPositions(CtxDB, CurrentOrganizationId).ToList().Select((p) => new DtoPosition {
                Id = p.Id,
                GroupId = p.GroupId,
                SubjectId = p.SubjectId,
                Type = p.RoleType
            }).ToList();
        }
        public DtoPosition Get(Guid PositionlId)
        {
            Position position = GetContextualPositions(CtxDB, CurrentOrganizationId).FirstOrDefault(s => s.Id == PositionlId);
            return Mapper.Map<DtoPosition>(position);
        }
        public DtoPosition GetLite(Guid PositionlId)
        {
            Position position = GetContextualPositions(CtxDB, CurrentOrganizationId).FirstOrDefault(s => s.Id == PositionlId);
            return new DtoPosition {
                Id = position.Id,
                GroupId = position.GroupId,
                SubjectId = position.SubjectId,
                Type = position.RoleType
            };
        }
        public void Remove(DtoPosition position)
        {
            Position oldPosition = GetPosition(CtxDB, CurrentOrganizationId, position.Id);
            // CtxDB.Positions.Remove(oldPosition);
            oldPosition.DeletedDate = DateTime.UtcNow;
            CtxDB.Entry(oldPosition).State = EntityState.Modified;
            CtxDB.SaveChanges();
        }
        public void Update(DtoPosition position, List<Position> Positions = null)
        {
            Position oldPosition = GetPosition(CtxDB, CurrentOrganizationId, position.Id);
            oldPosition.SubjectId = position.SubjectId;
            oldPosition.RoleType = position.Type;
            oldPosition.GroupId = position.GroupId;
            oldPosition.LastModifiedDate = DateTime.UtcNow;

            CtxDB.Entry(oldPosition).State = EntityState.Modified;
            CtxDB.SaveChanges();
        }
        public void Insert(DtoPosition position)
        {
            Position newPosition = new Position
            {
                SubjectId = position.SubjectId,
                RoleType = position.Type,
                GroupId = position.GroupId,
                OrganizationId = CurrentOrganizationId,
                CreatedDate = DateTime.UtcNow
            };
            CtxDB.Positions.Add(newPosition);
            CtxDB.SaveChanges();
        }
        public bool Exists(Guid id)
        {
            Position oldPosition = GetPosition(CtxDB, CurrentOrganizationId, id);
            return (oldPosition != null);
        }
        public void Dispose()
        {
            CtxDB.Dispose();
        }
    }
}