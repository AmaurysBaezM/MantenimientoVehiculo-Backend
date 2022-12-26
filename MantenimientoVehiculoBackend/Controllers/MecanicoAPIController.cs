using MantenimientoVehiculoBackend.Data;
using MantenimientoVehiculoBackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MantenimientoVehiculoBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]



    public class MecanicoAPIController : Controller

    {
        private readonly DbMantenimientoContext dbMantenimientoContext;


        private readonly ILogger  _logger;


        public MecanicoAPIController(DbMantenimientoContext dbMantenimientoContext)
        {
           
            this.dbMantenimientoContext = dbMantenimientoContext;
        }

        
        // GET: api/<MecanicoAPIController>
        [HttpGet]
        public List<Mecanico> Get()
        {
            return dbMantenimientoContext.Mecanico.ToList();
        }

        // GET api/<MecanicoAPIController>/5
        [HttpGet("{id}")]
        public string GetById(int id)
        {
            return "hola amigos";
        }

        // POST api/<MecanicoAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] Mecanico mecani)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbMantenimientoContext.Mecanico.Add(mecani);
                    int resultado = dbMantenimientoContext.SaveChanges();

                    if (resultado == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return Ok(mecani.IdMecanico);
                    }

                }
                return NotFound();


            }
            catch (System.Exception ex)
            {
                var error = ex.Message;
                Console.WriteLine(error);
                return BadRequest(error);

            }

        }
        // PUT api/<MecanicoAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MecanicoAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
