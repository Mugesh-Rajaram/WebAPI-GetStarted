using System.Data;
using System.Web.Http;
using WebAPIGetStarted.Common;

namespace WebAPIGetStarted.Controllers
{
    [MyControllerConfig]
    public class TestSampleController : ApiController
    {
        // GET: api/TestSample
        public DataSet Get()
        {
            DataSet resultSet = SQLConnectivity.GetData();

            //return Content(HttpStatusCode.OK, resultSet, Configuration.Formatters.XmlFormatter);// 
            return resultSet;
        }

        // GET: api/TestSample/5
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
