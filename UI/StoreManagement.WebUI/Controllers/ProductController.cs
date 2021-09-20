using Foundation.Abstraction.Repository;
using Foundation.Abstraction.Service;
using Foundation.Contract;
using Foundation.Dto;
using Microsoft.AspNetCore.Mvc;
using OVM.Jobs.Schedules;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.WebUI.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        readonly IProductService _productService;
        readonly ICustomerService _customerService;
        public ProductController(IProductService productService, ICustomerService customerServic)
        {
            _productService = productService;
            _customerService = customerServic;
        }

        public IActionResult Index(int? page)
        {
            var result = _productService.GetAll();
            return View(result);
        }

        [HttpGet]
        [Route("save/{id:int}")]
        public IActionResult Get(int id)
        {
            var model = new ProductContract();

            if (id==0)
                return View("Form", model);

            model = _productService.Get(id);
            return View("Form", model);
        }

        [HttpPost]
        [Route("save")]
        public ActionResult Add(ProductContract product)
        {
            _productService.Add(product);

            var customers = _customerService.GetAll();

            List<string> toEmails = customers.Select(x => x.Email).ToList();

            FireAndForgetJobs.NewProductSendMail(new MailDto { ToEmailss = toEmails }, product);

            return RedirectToAction("Index", "Product");
        }

        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            _productService.Delete(id);
            FireAndForgetJobs.CartCheck(id);
            return RedirectToAction("Index", "Product");
        }
    }
}
