using MVCAPIdotNET_starter.Models.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAPIdotNET_starter.Models.Dto.Authentication
{
    public class DtoGroup
    {
        public DtoGroup()
        {
            Positions = new List<DtoPosition>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TypeGroup Type { get; set; }

        public List<DtoPosition> Positions { get; set; }
    }
}