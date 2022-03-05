using _2020RC605WACRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace _2020RC605WACRUD.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EstadoEquipoController : ControllerBase
    {
        private readonly prestamosContext _context;

        public EstadoEquipoController(prestamosContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("api/estados_equipo")]
        public IActionResult Get()
        {
            IEnumerable<estados_equipo> list = from e in _context.estados_equipo select e;

            if (list.Count() > 0)
            {
                return Ok(list);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("api/estados_equipo/{id}")]

        public IActionResult Get(int id)
        {
            estados_equipo item = (from e in _context.estados_equipo
                                   where e.id_estados_equipo == id
                                   select e).FirstOrDefault();

            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("api/estados_equipo")]
        public IActionResult guardarEquipo([FromBody] estados_equipo item)
        {
            try
            {
                _context.estados_equipo.Add(item);

                _context.SaveChanges();

                return Ok(item);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/estados_equipo")]
        public IActionResult updateEquipo([FromBody] estados_equipo item)
        {
            estados_equipo data = (from e in _context.estados_equipo
                                   where e.id_estados_equipo == item.id_estados_equipo
                                   select e).FirstOrDefault();

            if (data is null)
            {
                return NotFound();
            }

            data.descripcion = item.descripcion;
            data.estado = item.estado;

            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();


            return Ok(data);
        }
    }
}
