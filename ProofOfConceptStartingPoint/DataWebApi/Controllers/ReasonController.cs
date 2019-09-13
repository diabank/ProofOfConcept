using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataWebApi.Controllers
{
    /// <summary>
    /// Reason Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReasonController : ControllerBase
    {
        IReasonProvider provider;

        /// <summary>
        /// Constructor with DI
        /// </summary>
        /// <param name="provider"></param>
        public ReasonController(IReasonProvider provider)
        {
            this.provider = provider;
        }

        /// <summary>
        /// GET: api/Reason
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Reason> GetReasons()
        {
            return provider.GetReasonsFromStorage();
        }


        /// <summary>
        /// GET: api/Reason/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public Reason GetAReason(int id)
        {
            return provider.GetReasonsFromStorage().First(p => p.ReasonID == id);
        }
    }
}
