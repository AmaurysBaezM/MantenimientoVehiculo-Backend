using MantenimientoVehiculoBackend.Data;
using MantenimientoVehiculoBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MantenimientoVehiculoBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class ClienteAPIController : Controller
    {
        private readonly DbMantenimientoContext dbMantenimientoContext;

        public ClienteAPIController(DbMantenimientoContext dbNoticiasContext)
        {
            int hola = 10;
            this.dbMantenimientoContext = dbNoticiasContext;

        }
        // GET: api/<ClienteAPIController>
        [HttpGet]
        public List<Cliente> Get()
        {
            return dbMantenimientoContext.Clientes.ToList();
        }

        // GET api/<ClienteAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClienteAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                     dbMantenimientoContext.Clientes.Add(cliente);
                    int resultado = dbMantenimientoContext.SaveChanges();

                    if (resultado == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return Ok(cliente.IdCliente);
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

        // PUT api/<ClienteAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
