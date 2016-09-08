using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestWebAPIApp.Services;
using TestWebAPIApp.Models;

namespace TestWebAPIApp.Controllers
{
    public class HomeController : ApiController
    {
        [Route("api/home")]
        public HttpResponseMessage Get(string path)
        {
            DataStruct data = new DataStruct();
            data.files = null;
            data.subDirs = null;
            data.less10 = 0;
            data.beetwen = 0;
            data.more50 = 0;
            System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(path);
            try{
                WalkDirectoryTreeClass.WalkDirectoryTree(root, ref data);
            }
            catch (Exception e) {
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

    }
}
