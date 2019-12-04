using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrestamosFIM.Core;
using PrestamosFIM.Core.Utils;
using PrestamosFIM.Infrastructure;

namespace PrestamosFIM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly PrestamosFIMContext _context;

        public ValuesController (PrestamosFIMContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public Wrapper<IEnumerable<Activo>> Get()
        {
            IQueryable<Activo> entity = _context.Activo;
            Wrapper<IEnumerable<Activo>> wrapper = new Wrapper<IEnumerable<Activo>>();
            wrapper.Success = true;
            wrapper.Result = entity;
            return wrapper;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
