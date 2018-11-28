using MovieStore.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using MovieStore.ViewModels;

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
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        /*
         * Post usado para criar e editar
         */
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();


            //Ao salvar voce da o redirect para a pagina Index
            //RedirectToAction(Action, ControllerName)
            return RedirectToAction("Index", "Customers") ;
        }
    }
}