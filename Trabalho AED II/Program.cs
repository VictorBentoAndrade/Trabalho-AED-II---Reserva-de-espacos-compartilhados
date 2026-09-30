using System;
using System.Security.AccessControl;
using Trabalho_AED_II.Modelos;
using Trabalho_AED_II.Repositorios;

var usuarioRepo = new UsuarioRepositorio();
var espacoRepo = new EspacoRepositorio();
var reservaRepo = new ReservaRepositorio();

bool continuar = true;

while (continuar)
{
    Console.WriteLine("   Sistemas de reservas   ");
    Console.WriteLine("1 - Cadastrar usuario");
    Console.WriteLine("2 - Cadastrar espaço");
    Console.WriteLine("3 - criar reserva");
    Console.WriteLine("4 - Listar reservas");
    Console.WriteLine("5 - Cancelar reservas");
    Console.WriteLine("6 - ver historico de um usuario");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");

    string opcao = Console.ReadLine();
    Console.WriteLine("");

    switch (opcao)
    {
        case "1":
            CadastrarUsuario(usuarioRepo);
            break;

        case "2":
            CadastrarEspaco(espacoRepo);
            break;

        case "3":
            CriarReserva(usuarioRepo, espacoRepo, reservaRepo);
            break;

        case "4":
            ListarReservas(reservaRepo);
            break;

        case "5":
            CancelarReserva(reservaRepo);
            break;

        case "6":
            VarHistorico(usuarioRepo);
            break;

        case "0":
            continuar = false;
            break;

        default:
            Console.WriteLine("Opção invalida");
            break;
    }

    void CadastrarUsuario(UsuarioRepositorio repo)
    {
        Console.WriteLine("Nome do usuario: ");
        string nome = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("Unidade/apto ");
        string unidade = Console.ReadLine();
        Console.WriteLine("");

        var usuario = repo.Cadastrar(nome, unidade);
        Console.WriteLine($"Usuario cadastrado com Id {usuario.Id}.\n");
    }

    void CadastrarEspaco(EspacoRepositorio repo)
    {
        Console.WriteLine("Nome do espaço: ");
        string nome = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("Tipo (Salão/Churrasqueira): ");
        string tipo = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("Capaxidade Maxima: ");
        if (!int.TryParse(Console.ReadLine(), out int capacidade))
        {
            Console.WriteLine("");
            Console.WriteLine("Valor invalido\n");
            return;
        }

        Console.WriteLine("Exige aprovação? (s/n): ");
        bool exigeAprovacao = Console.ReadLine().Trim().ToLower() == "s";
        Console.WriteLine("");

        var espaco = repo.Cadastrar(nome, tipo, capacidade, exigeAprovacao);
        Console.WriteLine($"Espaço cadastrado com Id {espaco.Id}.\n");
    }

    void CriarReserva(UsuarioRepositorio usuarioRepo, EspacoRepositorio espacoRepo, ReservaRepositorio reservaRepo)
    {
        Console.Write("Id do Usuario: ");
        int usuarioId = int.Parse(Console.ReadLine());
        var usuario = usuarioRepo.BuscarPorId(usuarioId);
        Console.WriteLine("");

        if (usuario == null)
        {
            Console.WriteLine("Usuario não encontrado\n");
            return;
        }

        Console.WriteLine("Id do espaço: ");
        int espacoId = int.Parse(Console.ReadLine());
        var espaco = espacoRepo.BuscarPorId(espacoId);
        Console.WriteLine("");

        if (espaco == null)
        { 
            Console.WriteLine("Espaço não encontrado\n");
            return;
        }

        Console.WriteLine("Data/hora inicio (dd/MM/yyy HH:mm): ");
        DateTime inicio = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("");

        Console.WriteLine("Data/hora fim (dd/MM/yyyy HH:mm): ");
        DateTime fim = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("");

        var reserva = reservaRepo.Criar(usuario, espaco, inicio, fim);

        if (reserva != null)
            Console.WriteLine($"Reserva #{reserva.Id} criada com sucesso\n");
    }

    void ListarReservas(ReservaRepositorio repo)
    {
        foreach (var r in repo.ListarTodos())
        {
            Console.WriteLine($"#{r.Id} | {r.Usuario.Nome} | {r.Espaco.Nome} | {r.DataHoraInicio} até {r.DataHoraFim} | {r.Status}\n");
        } 
    }

    void CancelarReserva(ReservaRepositorio repo)
    {
        Console.Write("Id da reserva a cancelar: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("");


        if (repo.Cancelar(id))
            Console.WriteLine("Reserva cancelada.\n");
        else
            Console.WriteLine("Reserva não encontrada.\n");
    }

    void VarHistorico(UsuarioRepositorio repo)
    {
        Console.Write("Id do usuario: ");
        int id = int.Parse(Console.ReadLine());
        var usuario = repo.BuscarPorId(id);
        Console.WriteLine("");

        if (usuario == null)
        {
            Console.WriteLine("Usuario não encontrado.\n");
            return;
        }

        foreach (var r in usuario.Historico.ListarDoFimAoInicio())
        {
            Console.WriteLine($"#{r.Id} | {r.Espaco.Nome} | {r.DataHoraInicio} até {r.DataHoraFim} | {r.Status}\n");
        }
    }

}