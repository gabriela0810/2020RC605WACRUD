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
    public class equiposController : ControllerBase
    {
        private readonly prestamosContext _context;

        public equiposController(prestamosContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("api/equipos")]
        public IActionResult Get()
        {
            IEnumerable<equipos> equiposList = from e in _context.equipos select e;

            if (equiposList.Count() > 0)
            {
                return Ok(equiposList);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("api/equipos/{id}")]

        public IActionResult Get(int id)
        {
            equipos equipo = (from e in _context.equipos
                              where e.id_equipos == id
                              select e
                                                ).FirstOrDefault();

            if (equipo != null)
            {
                return Ok(equipo);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/equipo")]
        public IActionResult guardarEquipo([FromBody] equipos equipoNuevo)
        {
            try
            {
                _context.equipos.Add(equipoNuevo);
                _context.SaveChanges();
                return Ok(equipoNuevo);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/equipos")]
        public IActionResult updateEquipo([FromBody] equipos equipoAModificar)
        {
            //Para actualizar un registro, se obtiene el regitro original de la base de datos
            equipos equipoExiste = (from e in _context.equipos
                                    where e.id_equipos == equipoAModificar.id_equipos
                                    select e).FirstOrDefault();

            if (equipoExiste is null)
            {
                //Si no existe el registro de retorna un NO ENCONTRADO
                return NotFound();
            }

            //Si se encuentra el registro, se alteran los campos a modificar
            equipoExiste.nombre = equipoAModificar.nombre;
            equipoExiste.descripcion = equipoAModificar.descripcion;

            //Se envia el objeto a la base de datos
            _context.Entry(equipoExiste).State = EntityState.Modified;
            _context.SaveChanges();


            return Ok(equipoExiste);

        }
    }
}
