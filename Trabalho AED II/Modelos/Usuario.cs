using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_AED_II.Repositorios;

namespace Trabalho_AED_II.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Unidade { get; set; }
        public HistoricoReservas Historico { get; set; }

        public Usuario(int id, string nome, string unidade)
        {
            Id = id;
            Nome = nome;
            Unidade = unidade;
            Historico = new HistoricoReservas();
        }
    }
}
