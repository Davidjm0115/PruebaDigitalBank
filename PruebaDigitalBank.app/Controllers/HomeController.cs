using Microsoft.AspNetCore.Mvc;
using PruebaDigitalBank.app.Models;
using PruebaDigitalBank.app.Models.ViewModels;
using PruebaDigitalBank.BLL.Service;
using PruebaDigitalBank.DAL.DataContext;
using System.Diagnostics;
using System.Globalization;

namespace PruebaDigitalBank.app.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public HomeController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.GetAllUsuarios();
            return View(usuarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VMUsuario vmUsuario)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    Nombre = vmUsuario.Nombre,
                    FechaNacimiento = vmUsuario.FechaNacimiento,
                    Sexo = vmUsuario.Sexo
                };

                await _usuarioService.InsertarUsuario(usuario);
                return RedirectToAction(nameof(Index));
            }

            return View(vmUsuario);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _usuarioService.GetUsuarioById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            var vmUsuario = new VMUsuario
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                FechaNacimiento = usuario.FechaNacimiento,
                Sexo = usuario.Sexo
            };

            return View(vmUsuario);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VMUsuario vmUsuario)
        {
            if (id != vmUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    Id = vmUsuario.Id,
                    Nombre = vmUsuario.Nombre,
                    FechaNacimiento = vmUsuario.FechaNacimiento,
                    Sexo = vmUsuario.Sexo
                };

                var result = await _usuarioService.ActualizarUsuario(usuario);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(vmUsuario);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _usuarioService.GetUsuarioById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            var vmUsuario = new VMUsuario
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                FechaNacimiento = usuario.FechaNacimiento,
                Sexo = usuario.Sexo
            };

            return View(vmUsuario);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _usuarioService.EliminarUsuario(id);

            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}
