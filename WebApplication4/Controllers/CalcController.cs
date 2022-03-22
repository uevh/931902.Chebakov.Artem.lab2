using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class CalcController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public CalcController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Manual()
        {

            if (Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                Example exam = new Example();
                if (Request.Form["Number1"] != "" && Request.Form["Number2"] != "")
                {
                    exam.Number1 = Int32.Parse(Request.Form["Number1"]);
                    exam.Number2 = Int32.Parse(Request.Form["Number2"]);
                    exam.Operation = Request.Form["operation"];
                    exam.Get_Result();
                    
                    
                }
                else
                    exam.Result = "Error:INVALIDE INPUT";

                ViewBag.Result = exam.Result;
                return View("Result");
            }
            else
                return View();

          
        }

        [HttpGet]
        public IActionResult ManualParsingInSeparate()
        {
            return View();
        }
        [HttpPost, ActionName("ManualParsingInSeparate")]
        public IActionResult ManualParsingInSeparatePost()
        {
            Example exam = new Example();
            if (Request.Form["Number1"] != "" && Request.Form["Number2"] != "")
            {
                exam.Number1 = Int32.Parse(Request.Form["Number1"]);
                exam.Number2 = Int32.Parse(Request.Form["Number2"]);
                exam.Operation = Request.Form["operation"];
                exam.Get_Result();
                
            }
            else
                exam.Result = "Error:INVALIDE INPUT";

            ViewBag.Result = exam.Result;
            return View("Result");
        }
        [HttpGet]
        public IActionResult ModelBindingInParameters()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ModelBindingInParameters(int Number1, int Number2, string Operation)
        {
            Example exam = new Example();
            
            exam.Number1 = Number1;
            exam.Number2 = Number2;
            exam.Operation = Operation;
            exam.Get_Result();
            ViewBag.Result = exam.Result;
            return View("Result");
        }

        [HttpGet]
        public IActionResult ModelBindingInSeparateModel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModelBindingInSeparateModel(Example exam)
        {
            exam.Get_Result();
            ViewBag.Result = exam.Result;
            return View("Result");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

