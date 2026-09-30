using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Trabalho_AED_II.Modelos
{
    public enum StatusReserva
    {
        Pendente,
        Aprovado,
        Confirmado,
        Recusada,
        Cancelada
    }
    public class Reserva
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Espaco Espaco { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public StatusReserva Status { get; set; }
        
        public Reserva (int id, Usuario usuario, Espaco espaco, DateTime inicio, DateTime fim)
        {
            Id = id;
            Usuario = usuario;
            Espaco = espaco;
            DataHoraInicio = inicio;
            DataHoraFim = fim;
            Status = StatusReserva.Pendente;
        }

        public bool SobrepoeCom(DateTime inicio, DateTime fim)
        {
            return DataHoraInicio < fim && inicio < DataHoraFim;
        }
    }
}
