using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_AED_II.Modelos;

namespace Trabalho_AED_II.Repositorios
{
    public class FilaEspera
    {
        private Queue<Usuario> fila = new Queue<Usuario>();

        public void EntrarNaFila(Usuario usuario)
        {
            fila.Enqueue(usuario);
        }

        public Usuario ChamarProximo()
        {
            if (fila.Count == 0) return null;
            return fila.Dequeue();
        }

        public Usuario ConsultarProximo()
        {
            if (fila.Count == 0) return null;
            return fila.Peek(); //olha sem remover
        }

        public List<Usuario> ListarFila()
        {
            return fila.ToList();
        }

        public int TotalNaFila()
        {
            return fila.Count;
        }
    }
}
