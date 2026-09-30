using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_AED_II.Modelos;

namespace Trabalho_AED_II.Repositorios
{
    internal class UsuarioRepositorio
    {
        private List<Usuario> usuarios = new List<Usuario>();
        private int proximoId = 1;

        public Usuario Cadastrar(string nome, string unidade)
        {
            var usuario = new Usuario(proximoId++, nome, unidade);
            usuarios.Add(usuario);
            return usuario;
        }

        public List<Usuario> ListarTodos()
        {
            return usuarios;
        }

        public Usuario BuscarPorId(int id)
        {
            return usuarios.FirstOrDefault(u => u.Id == id);
        }

        public bool Remover(int id)
        {
            var usuario = BuscarPorId(id);
            if (usuario == null) return false;
            usuarios.Remove(usuario);
            return true;
        }
    }
}
