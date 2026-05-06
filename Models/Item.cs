/*
 * Atributos:
 * ----------
 * Titulo : string
 * Título del videojuego.
 *
 * Genero : string
 * Clasificación temática (RPG, FPS, Plataforma, etc.).
 *
 * Anio : int
 * Año de salida al mercado.
 *
 * Consola : string
 * Plataforma o sistema original.
 *
 * Descripcion : string
 * Breve reseña sobre la historia o jugabilidad.
 */

namespace Catalogo.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Genero { get; set; } = string.Empty;

        public int Ano { get; set; }

        public string Consola { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;
    }
}