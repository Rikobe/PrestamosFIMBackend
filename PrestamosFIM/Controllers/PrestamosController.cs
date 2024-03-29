﻿using System;
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
using Newtonsoft.Json;

namespace PrestamosFIM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        private readonly IRepository<Prestamo> _prestamoRepository;
        private readonly IRepository<DetallePrestamo> _detallePrestamoRepository;
        private readonly PrestamosFIMContext _context;

        public PrestamosController(IRepository<Prestamo> prestamoRepository, IRepository<DetallePrestamo> detallePrestamoRepository, PrestamosFIMContext context)
        {
            _prestamoRepository = prestamoRepository;
            _detallePrestamoRepository = detallePrestamoRepository;
            _context = context;
        }

        // GET: api/Prestamos
        [HttpGet]
        public IActionResult GetPrestamo()
        {     
            Wrapper<IList<Prestamo>> wrapper = new Wrapper<IList<Prestamo>>();
            try
            {     
                wrapper.Result = _prestamoRepository.GetAll()
                    .Include(dp => dp.DetallePrestamo)
                    .ThenInclude(x => x.IdActivoNavigation).ToList();
                wrapper.Success = true;
            }
            catch (Exception e)
            {
                wrapper.Success =false;
            }
            return Ok(wrapper);
        }

        // GET: api/Prestamos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prestamo>> GetPrestamo(int id)
        {
            var prestamo = await _context.Prestamo.FindAsync(id);

            if (prestamo == null)
            {
                return NotFound();
            }

            return prestamo;
        }

        // PUT: api/Prestamos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrestamo(int id, Prestamo prestamo)
        {
            if (id != prestamo.IdPrestamo)
            {
                return BadRequest();
            }

            _context.Entry(prestamo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestamoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Prestamos
        [HttpPost]
        public async Task<ActionResult<Prestamo>> PostPrestamo(Prestamo prestamo)
        {
            _context.Prestamo.Add(prestamo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrestamoExists(prestamo.IdPrestamo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPrestamo", new { id = prestamo.IdPrestamo }, prestamo);
        }

        // DELETE: api/Prestamos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prestamo>> DeletePrestamo(int id)
        {
            var prestamo = await _context.Prestamo.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            _context.Prestamo.Remove(prestamo);
            await _context.SaveChangesAsync();

            return prestamo;
        }

        private bool PrestamoExists(int id)
        {
            return _context.Prestamo.Any(e => e.IdPrestamo == id);
        }
    }
}
