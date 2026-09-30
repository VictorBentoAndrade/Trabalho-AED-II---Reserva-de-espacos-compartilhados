using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_AED_II.Modelos;

namespace Trabalho_AED_II.Repositorios
{
    public class HistoricoReservas
    {
        private NoReserva cabeca;
        private NoReserva cauda;
        private int total;

        public void Adicionar(Reserva reserva)
        {
            var novoNo = new NoReserva(reserva);

            if (cabeca == null)
            {
                //Lista vazia: novo nó vira cabeça e cauda
                cabeca = novoNo;
                cauda = novoNo;
            }
            else
            {
                //insere no fim, religando os ponteiros
                novoNo.Anterior = cauda;
                cauda.Proximo = novoNo;
                cauda = novoNo;
            }

            total++;
        }

        public bool RemoverPorId(int id)
        {
            var atual = cabeca;

            while (atual != null)
            {
                if (atual.Dados.Id == id)
                {
                    //religa os vizinhos, pulando o no atual
                    if (atual.Anterior != null)
                        atual.Anterior.Proximo = atual.Proximo;
                    else
                        cabeca = atual.Proximo; //era a cabeca

                    if (atual.Proximo != null)
                        atual.Proximo.Anterior = atual.Anterior;
                    else
                        cauda = atual.Anterior; //era a cauda

                    total--;
                    return true;
                }
                atual = atual.Proximo;
            }

            return false;
        }

        public List<Reserva> ListarDoInicioAoFim()
        {
            var resultado = new List<Reserva>();
            var atual = cabeca;

            while (atual != null)
            {
                resultado.Add(atual.Dados);
                atual = atual.Proximo;
            }

            return resultado;
        }

        public List<Reserva> ListarDoFimAoInicio()
        {
            var resultado = new List<Reserva>();
            var atual = cauda;

            while (atual != null)
            {
                resultado.Add(atual.Dados);
                atual = atual.Anterior;
            }

            return resultado;
        }

        public int Total()
        {
            return total;
        }
    }
}
