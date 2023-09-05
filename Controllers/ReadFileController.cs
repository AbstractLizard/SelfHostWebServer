namespace SelfHostWebServer.Controllers
{
    using SelfHostWebServer.Service;
    using System;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;

    public class ReadFileController : ApiController
    {
        private ReadFileService _readFileService;

        private ReadFileService ReadFileService
        {
            get 
            { 
                if(_readFileService == null)
                {
                    _readFileService = new ReadFileService();
                }
                return _readFileService;
            }
        }

        [HttpGet,Route("Test")]
        public async Task<IHttpActionResult> Test()
        {
            var returnData = new { w = "test"};

            return Json(returnData);
        }

        [Route("GetData/{fileName}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDataFromFileAsync(string fileName)
        {
            var returnData = await ReadFileService.GetObjectFromFileAsync(fileName);

            return Json(returnData);
        }
    }
}
