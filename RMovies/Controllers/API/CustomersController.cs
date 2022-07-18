using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using RMovies.DTOS;
using RMovies.Models;
using System.Net;

namespace RMovies.Controllers.API
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext ctx;
        public CustomersController()
        {
            ctx = new ApplicationDbContext();
        }
      
       /* public IEnumerable<CustomerDto> GetCustomers()
        {

            return ctx.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }*/
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = ctx.Customers.Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }


        public CustomerDto GetCustomerById(int id)
        {
            
            
            var customer = ctx.Customers.Where(c => c.id == id).FirstOrDefault();
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Mapper.Map<Customer,CustomerDto>(customer);
            } 
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Create(CustomerDto c)
        {
            if (ModelState.IsValid)
            {
                var customer = Mapper.Map<CustomerDto, Customer>(c);
                ctx.Customers.Add(customer);
                ctx.SaveChanges();
                c.id = customer.id;
                return Created(new Uri(Request.RequestUri+"/"+customer.id),c);
            }
            else
            {
                return BadRequest();
            }
        }
        [System.Web.Http.HttpPut]
        public void Update(int id, CustomerDto c)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = ctx.Customers.Where(cs=> cs.id == id).FirstOrDefault();

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            /*customer.birthday = c.birthday;
            customer.IsSubscribed = c.IsSubscribed;
            customer.MembershipTypeId = c.MembershipTypeId;
            customer.name = c.name;*/
            Mapper.Map<CustomerDto, Customer>(c, customer);
           
            
            ctx.SaveChanges();
           }

        [System.Web.Http.HttpDelete]
        public void Delete(int id)
        {
            var customer = ctx.Customers.Where(c => c.id == id).FirstOrDefault();
            ctx.Customers.Remove(customer);
            ctx.SaveChanges();
        }
          
               
            
        }
    }


