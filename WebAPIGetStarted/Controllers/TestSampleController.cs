using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPIGetStarted.Common;

namespace WebAPIGetStarted.Controllers
{
    //[MyControllerConfig]
    //[RoutePrefix("api/test")]
    [EnableCors("*", "*", "*")]
    public class TestSampleController : ApiController
    {
        // GET: api/TestSample
        [Route("ssql")]
        public IHttpActionResult Get()
        {
            DataSet resultSet = SQLConnectivity.GetData();

            //return Content(HttpStatusCode.OK, resultSet, Configuration.Formatters.XmlFormatter);// 
            dfasdfasd;
            return Ok(resultSet);
        }

        [HttpGet, Route("str")]
        public string GetData()
        {
            return "Success";
        }

        // GET: api/TestSample/5
        [HttpGet, Route("val/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TestSample
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TestSample/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TestSample/5
        public void Delete(int id)
        {
        }
    }
}
