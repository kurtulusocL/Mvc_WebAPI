using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class LessonsController : ApiController
    {
        private string[] lessonList = { "MVC", "CSS", "C#", "JavaScript", "EntityFramework", "WebAPI" };
        public string[] Get()
        {
            return lessonList;
        }
        public string Get(int id)
        {
            return lessonList[id];
        }
    }
}
