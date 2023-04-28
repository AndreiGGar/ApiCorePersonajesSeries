using ApiCorePersonajesSeries.Context;
using ApiCorePersonajesSeries.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ApiCorePersonajesSeries.Repositories
{
    public class RepositoryApi
    {
        private DataContext context;

        public RepositoryApi(DataContext context)
        {
            this.context = context;
        }

        #region Series

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        public async Task<Serie> FindSerieAsync(int id)
        {
            return await this.context.Series.FirstOrDefaultAsync(x => x.IdSerie == id);
        }

        private int GetMaxIdSerie()
        {
            if (this.context.Series.Count() == 0)
            {
                return 1;
            } else
            {
                return this.context.Series.Max(x => x.IdSerie) + 1;
            }
        }

        public async Task InsertarSerieAsync(string nombre, string imagen, double puntuacion, int anyo)
        {
            Serie serie = new Serie();
            serie.IdSerie = GetMaxIdSerie();
            serie.Nombre = nombre;
            serie.Imagen = imagen;
            serie.Puntuacion = puntuacion;
            serie.Anyo = anyo;
            this.context.Series.Add(serie);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateSerieAsync(int id, string nombre, string imagen, double puntuacion, int anyo)
        {
            Serie serie = await this.FindSerieAsync(id);
            serie.Nombre = nombre;
            serie.Imagen = imagen;
            serie.Puntuacion = puntuacion;
            serie.Anyo = anyo;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteSerieAsync(int id)
        {
            Serie serie = await this.FindSerieAsync(id);
            this.context.Series.Remove(serie);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region Personajes

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }

        private int GetMaxIdPersonaje()
        {
            if (this.context.Personajes.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Personajes.Max(x => x.IdPersonaje) + 1;
            }
        }

        public async Task InsertarPersonajeAsync(string nombre, string imagen, int idserie)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = GetMaxIdPersonaje();
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idserie;
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonajeAsync(int id, string nombre, string imagen, int idserie)
        {
            Personaje personaje = await this.FindPersonajeAsync(id);
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idserie;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonajeAsync(int id)
        {
            Personaje personaje = await this.FindPersonajeAsync(id);
            this.context.Personajes.Remove(personaje);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<Personaje>> PersonajesSeriesAsync(int id)
        {
            return await this.context.Personajes.Where(x => x.IdSerie == id).ToListAsync();
        }

        #endregion
    }
}
