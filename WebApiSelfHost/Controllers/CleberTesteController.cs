using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net;
using BusinessAccess;
using ExceptionContainer;

namespace WebApiSelfHost.Controllers
{
    public class CleberTesteController : ApiController
    {
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response = null;

            var message = Hello.GetHelloType(id).Match(
                success: result => response = Request.CreateResponse(HttpStatusCode.OK, result),
                failure: exception => response = Request.CreateResponse(HttpStatusCode.BadRequest, exception.Message
            ));

            return response;
        }
    }
}
