using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Repository
{
    public interface IUsuarioRepository
    {
        UsuarioModel cadastrarUsuario(UsuarioModel usuario);
        UsuarioModel buscarId(int id);
        List<UsuarioModel> listarUsuarios();
        UsuarioModel atualizarUsuario(UsuarioModel usuario);

        bool deletarUsuario(int id);
    }
}