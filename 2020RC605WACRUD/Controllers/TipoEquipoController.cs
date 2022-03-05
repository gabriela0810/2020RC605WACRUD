using _2020RC605WACRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace _2020RC605WACRUD.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TipoEquipoController : ControllerBase
    {
        private readonly prestamosContext _context;

        public TipoEquipoController(prestamosContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("api/tipoEquipos")]
        public IActionResult Get()
        {
            IEnumerable<tipo_equipo> list = from e in _context.tipo_equipo select e;

            if (list.Count() > 0)
            {
                return Ok(list);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("api/tipoEquipos/{id}")]

        public IActionResult Get(int id)
        {
            tipo_equipo item = (from e in _context.tipo_equipo
                                where e.id_tipo_equipo == id
                                select e).FirstOrDefault();

            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("api/tipoEquipo")]
        public IActionResult guardarEquipo([FromBody] tipo_equipo item)
        {
            try
            {
                _context.tipo_equipo.Add(item);

                _context.SaveChanges();

                return Ok(item);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/tipoEquipos")]
        public IActionResult updateEquipo([FromBody] tipo_equipo item)
        {
            tipo_equipo data = (from e in _context.tipo_equipo
                                where e.id_tipo_equipo == item.id_tipo_equipo
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
