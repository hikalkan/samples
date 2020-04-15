using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryBindingError.Controllers
{
    [Route("test")]
    public class TestController : Controller
    {
        //Request example: http://localhost:56820/test/test1?dict[2]=B&dict[5]=E
        [Route("test1")]
        public ActionResult Test1(Dictionary<int, string> dict)
        {
            return Content(string.Join(", ", dict.Select(v => v.Key + "=" + v.Value)));
        }

        //Request example: http://localhost:56820/test/test2?dict[A]=C&dict[B]=D
        [Route("test2")]
        public ActionResult Test2(Dictionary<string, object> dict)
        {
            return Content(string.Join(", ", dict.Select(v => v.Key + "=" + v.Value)));
        }
    }
}
