using ApiCorePersonajesSeries.Models;
using ApiCorePersonajesSeries.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCorePersonajesSeries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryApi repo;
        public PersonajesController(RepositoryApi repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> Get()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> FindPersonajes(int id)
        {
            return await this.repo.FindPersonajeAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> InsertPersonaje(Personaje personaje)
        {
            await this.repo.InsertarPersonajeAsync(personaje.Nombre, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePersonaje(Personaje personaje)
        {
            await this.repo.UpdatePersonajeAsync(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePersonaje(int id)
        {
            await this.repo.DeletePersonajeAsync(id);
            return Ok();
        }

        [HttpGet("/Series/{serie}")]
        public async Task<ActionResult<List<Personaje>>> PersonajesSerie(int serie)
        {
            return await this.repo.PersonajesSeriesAsync(serie);
        }
    }
}
