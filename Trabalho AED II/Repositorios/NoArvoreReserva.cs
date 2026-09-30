using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_AED_II.Modelos;

namespace Trabalho_AED_II.Repositorios
{
    public class NoArvoreReserva
    {
        public Reserva Dados { get; set; }
        public NoArvoreReserva Esquerda { get; set; }
        public NoArvoreReserva Direita { get; set; }

        public NoArvoreReserva (Reserva dados)
        {
            Dados = dados;
            Esquerda = null;
            Direita = null;
        }
    }
}
