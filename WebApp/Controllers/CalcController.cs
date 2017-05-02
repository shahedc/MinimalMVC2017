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

        public ActionResult FunctionCaller()
        {
            return View("FunctionCaller");
        }

        [HttpPost]
        public ActionResult Process(CalcViewModel model, string operation)
        {
            var cs = new CalcService();
            model.Operation = operation;
            var result = 0;
            bool boolResult1 = false;
            bool boolResult2 = false;

            if (operation == "Add")
            {
                result = cs.AddNumbers(model.Number1, model.Number2);
            } else if (operation == "Subtract")
            {
                result = cs.SubtractNumbers(model.Number1, model.Number2);
            }
            else if (operation == "Multiply")
            {
                result = cs.MultiplyNumbers(model.Number1, model.Number2);
            }
            else if (operation == "Divide")
            {
                result = cs.SafeDivide(model.Number1, model.Number2);
            }
            else if (operation == "CheckEven")
            {
                boolResult1 = cs.IsEven(model.Number1);
                boolResult2 = cs.IsEven(model.Number2);
            }
            else if (operation == "CheckOdd")
            {
                boolResult1 = !(cs.IsEven(model.Number1));
                boolResult2 = !(cs.IsEven(model.Number2));
            }

            model.Result = result;
            model.boolResult1 = boolResult1;
            model.boolResult2 = boolResult2;
            return View(model);
        }
    }
}
