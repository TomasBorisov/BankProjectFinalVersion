using System.Linq;
using CRUD_Operations.Models;
using Microsoft.AspNetCore.Mvc;
namespace AdminPanelTutorial
{
    public class DoctorsController : Controller
    {
        MyDbContext db = new MyDbContext();
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDoctor(Customers customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                Customers customer = db.Customers.Where(s => s.Id == id).First();
                db.Customers.Remove(customer);
                db.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }

        }
        public ActionResult Update(int id)
        {
            return View(db.Customers.Where(s => s.Id == id).First());
        }
        [HttpPost]
        public ActionResult UpdateCustomer(Customers customer)
        {
            Customers d = db.Customers.Where(s => s.Id == customer.Id).First();
            d.Name = customer.Name;
            d.Phone = customer.Phone;
            //d.Specialist = customer.Specialist;
            db.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}