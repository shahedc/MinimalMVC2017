using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinimalMVC2017.Models;
using MinimalMVC2017.Services;

namespace MinimalMVC2017.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Process(CalcViewModel model)
        {
            var cs = new CalcService();
            var result = cs.AddNumbers(model.Number1, model.Number2);
            model.Result = result;
            return View(model);
        }
    }
}
