using AutoMapper;
using MovieStore.Dto;
using MovieStore.Models;
using System;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using MovieStore.Models.IdentityModels;

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
        public IHttpActionResult GetCustomers(string query = null)
        {
            //Ao utilziar o SELECT dessa forma voce mapeia as propriedades do Customer para o DTO
            //var customer = _context.Customers.Include(c => c.MembershipType)
            //   .Select(Mapper.Map<Customer, CustomerDto>);

            //return Ok(customer);
            //return Ok(Mapper.Map<Customer,CustomerDto>(customer));


            //Depois do modulo 11
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!string.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);

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
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerDb == null)
                return NotFound();

            //Adiciona propriedades de um no outro  
            Mapper.Map(customerDto, customerDb);

            _context.SaveChanges();

            return Ok();

        }

        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerDb == null)
                return NotFound();

            _context.Customers.Remove(customerDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
