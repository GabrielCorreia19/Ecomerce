using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Models;
namespace WebStore.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly WebStoreContext usuario_Context;

        public UsuarioRepository(WebStoreContext usuarioContext)
        {  
            this.usuario_Context = usuarioContext;
        }
        public UsuarioModel cadastrarUsuario(UsuarioModel usuario)
        {
            usuario_Context.Usuarios.Add(usuario);
            usuario_Context.SaveChanges();
            return usuario;
        }
        public List<UsuarioModel> listarUsuarios()
        {
             return usuario_Context.Usuarios.ToList();
        }
        public UsuarioModel atualizarUsuario(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = buscarId(usuario.IdUsuario);

            if(usuarioDB == null) throw new Exception("usuario não foi encontrado");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Sobrenome = usuario.Sobrenome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Senha = usuario.Senha;
            usuarioDB.SenhaConfirmacao = usuario.SenhaConfirmacao;
            
            usuario_Context.Update(usuarioDB);
            usuario_Context.SaveChanges();
            return usuarioDB;
        }

        public UsuarioModel buscarId(int id)
        {
            return usuario_Context.Usuarios.FirstOrDefault(x=> x.IdUsuario == id);
        }
        


        public bool deletarUsuario(int id)
        {
            UsuarioModel usuarioDb = buscarId(id);

            if(usuarioDb == null) throw new Exception("usuario não encontrado");

            usuario_Context.Usuarios.Remove(usuarioDb);
            usuario_Context.SaveChanges();
            return true;
        }

    }
}