using City_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace City_Management_App.Controllers.api
{
    public class SchoolsController : ApiController
    {
        static string connString = "Data Source=LAPTOP-P4F5KURV;Initial Catalog=CityDB;Integrated Security=True;Pooling=False";
        SchoolsDBDataContext SchoolsDB = new SchoolsDBDataContext;
        // GET: api/Schools
        public IHttpActionResult Get()
        {

            return Ok()
        }

        // GET: api/Schools/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Schools
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Schools/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Schools/5
        public void Delete(int id)
        {
        }
    }
}
