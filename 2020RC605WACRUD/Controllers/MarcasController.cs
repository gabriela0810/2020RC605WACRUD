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
    public class MarcasController : ControllerBase
    {
        private readonly prestamosContext _context;

        public MarcasController(prestamosContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("api/marcas")]
        public IActionResult Get()
        {
            IEnumerable<marca> list = from e in _context.marcas select e;

            if (list.Count() > 0)
            {
                return Ok(list);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("api/marcas/{id}")]

        public IActionResult Get(int id)
        {
            marca item = (from e in _context.marcas
                          where e.id_marcas == id
                          select e).FirstOrDefault();

            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("api/marca")]
        public IActionResult guardarEquipo([FromBody] marca item)
        {
            try
            {
                _context.marcas.Add(item);

                _context.SaveChanges();

                return Ok(item);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/marca")]
        public IActionResult updateEquipo([FromBody] marca item)
        {
            marca marca = (from e in _context.marcas
                           where e.id_marcas == item.id_marcas
                           select e).FirstOrDefault();

            if (marca is null)
            {
                return NotFound();
            }

            marca.nombre_marca = item.nombre_marca;
            marca.estados = item.estados;

            _context.Entry(marca).State = EntityState.Modified;
            _context.SaveChanges();


            return Ok(marca);
        }
    }
}
