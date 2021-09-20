using Foundation.Abstraction.Service;
using Foundation.Contract;
using Microsoft.AspNetCore.Mvc;
using OVM.Jobs.Schedules;

namespace StoreManagement.WebUI.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        readonly ICustomerService _CustomerService;
        public CustomerController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        public IActionResult Index(int? page)
        {
            var result = _CustomerService.GetAll();
            return View(result);
        }

        [HttpGet]
        [Route("save/{id:int}")]
        public IActionResult Get(int id)
        {
            var model = new CustomerContract();

            if (id == 0)
                return View("Form", model);

            model = _CustomerService.Get(id);
            return View("Form", model);
        }

        [HttpPost]
        [Route("save")]
        public ActionResult Add(CustomerContract Customer)
        {
           var entty = _CustomerService.Add(Customer);

            DelayedJobs.NewCustomerSendMail(entty.Id);
            return RedirectToAction("Index", "Customer");
        }

        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            _CustomerService.Delete(id);

            return RedirectToAction("Index", "Customer");
        }
    }
}
