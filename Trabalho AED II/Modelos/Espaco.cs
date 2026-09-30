using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_AED_II.Repositorios;

namespace Trabalho_AED_II.Modelos
{
    public enum StatusEspaco
    {
        Disponivel,
        EmManuntencao,
        Inativo
    }

    public class Espaco
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int CapacidadeMaxima { get; set; }
        public bool ExigeAprovacao { get; set; }
        public StatusEspaco Status { get; set; }
        public FilaEspera FilaEspera { get; set; }
        public ArvoreReserva Reservas { get; set; }

        public Espaco (int id, string nome, string tipo, int capacidadeMaxima, bool exigeAprovacao)
        {
            Id = id;
            Nome = nome;
            Tipo = tipo;
            CapacidadeMaxima = capacidadeMaxima;
            ExigeAprovacao = exigeAprovacao;
            Status = StatusEspaco.Disponivel;
            FilaEspera = new FilaEspera();
            Reservas = new ArvoreReserva();
        }
    }
}
