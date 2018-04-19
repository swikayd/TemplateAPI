using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TemplateAPI.Models;
using System.Web.Http.Cors;

namespace TemplateAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TemplatesController : ApiController
    {
        [HttpGet]
        [Route("api/template")]
        public List<Template> GetTemplates()
        {
            using (var context = new TemplateAPIContext())
            {
                var query = context.Templates.ToList();
                if (query != null)
                {
                    return query;
                }
                return null;
            }
        }

        [HttpPost]
        [Route("api/template")]
        public Template Insert([FromBody]Template template)
        {
            using (var context = new TemplateAPIContext())
            {
                if (template != null)
                {
                    context.Templates.Add(template);
                    context.SaveChanges();
                }
                return template;
            }
        }

        [HttpPut]
        [Route("api/template")]
        public Template Update([FromBody]Template template)
        {
            using (var context = new TemplateAPIContext())
            {
                var entity = context.Templates.Where(x => x.Id == template.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.Id = template.Id;
                    entity.TemplateId = template.TemplateId;
                    entity.Json = template.Json;
                    entity.CreationDate = template.CreationDate;
                    entity.Version = template.Version;
                    context.SaveChanges();
                }
                return entity;
            }
        }

        [HttpDelete]
        [Route("api/template/{id:int}")]
        public bool Delete(int id)
        {
            using (var context = new TemplateAPIContext())
            {
                var entity = context.Templates.Where(x => x.Id == id).FirstOrDefault();
                if (entity != null)
                {
                    context.Templates.Remove(entity);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        [HttpGet]
        [Route("api/template/{id:int}")]
        public Template GetRequestById(int id)
        {
            using (var context = new TemplateAPIContext())
            {
                var query = context.Templates.Where(x => x.Id == id).FirstOrDefault();
                if (query != null)
                {
                    return query;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}