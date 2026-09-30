using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_AED_II.Modelos;

namespace Trabalho_AED_II.Repositorios
{
    public class EspacoRepositorio
    {
        private List<Espaco> espacos = new List<Espaco>();
        private int proximoId = 1;

        public Espaco Cadastrar(string nome, string tipo, int capacidadeMaxima, bool exigeAprovacao)
        {
            var espaco = new Espaco(proximoId++, nome, tipo, capacidadeMaxima, exigeAprovacao);
            espacos.Add(espaco);
            return espaco;
        }

        public List<Espaco> ListarTodos()
        {
            return espacos;
        }

        public Espaco BuscarPorId(int id)
        {
            return espacos.FirstOrDefault(e => e.Id == id);
        }

        public void AtualizarStatus(int id, StatusEspaco novoStatus)
        {
            var espaco = BuscarPorId(id);
            if (espaco != null) espaco.Status = novoStatus;
        }

        public bool Remover (int id)
        {
            var espaco = BuscarPorId(id);
            if (espaco == null) return false;
            espacos.Remove(espaco);
            return true;
        }
    }
}
