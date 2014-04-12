using MatchTrakr.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MatchTrakr.Web.Controllers
{
    public class BaseApiController : ApiController
    {
        private IMatchTrakrRepository _repo;

        protected IMatchTrakrRepository TheRepository
        {
            get
            {
                _repo = new MatchTrakrRepository();
                return _repo;
            }
        }
    }
}