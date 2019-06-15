using AutoMapper;
using AutoMapper.EntityFramework;
using AutoMapper.EquivalencyExpression;
using MVCAPIdotNET_starter.Models.Domain.Authentication;
using MVCAPIdotNET_starter.Models.Domain.DB;
using MVCAPIdotNET_starter.Models.Dto.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCAPIdotNET_starter
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // initialize AutoMapper - we have to map in both ways
            Mapper.Initialize(cfg => {
                // adds ability to map collections to existing collections without re-creating the collection object
                cfg.AddCollectionMappers();
                // figure out the Id equivalency in EF
                cfg.SetGeneratePropertyMaps<GenerateEntityFrameworkPrimaryKeyPropertyMaps<AppDbContext>>();

                cfg.CreateMap<DtoSubject, Subject>().EqualityComparison((dtoSubject, subject) => dtoSubject.Id == subject.Id);
                cfg.CreateMap<DtoGroup, Group>().EqualityComparison((dtoGroup, subject) => dtoGroup.Id == subject.Id);
                cfg.CreateMap<DtoPosition, Position>().EqualityComparison((dtoPosition, subject) => dtoPosition.Id == subject.Id);

                cfg.CreateMap<Subject, DtoSubject>().EqualityComparison((subject, dtoSubject) => dtoSubject.Id == subject.Id);
                cfg.CreateMap<Group, DtoGroup>().EqualityComparison((subject, dtoGroup) => dtoGroup.Id == subject.Id);
                cfg.CreateMap<Position, DtoPosition>().EqualityComparison((subject, dtoPosition) => dtoPosition.Id == subject.Id);
            });
        }
    }
}
