using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrestamosFIM.Core.Entities;
using PrestamosFIM.Core.Utils;
using PrestamosFIM.Infrastructure;
using PrestamosFIM.Infrastructure.Repository;

namespace PrestamosFIM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivosController : ControllerBase
    {
        private readonly IRepository<Activo> _repository;

        public ActivosController(IRepository<Activo> repository)
        {
            _repository = repository;
        }

        // GET: api/Activos
        [HttpGet]
        public Wrapper<IEnumerable<Activo>> GetActivos()
        {
            Wrapper<IEnumerable<Activo>> wrapper = new Wrapper<IEnumerable<Activo>>();
            wrapper.Success = true;
            wrapper.Result = _repository.GetAll();
            return wrapper;
        }

        // GET: api/Activos/5
        [HttpGet("{id}")]
        public Wrapper<IEnumerable<Activo>> GetActivo(int id)
        {
            Wrapper<IEnumerable<Activo>> wrapper = new Wrapper<IEnumerable<Activo>>();
            
            var activoBuscado = _repository.Find(activo => activo.IdActivo == id);

            if (activoBuscado == null)
            {
                wrapper.Success = false;
            }

            wrapper.Result = activoBuscado;

            return wrapper;
        }

        // PUT: api/Activos/5
        [HttpPut("{id}")]
        public Wrapper<Activo> PutActivo(int id, Activo activo)
        {
            Wrapper<Activo> wrapper = new Wrapper<Activo>();

            if (id != activo.IdActivo)
            {
                wrapper.Success = false;
            }
            else
            {
                wrapper.Success = true;
                _repository.Edit(activo);
                _repository.Save();
                wrapper.Result = activo;
            }

            return wrapper;
        }

        // POST: api/Activos
        [HttpPost]
        public Wrapper<Activo> PostActivo(Activo activo)
        {
            Wrapper<Activo> wrapper = new Wrapper<Activo>();
            _repository.Add(activo);
            _repository.Save();

            wrapper.Success = true;
            wrapper.Result = activo;

            return wrapper;

        }

        // DELETE: api/Activos/5
        [HttpDelete("{id}")]
        public Wrapper<Activo> DeleteActivo(int id)
        {
            Wrapper<Activo> wrapper = new Wrapper<Activo>();

            if (_repository.Find(activo => activo.IdActivo == id) == null)
            {
                wrapper.Success = false;
            }
            else
            {
                wrapper.Success = true;
            }

            return wrapper;
        }
    }
}
