using Microsoft.AspNetCore.Mvc;
using MantenimientoVehiculoBackend.Data;
using MantenimientoVehiculoBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MantenimientoVehiculoBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class VehiculoAPIController : ControllerBase
    {

        private readonly DbMantenimientoContext dbMantenimientoContext;

        public VehiculoAPIController(DbMantenimientoContext dbNoticiasContext)
        {
            this.dbMantenimientoContext = dbNoticiasContext;

        }


            // GET: api/<VehiculoAPIController>
        [HttpGet]
        public List<Vehiculo> Get()
        {
            return dbMantenimientoContext.Vehiculos.ToList();
        }

        // GET api/<VehiculoAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VehiculoAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VehiculoAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VehiculoAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
