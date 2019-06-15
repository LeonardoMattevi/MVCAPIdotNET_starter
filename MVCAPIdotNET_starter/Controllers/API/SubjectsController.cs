using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using MVCAPIdotNET_starter.Controllers.API.Base;
using MVCAPIdotNET_starter.Models.Dto.Authentication;
using MVCAPIdotNET_starter.Services;

namespace MVCAPIdotNET_starter.Controllers.API
{
    public class SubjectsController : BaseAPIController
    {
        private SubjectService SubjectService = new SubjectService(ContextualOrganization.InstanceGuid);

        // GET: api/Subjects
        [ResponseType(typeof(List<DtoSubject>))]
        public IHttpActionResult GetSubjects()
        {
            List<DtoSubject> subjectList = SubjectService.GetList();
            return Ok(subjectList);
        }

        // GET: api/Subjects/5
        [ResponseType(typeof(DtoSubject))]
        public IHttpActionResult GetSubject(Guid id)
        {
            DtoSubject subject = SubjectService.Get(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        // PUT: api/Subjects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubject(Guid id, DtoSubject subject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (id != subject.Id)
                return BadRequest();

            try {
                SubjectService.Update(subject);
            }
            catch (Exception e) {
                throw e;
            }

            return Ok(subject);
        }

        // POST: api/Subjects
        [ResponseType(typeof(DtoSubject))]
        public IHttpActionResult PostSubject(DtoSubject subject)
        {
            if (!ModelState.IsValid)            
                return BadRequest(ModelState);           

            try
            {
                SubjectService.Insert(subject);
            }
            catch (Exception e)
            {
                throw e;
            }

            return Ok(subject);
        }
        
        // DELETE: api/Subjects/5
        [ResponseType(typeof(DtoSubject))]
        public IHttpActionResult DeleteSubject(Guid id)
        {
            DtoSubject subject = SubjectService.Get(id);
            if (subject == null)
                return NotFound();

            return Ok(subject);
        }

        private bool SubjectExists(Guid id)
        {
            return SubjectService.Exists(id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                SubjectService.Dispose();

            base.Dispose(disposing);
        }

    }
}