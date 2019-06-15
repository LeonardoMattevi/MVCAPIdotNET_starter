using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAPIdotNET_starter.Models.Domain.Base
{
    public class BaseDomainEntities
    {
        public DateTime CreatedDate { get; set; }
        public Nullable<DateTime> LastModifiedDate { get; set; }
        public Nullable<DateTime> DeletedDate { get; set; }
    }
}