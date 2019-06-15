using MVCAPIdotNET_starter.Models.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAPIdotNET_starter.Models.Dto.Authentication
{
    public class DtoUser
    {
        public DtoUser() {}

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.Name, this.Surname);
            }
        }
        public string Email { get; set; }
        public TypeRole Role { get; set; }
    }
}