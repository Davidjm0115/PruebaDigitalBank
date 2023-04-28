using CapaDatos;
using CapaNegocios.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBankPrueba.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _iusuario;

        public UsuarioController(IUsuarioRepository iusuario)
        {
            _iusuario = iusuario;
        }


        public IActionResult UsuarioConsulta()
        {
            var usuario = _iusuario.GetAllUsuarios();
            return View(usuario);
        }

        public IActionResult Usuario() 
        {
            return View();
        }

        [HttpPost]

        public IActionResult Usuario(Usuario usuario) 
        {
                _iusuario.InsertarUsuario(usuario);
                return RedirectToAction("Index");
             
        }

        public IActionResult Editar(int id)
        {
            var usuario = _iusuario.GetUsuarioById(id);
            return View(usuario);
        }

        [HttpPost]

        public IActionResult Editar(Usuario usuario)
        {
            _iusuario.ActualizarUsuario(usuario);
            return RedirectToAction("Index");

        }

        public IActionResult Eliminar(int id)
        {
            var usuario = _iusuario.GetUsuarioById(id);

            if (usuario == null)
                return NotFound();  

            return View(usuario);

           
        }

        [HttpPost]

        public IActionResult EliminarConfirmado(int id)
        {
            _iusuario.EliminarUsuario(id);
            return RedirectToAction("Index");

        }

    }

        
}
