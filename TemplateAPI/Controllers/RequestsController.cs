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
    public class RequestsController : ApiController
    {
        [HttpGet]
        [Route("api/request")]
        public List<Request> GetRequest()
        {
            using (var context = new TemplateAPIContext())
            {
                var query = context.Requests.ToList();
                if (query != null)
                {
                    return query;
                }
                return null;
            }
        }

        [HttpPost]
        [Route("api/request")]
        public Request Insert([FromBody]Request request)
        {
            using (var context = new TemplateAPIContext())
            {
                if (request != null)
                {
                    context.Requests.Add(request);
                    context.SaveChanges();
                }
                return request;
            }
        }

        [HttpPut]
        [Route("api/request")]
        public Request Update([FromBody]Request request)
        {
            using (var context = new TemplateAPIContext())
            {
                var entity = context.Requests.Where(x => x.Id == request.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.Id = request.Id;
                    entity.TemplateId = request.TemplateId;
                    entity.Json = request.Json;
                    entity.CreationDate = request.CreationDate;
                    entity.Version = request.Version;
                    context.SaveChanges();
                }
                return entity;
            }
        }

        [HttpDelete]
        [Route("api/request/{id:int}")]
        public bool Delete(int id)
        {
            using (var context = new TemplateAPIContext())
            {
                var entity = context.Requests.Where(x => x.Id == id).FirstOrDefault();
                if (entity != null)
                {
                    context.Requests.Remove(entity);
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
        [Route("api/request/{id:int}")]
        public Request GetRequestById(int id)
        {
            using (var context = new TemplateAPIContext())
            {
                var query = context.Requests.Where(x => x.Id == id).FirstOrDefault();
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