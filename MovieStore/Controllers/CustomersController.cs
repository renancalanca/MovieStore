using MovieStore.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using MovieStore.ViewModels;
using System;
using System.Data.Entity.Validation;

namespace MovieStore.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        //Construtor
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Customers
        // GET: Customer
        [HttpGet]
        public ActionResult Index()
        {
            //O include é utilizado para incluir o objeto relacionado com o Customer que é o MembershipType
            var customer = _context.Customers.Include(c => c.MembershipType).ToList();

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //Customers/details
        public ActionResult Details(int id)
        {
            //Buscar customer por ID usando o lambda
            var customer = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            //Caso a View não tenha o mesmo nome da Action voce pode passar os seguintes parametros no retorno para especificar qual View é.
            return View("CustomerForm", viewModel);
        }

        /*
         * Post usado para criar e editar
         */
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            try
            {
                //Pelo fato de eu estar usando um validator no Model é necessário usar esse IF

                if (!ModelState.IsValid)
                {
                    var viewModel = new CustomerFormViewModel
                    {
                        Customer = customer,
                        MembershipTypes = _context.MembershipTypes.ToList()
                    };

                    return View("CustomerForm", viewModel);
                }
                if (customer.Id == 0)
                {
                    _context.Customers.Add(customer);
                }
                else
                {
                    var customerEdit = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                    customerEdit.Name = customer.Name;
                    customerEdit.Birth = customer.Birth;
                    customerEdit.MembershipTypeId = customer.MembershipTypeId;
                    customerEdit.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

                }
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return RedirectToAction("Index", "Customers");
            //Ao salvar voce da o redirect para a pagina Index
            //RedirectToAction(Action, ControllerName)

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}