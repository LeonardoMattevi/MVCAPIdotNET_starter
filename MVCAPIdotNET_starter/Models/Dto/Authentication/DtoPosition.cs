using MVCAPIdotNET_starter.Models.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAPIdotNET_starter.Models.Dto.Authentication
{
    public class DtoPosition
    {
        public DtoPosition()
        {
            Subject = null;
            Group = null;
        }
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }
        public Guid GroupId { get; set; }
        public TypeRole Type { get; set; }

        public DtoUser Subject { get; set; }
        public DtoGroup Group { get; set; }
    }
}