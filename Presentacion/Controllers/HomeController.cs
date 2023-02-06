using Datos.DbUsuarios;
using Datos.Modelos;
using Microsoft.AspNetCore.Mvc;
using Negocios.Service;
using Presentacion.Models;
using System.Diagnostics;
using System.Globalization;

namespace Presentacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioService usuService;

        public HomeController(IUsuarioService usuService)
        {
            this.usuService = usuService;
        }

        public IActionResult Usuario()
        {
            return View("Usuario");
        }
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            IQueryable<Usuario> queryUsuarioSQL = await usuService.ObtTodos();

            List<VMUsuario>lista = queryUsuarioSQL.Select(c => new VMUsuario()
            {
                IdUsuario = c.IdUsuario,
                Nombre = c.Nombre,
                FechaNac = c.FechaNac.Value.ToString("dd/MM/yyyy"),
                Sexo = c.Sexo
            }).ToList();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMUsuario modelo)
        {
            Console.Write("entro");
            Usuario nuevoRegistro = new Usuario()
            {
                Nombre = modelo.Nombre,
                FechaNac = DateTime.ParseExact(modelo.FechaNac, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-CO")),
                Sexo = modelo.Sexo
            };
            bool resultado = await usuService.Insertar(nuevoRegistro);
            return StatusCode(StatusCodes.Status200OK, new { valor = resultado });
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMUsuario modelo)
        {
            Usuario nuevoRegistro = new Usuario()
            {
                IdUsuario = modelo.IdUsuario,
                Nombre = modelo.Nombre,
                FechaNac = DateTime.ParseExact(modelo.FechaNac, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-CO")),
                Sexo = modelo.Sexo
            };
            bool resultado = await usuService.Actualizar(nuevoRegistro);
            return StatusCode(StatusCodes.Status200OK, new { valor = resultado });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool resultado = await usuService.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, new { valor = resultado });
        }

        public IActionResult UsuarioConsulta()
        {
            return View("UsuarioConsulta");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}