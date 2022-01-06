using City_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace City_Management_App.Controllers.api
{
    public class CitizenController : ApiController
    {
        static string connString = "Data Source=LAPTOP-P4F5KURV;Initial Catalog=CityDB;Integrated Security=True;Pooling=False";
        CitizensDBDataContext dataContext = new CitizensDBDataContext(connString);
        // GET: api/Citizen
        public IHttpActionResult Get()
        {
            try
            {
                List<Citizen> list = dataContext.Citizens.ToList();
                return Ok(list);

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/Citizen/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Citizen SpecificCitizen = dataContext.Citizens.First((item) => item.Id == id);
                return Ok(new { SpecificCitizen });

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Citizen
        public IHttpActionResult Post([FromBody] Citizen value)
        {
            try
            {
                dataContext.Citizens.InsertOnSubmit(value);
                dataContext.SubmitChanges();

                return Ok(new { value });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Citizen/5
        public IHttpActionResult Put(int id, [FromBody] Citizen value)
        {
            try
            {
                Citizen CitizenToAdd = dataContext.Citizens.First((item) => item.Id == id);
                CitizenToAdd.First_Name = value.First_Name;
                CitizenToAdd.Last_Name = value.Last_Name;
                CitizenToAdd.Birthday = value.Birthday;
                CitizenToAdd.Address = value.Address;
                CitizenToAdd.Seniority = value.Seniority;

                dataContext.SubmitChanges();

                List<Citizen> listo = dataContext.Citizens.ToList();
                return Ok(new { listo });
            }

            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE: api/Citizen/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                dataContext.Citizens.DeleteOnSubmit(dataContext.Citizens.First((item) => item.Id == id));
                dataContext.SubmitChanges();

                List<Citizen> listo = dataContext.Citizens.ToList();
                return Ok(new { listo });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Cannot Delete NONE!");
            }
        }
    }
}
