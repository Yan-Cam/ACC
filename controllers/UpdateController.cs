using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using aac.service;
using aac.entity;
using Newtonsoft.Json.Linq;

namespace aac.controllers
{
    [Route("api/[controller]")]
    public class UpdateController : Controller
    {
        private readonly ILogger<UpdateController> _logger;

        public UpdateController(ILogger<UpdateController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult update([FromBody] ContactModel model) {
            UpdateService service = new UpdateService();
            String NewString = "";
            String NewJson = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            if (string.IsNullOrEmpty(NewJson))
            {
                NewString = "{\"msg\":\"保存失败\"}";
            }
            else {
                NewString = "{\"msg\":\"保存成功\"}";
                service.update(NewJson);
            }
             return new ContentResult { Content = NewJson, ContentType = "application/json" };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        public class row {
            public int uid {get;set;}
            public String name {get;set;}
            public String phone {get;set;}
            public String wechat {get;set;}
            public String qq {get;set;}
            public String address {get;set;}
        }

        public class ContactModel {
            public List<row> rows {get; set;}
        }
    }
}