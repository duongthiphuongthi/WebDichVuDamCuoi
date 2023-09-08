using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeddingsWebsite.Models;

namespace WeddingsWebsite.Controllers
{
    public class DoCuoiApiController : ApiController
    {
        // GET: api/DoCuoiApi
        public IEnumerable<DOCUOI> Get()
        {
            DBWeddingDataContext db = new DBWeddingDataContext();
            return db.DOCUOIs.ToList();
        }

        // GET: api/DoCuoiApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DoCuoiApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DoCuoiApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DoCuoiApi/5
        public void Delete(int id)
        {
        }
    }
}
