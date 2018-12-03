using AutoMapper;
using MovieStore.Dto;
using MovieStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieStore.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        //[HttpGet]
        public IHttpActionResult GetCustomers()
        {
            //Ao utilziar o SELECT dessa forma voce mapeia as propriedades do Customer para o DTO
            var customer = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return Ok();
            //return Ok(Mapper.Map<Customer,CustomerDto>(customer));

        }

        // GET /api/customers/1
        //[HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            //return Mapper.Map<Customer, CustomerDto>(customer);
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            //Returni Status 201 que significa created
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //Adiciona propriedades de um no outro
            Mapper.Map(customerDto, customerDb);

            _context.SaveChanges();

        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerDb);
            _context.SaveChanges();

        }
    }
}
