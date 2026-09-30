using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_AED_II.Modelos;

namespace Trabalho_AED_II.Repositorios
{
    public class ArvoreReserva
    {
        private NoArvoreReserva raiz;

        public void Inserir(Reserva reserva)
        {
            raiz = InserirRecursivo(raiz, reserva);
        }

        private NoArvoreReserva InserirRecursivo(NoArvoreReserva no, Reserva reserva)
        {
            if (no == null)
                return new NoArvoreReserva(reserva);

            //ordena pela data/hora de inicio
            if (reserva.DataHoraInicio < no.Dados.DataHoraInicio)
                no.Esquerda = InserirRecursivo(no.Esquerda, reserva);
            else
                no.Direita = InserirRecursivo(no.Direita, reserva);

            return no;
        }

        public bool ExisteConflito(DateTime incio, DateTime fim)
        {
            return VerificarConflitoRecursivo(raiz, incio, fim);
        }

        private bool VerificarConflitoRecursivo(NoArvoreReserva no, DateTime inicio, DateTime fim)
        {
            if (no == null) return false;

            //ignora reservas canceladas/recusadas - não ocupam mais hora
            bool ocupaHorario = no.Dados.Status != StatusReserva.Cancelada && no.Dados.Status != StatusReserva.Recusada;

            if (ocupaHorario && no.Dados.SobrepoeCom(inicio, fim))
                return true;

            //como a arvore está ordenada por inicio, poda os ramos que nao podem sobrepor
            bool encontradoEsquerda = inicio < no.Dados.DataHoraInicio && VerificarConflitoRecursivo(no.Esquerda, inicio, fim);

            bool encontradoDireita = inicio < no.Dados.DataHoraInicio && VerificarConflitoRecursivo(no.Direita, inicio, fim);

            return encontradoEsquerda || encontradoDireita;
        }

        public List<Reserva> ListarEmOrdem()
        {
            var resultado = new List<Reserva>();
            PercorrerEmOrdem(raiz, resultado);
            return resultado;
        }

        private void PercorrerEmOrdem(NoArvoreReserva no, List<Reserva> resultado)
        {
            if (no == null) return;
            PercorrerEmOrdem(no.Esquerda, resultado);
            resultado.Add(no.Dados);
            PercorrerEmOrdem(no.Direita, resultado);
        }
    }
}
