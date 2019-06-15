using MVCAPIdotNET_starter.Models.Domain.Authentication;
using MVCAPIdotNET_starter.Models.Domain.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace MVCAPIdotNET_starter.Code.Manager
{
    public static class ManagerSeedDB
    {
        public static void SeedMe(AppDbContext context)
        {
            Guid organizationSeed = Guid.Parse("88888888-1811-43e3-908f-6fcf3ac3ced3");
            Subject sysAdmin = new Subject
            {
                Id = Guid.Parse("88888888-5dfa-46e0-971d-38f034429dc9"),
                Name = "Leonardo",
                LastName = "Mattevi",
                Email = "leonardo.mattevi@isnotmyemail.com",
                OrganizationId = organizationSeed,
                CreatedDate = DateTime.UtcNow
            };
            Subject userPerson = new Subject
            {
                Id = Guid.Parse("88888888-f967-41b0-8fac-d2b6eb197276"),
                Name = "Mario",
                LastName = "Rossi",
                Email = "mario.rossi@isnotmyemail.com",
                OrganizationId = organizationSeed,
                CreatedDate = DateTime.UtcNow
            };
            Group sysGroup = new Group
            {
                Id = Guid.Parse("88888888-78b8-4868-9f72-a6cc738de8ae"),
                Name = "BaseGroup",
                Description = "This is the group with job to manage the application.",
                OrganizationId = organizationSeed,
                GroupType = TypeGroup.BaseGroup,
                CreatedDate = DateTime.UtcNow
            };
            Position sysAdminPosition = new Position
            {
                Id = Guid.Parse("88888888-9620-4e1f-819a-10e856cab20e"),
                RoleType = TypeRole.SysAdmin,
                GroupId = sysGroup.Id,
                SubjectId = sysAdmin.Id,
                OrganizationId = organizationSeed,
                CreatedDate = DateTime.UtcNow
            };
            Position userPersonPosition = new Position
            {
                Id = Guid.Parse("88888888-491f-4454-8deb-0f3000d353ae"),
                RoleType = TypeRole.AuthUser,
                GroupId = sysGroup.Id,
                SubjectId = userPerson.Id,
                OrganizationId = organizationSeed,
                CreatedDate = DateTime.UtcNow
            };

            context.Groups.AddOrUpdate(sysGroup);

            context.Subjects.AddOrUpdate(sysAdmin);
            context.Positions.AddOrUpdate(sysAdminPosition);

            context.Subjects.AddOrUpdate(userPerson);
            context.Positions.AddOrUpdate(userPersonPosition);
        }
    }
}