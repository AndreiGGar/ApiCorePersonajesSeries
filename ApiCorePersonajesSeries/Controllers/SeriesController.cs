using ApiCorePersonajesSeries.Models;
using ApiCorePersonajesSeries.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace ApiCorePersonajesSeries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private RepositoryApi repo;
        public SeriesController(RepositoryApi repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Serie>>> Get()
        {
            return await this.repo.GetSeriesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Serie>> FindSerie(int id)
        {
            return await this.repo.FindSerieAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> InsertSerie(Serie serie)
        {
            await this.repo.InsertarSerieAsync(serie.Nombre, serie.Imagen, serie.Puntuacion, serie.Anyo);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSerie(Serie serie)
        {
            await this.repo.UpdateSerieAsync(serie.IdSerie, serie.Nombre, serie.Imagen, serie.Puntuacion, serie.Anyo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSerie(int id)
        {
            await this.repo.DeleteSerieAsync(id);
            return Ok();
        }
    }
}
