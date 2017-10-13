using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalSite.Models;
using System.Data.Entity;
using MovieRentalSite.ViewModels;

namespace MovieRentalSite.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customers
        public ActionResult Index()
        {   
            // dataTable sends AJAX request to customers api and gets the list of customers
            //var customers = _context.Customers.OrderBy(c => c.Name).Include(c => c.MembershipType).ToList();

            return View();
        }


        public ActionResult Details(int? id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }


        // Model Binding - b/c the model beind the view is CustomerFormViewModel, you can 
        // use CustomerFormViewModel (or Customer) and MVC will automatically map request 
        // data to this object
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            // ModelState accesses validation data
            // IsValid used to change app flow
            //var id = customer.Id;
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new CustomerFormViewModel
            //    {
            //        Customer = customer,
            //        MembershipTypes = _context.MembershipTypes.ToList()
            //    };

            //    return View("CustomerForm", viewModel);
            //}

            // HiddenFor in form provides the Id of the customer
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                // Used to update properties of the edited object - provide string array
                // of properties to be uptated 
                // TryUpdateModel(customerInDb, "", new string[] { "Name", "Email" });

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}
