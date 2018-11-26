using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        //Customers
        // GET: Customer
        public ActionResult Index()
        {
            var customers = new CustomersViewModel();

            customers.Costumers = new List<Customer>
            {
                new Customer{Name = "Renan", Id = 1},
                new Customer{Name = "Marcos", Id = 2}

            };

            return View(customers);
        }

        //Customers/details
        public ActionResult Details(int id)
        {

            var customer = new Customer();

            switch (id)
            {
                case 1:
                    customer.Name = "Renan";
                    break;
                case 2:
                    customer.Name = "Marcos";
                    break;
                default: return HttpNotFound();

            }
            return View(customer);
        }
    }
}