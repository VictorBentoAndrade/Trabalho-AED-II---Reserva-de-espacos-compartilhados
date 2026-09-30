using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_AED_II.Modelos;

namespace Trabalho_AED_II.Repositorios
{
    internal class ReservaRepositorio
    {
        private List<Reserva> reservas = new List<Reserva>();
        private int proximoId = 1;
        private PilhaAuditoria auditoria = new PilhaAuditoria();

        public Reserva Criar(Usuario usuario, Espaco espaco, DateTime inicio, DateTime fim)
        {
            if (espaco.Reservas.ExisteConflito(inicio, fim))
            {
                Console.WriteLine($"Conflito de horario! {espaco.Nome} já esta reservado nesse período.");
                return null;

            }

            var reserva = new Reserva(proximoId++, usuario, espaco, inicio, fim);
            reservas.Add(reserva);
            usuario.Historico.Adicionar(reserva);
            espaco.Reservas.Inserir(reserva);
            return reserva;
        }

        public List<Reserva> ListarTodos()
        {
            return reservas;
        }

        public Reserva BuscarPorId(int id)
        {
            return reservas.FirstOrDefault(r => r.Id == id);
        }

        public bool Aprovar (int id)
        {
            var reserva = BuscarPorId(id);
            if (reserva == null) return false;

            var statusAnterior = reserva.Status;
            reserva.Status = StatusReserva.Aprovado;
            auditoria.RegistrarAcao(reserva.Id, statusAnterior, reserva.Status);

            return true;
        }

        public List<AcaoReserva> ConsultarAuditoria()
        {
            return auditoria.ListarHistoricoCompleto();
        }

        public bool Cancelar(int id)
        {
            var reserva = BuscarPorId(id);
            if (reserva == null) return false;

            var statusAnterior = reserva.Status;
            reserva.Status = StatusReserva.Cancelada;
            auditoria.RegistrarAcao(reserva.Id, statusAnterior, reserva.Status);

            //Chama o proximo da fila de espera, se houver
            var proximo = reserva.Espaco.FilaEspera.ChamarProximo();
            if (proximo != null)
            {
                Console.WriteLine($"Vaga liberada! {proximo.Nome} foi chamado na fila de espera para {reserva.Espaco.Nome}.");
            }

            return true;
        }

        public void EntrarNaFilaDeEspera(Usuario usuario, Espaco espaco)
        {
            espaco.FilaEspera.EntrarNaFila(usuario);
        }
    }
}
