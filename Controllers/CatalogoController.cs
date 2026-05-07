using Catalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers { 

    public class CatalogoController : Controller
{
        private static List<Item> _items = new()
        {
             new Item {
                   Id = 1,
                Titulo = "Devil May Cry",
                Genero = "Hack and Slash",
                Ano = 2001,
                Consola = "PlayStation 2",
                Descripcion = "Videojuego que trata de un cazador ..."
            },

            new Item {
                Id = 2,
                Titulo = "Castlevania: Symphony of the Night",
                Genero = "Metroidvania",
                Ano = 1997,
                Consola = "PlayStation 2",
                Descripcion = "Videojuego de exploración en el castillo de Drácula"
             },

            new Item {
                Id = 3,
                Titulo = "NieR: Automata",
                Genero = "Action RPG",
                Ano = 2017,
                Consola = "PlayStation 4",
                Descripcion = "Historia de androides en guerra contra máquinas"
            },

            new Item {
                Id = 4,
                Titulo = "Silent Hill",
                Genero = "Terror Psicológico / Survival Horror",
                Ano = 1999,
                Consola = "PlayStation",
                Descripcion = "Videojuego de terror psicológico donde Harry Mason explora el misterioso pueblo de Silent Hill en busca de su hija desaparecida. Destaca por su atmósfera oscura, niebla intensa y narrativa inquietante."
            },

            new Item {
                Id = 5,
                Titulo = "Castlevania: Order of Ecclesia",
                Genero = "Acción / Plataforma / Metroidvania",
                Ano = 2008,
                Consola = "Nintendo DS",
                Descripcion = "Juego de acción donde Shanoa utiliza poderosos Glyphs para enfrentar monstruos y detener el regreso de Drácula. Es reconocido por su dificultad y ambientación gótica."
             },

            new Item {
                Id = 6,
                Titulo = "Dante's Inferno",
                Genero = "Acción / Hack and Slash",
                Ano = 2010,
                Consola = "PlayStation 3 / Xbox 360",
                Descripcion = "Videojuego inspirado en La Divina Comedia de Dante Alighieri. El jugador desciende por los nueve círculos del infierno enfrentando criaturas demoníacas para rescatar a Beatrice."
            },
        };

    // Lista - con filtro opcional por genero
        public IActionResult Index(string? genero)
        {
            var resultado = string.IsNullOrEmpty(genero)
                 ? _items
                : _items.Where(i => i.Genero == genero).ToList();

            ViewBag.Generos = _items.Select(i => i.Genero).Distinct().ToList();
            ViewBag.GeneroActual = genero;

            return View(resultado);
         }

    // Detalle
        public IActionResult Detalle(int id)
        {
             var item = _items.FirstOrDefault(i => i.Id == id);
             return item == null ? NotFound() : View(item);
        }

    // Formulario - GET
         public IActionResult Agregar()
        {
            return View();
        }

    // Formulario - POST
         [HttpPost]
         public IActionResult Agregar(Item item)
         {
             item.Id = _items.Count + 1;
             _items.Add(item);
             return RedirectToAction("Index");
         }
    }
}