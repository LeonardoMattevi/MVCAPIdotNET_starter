using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAPIdotNET_starter.Models.Domain.Authentication
{
    public enum TypeRole : short
    {
        Unknow = 0,
        AuthUser = 1,
        Admin = 100,
        SysAdmin = 1000
    }
    public enum TypeGroup : short
    {
        BaseGroup = 1000,
        Organization = 1,
        Group = 10
    }
}