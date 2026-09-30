using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_AED_II.Modelos;

namespace Trabalho_AED_II.Repositorios
{
    internal class PilhaAuditoria
    {
        private Stack<AcaoReserva> pilha = new Stack<AcaoReserva>();

        public void RegistrarAcao(int reservaId, StatusReserva statusAnterior, StatusReserva statusNovo)
        {
            var acao = new AcaoReserva(reservaId, statusAnterior, statusNovo);
            pilha.Push(acao);
        }

        public AcaoReserva ConsultarUltimaAcao()
        {
            if (pilha.Count == 0) return null;
            return pilha.Peek(); //olha sem remover
        }

        public AcaoReserva DesfazerUltimaAcao()
        {
            if (pilha.Count == 0) return null;
            return pilha.Pop(); // remove e retorna
        }

        public List<AcaoReserva> ListarHistoricoCompleto()
        {
            return pilha.ToList(); //ja vem do mais recente pro mais antigo
        }

        public int TotalAcoes()
        {
            return pilha.Count;
        }
    }
}
