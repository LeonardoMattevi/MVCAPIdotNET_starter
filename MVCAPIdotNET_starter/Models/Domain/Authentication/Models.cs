using MVCAPIdotNET_starter.Models.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAPIdotNET_starter.Models.Domain.Authentication
{
    public class Subject : BaseDomainEntities
    {
        public Subject()
        {
            Positions = new HashSet<Position>();
        }
        public Guid Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [StringLength(150)]
        public string LastName { get; set; }
        [Required]
        [StringLength(150)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Wrong email format")]
        public string Email { get; set; }
        [Required]
        public Guid OrganizationId { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
    public class Group : BaseDomainEntities
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(2500)]
        public string Description { get; set; }
        [Required]
        public Guid OrganizationId { get; set; }
        public TypeGroup GroupType { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
    public class Position : BaseDomainEntities
    {
        public Guid Id { get; set; }
        [Required]
        public Guid SubjectId { get; set; }
        [Required]
        public Guid GroupId { get; set; }
        [Required]
        public TypeRole RoleType { get; set; }
        [Required]
        public Guid OrganizationId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Group Group { get; set; }
    }
}