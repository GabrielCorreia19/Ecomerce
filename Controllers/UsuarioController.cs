using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebStore.Models;
using WebStore.Repository;

namespace WebStore.Controllers
{
    
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        
        public IActionResult ListarUsuarios()
        {
            List<UsuarioModel> usuarios = _usuarioRepository.listarUsuarios();
            return View(usuarios);
        }
        
        public IActionResult AtualizarUsuario(int id)
        {
            UsuarioModel usuario = _usuarioRepository.buscarId(id);
            return View(usuario);
        }


        public IActionResult ConfirmarExclusao(int id)
        {
            UsuarioModel usuario = _usuarioRepository.buscarId(id);
            return View(usuario);
        }
        public IActionResult RegistrarUsuario()
        {
            return View();
        }
        public IActionResult Deletar(int id)
        {
            _usuarioRepository.deletarUsuario(id);
            return RedirectToAction("ListarUsuarios");
        }


        [HttpPost]
        public IActionResult RegistrarUsuario(UsuarioModel usuario)
        {
            _usuarioRepository.cadastrarUsuario(usuario);
            return RedirectToAction("ListarUsuarios");
        }

        [HttpPost]
        public IActionResult Atualizar(UsuarioModel usuario)
        {
            _usuarioRepository.atualizarUsuario(usuario);
            return RedirectToAction("ListarUsuarios");
        }

    }
}