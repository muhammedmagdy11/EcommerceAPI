using E_Commerce_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace E_Commerce_API.Controllers
{
    public class UserController : ApiController
    {

        Ecommerce db = new Ecommerce();

        public IHttpActionResult GetCustomers()
        {
            List<AspNetUser> li = db.AspNetUsers.Include("Orders").ToList();
            //List<AspNetUsers> li = db.AspNetUsers.ToList();
            return Ok<List<AspNetUser>>(li);
        }

        // GET: api/Customers/5
        [ResponseType(typeof(AspNetUser))]
        public IHttpActionResult GetCustomer(string id)
        {
            AspNetUser customer = db.AspNetUsers.Where( u => u.Id == id).FirstOrDefault();
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(string id, AspNetUser customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(AspNetUser))]
        public IHttpActionResult PostCustomer(AspNetUser customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AspNetUsers.Add(customer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(AspNetUser))]
        public IHttpActionResult DeleteCustomer(string id)
        {
            AspNetUser customer = db.AspNetUsers.Where( u => u.Id == id).FirstOrDefault();
            if (customer == null)
            {
                return NotFound();
            }

            db.AspNetUsers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(string id)
        {
            return db.AspNetUsers.Count(e => e.Id == id) > 0;
        }

    }
}
