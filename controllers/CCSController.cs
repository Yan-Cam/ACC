using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using aac.entity;
using aac.service;
using Newtonsoft;
namespace aac
{
    [Route("api/[controller]")]
    public class CCSController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<CCSController> _logger;

        public CCSController(ILogger<CCSController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult List()
        {
            CCSClass ccsService = new CCSClass(); 
            List<ContactClass> list = ccsService.FindAllByPage();
            String NewJSON = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            NewJSON = "{\"total\":"+list.Count+",\"rows\":"+NewJSON+"}";
            // Json aa = Json("{total = list.Count()}", );
            // return 
            return new ContentResult { Content = NewJSON, ContentType = "application/json" };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}