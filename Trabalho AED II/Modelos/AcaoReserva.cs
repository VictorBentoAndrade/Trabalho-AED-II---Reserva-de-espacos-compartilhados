using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_AED_II.Modelos
{
    internal class AcaoReserva
    {
        public int ReservaId { get; set; }
        public StatusReserva StatusAnterior { get; set; }
        public StatusReserva StatusNovo { get; set; }
        public DateTime DataHoraAcao { get; set; }

        public AcaoReserva(int reservaId, StatusReserva statusAnterior, StatusReserva statusNovo)
        {
            ReservaId = reservaId;
            StatusAnterior = statusAnterior;
            StatusNovo = statusNovo;
            DataHoraAcao = DateTime.Now;
        }
    }
}
