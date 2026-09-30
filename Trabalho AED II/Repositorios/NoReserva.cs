using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_AED_II.Modelos;

namespace Trabalho_AED_II.Repositorios
{
    public class NoReserva
    {
        public Reserva Dados { get; set; }
        public NoReserva Anterior { get; set; }
        public NoReserva Proximo { get; set; }

        public NoReserva(Reserva dados)
        {
            Dados = dados;
            Anterior = null;
            Proximo = null;
        }
    }
}
