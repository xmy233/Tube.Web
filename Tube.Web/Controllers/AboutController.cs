using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tube.Web.Controllers
{
    //About/me

    [Route("v2/[controller]/[action]")]
    public class AboutController
    {
       // [Route("")]
        public string Me()
        {
            return "Deve";
        }

        //[Route("Company")]
        public string Company()
        {
            return "No Company";
        }
    }
}
