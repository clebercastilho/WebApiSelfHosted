using BusinessAccess;
using System.Net.Http;
using System.Web.Http;

namespace WebApiSelfHost.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Route("{login}")]
        public HttpResponseMessage Get(string login)
        {
            HttpResponseMessage response = null;

            var result = Usuarios.GetUserByLogin(login).Match(
                success: user => response = Request.CreateResponse(System.Net.HttpStatusCode.OK, user),
                failure: notifier => response = Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, notifier.ToString())
            );

            return response;
        }
    }
}
