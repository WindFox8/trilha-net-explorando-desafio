using System;
using System.Collections.Generic;
using DesafioProjetoHospedagem.Models; // Importando o namespace que contém as classes

class Program
{
    static List<Pessoa> hospedes = new List<Pessoa>();
    static List<Suite> suites = new List<Suite>();
    static List<Reserva> reservas = new List<Reserva>();

    static void Main(string[] args)
    {
        int opcao;
        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Reservar");
            Console.WriteLine("2 - Cadastros");
            Console.WriteLine("3 - Listar Hospedes");
            Console.WriteLine("4 - Listar Suítes");
            Console.WriteLine("5 - Listar Reservas");
            Console.WriteLine("6 - Sair");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    RealizarReserva();
                    break;
                case 2:
                    MenuCadastro();
                    break;
                case 3:
                    ListarHospedes();
                    break;
                case 4:
                    ListarSuites();
                    break;
                case 5:
                    ListarReservas();
                    break;
                case 6:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (opcao != 6);
    }

    static void RealizarReserva()
    {
        Console.WriteLine("===== Realizar Reserva =====");
        Console.Write("Digite a quantidade de dias da reserva: ");
        int diasReservados = int.Parse(Console.ReadLine());

        Console.WriteLine("Escolha a suíte:");
        ListarSuites();

        Console.Write("Digite o número da suíte desejada: ");
        int indiceSuite = int.Parse(Console.ReadLine()) - 1;

        Console.WriteLine("Digite as informações dos hóspedes:");
        Console.Write("Quantidade de hóspedes: ");
        int quantidadeHospedes = int.Parse(Console.ReadLine());

        List<Pessoa> hospedesReserva = new List<Pessoa>();
        for (int i = 0; i < quantidadeHospedes; i++)
        {
            Console.Write($"Nome do hóspede {i + 1}: ");
            string nome = Console.ReadLine();
            hospedesReserva.Add(new Pessoa(nome));
        }

        Reserva reserva = new Reserva(diasReservados);
        reserva.CadastrarHospedes(hospedesReserva);
        reserva.CadastrarSuite(suites[indiceSuite]);
        reservas.Add(reserva);

        Console.WriteLine("Reserva realizada com sucesso!");
    }

    static void MenuCadastro()
    {
        int opcao;
        do
        {
            Console.WriteLine("Menu de Cadastros:");
            Console.WriteLine("1 - Cadastrar Hospedes");
            Console.WriteLine("2 - Cadastrar Suíte");
            Console.WriteLine("3 - Cadastrar Reserva");
            Console.WriteLine("4 - Voltar");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarHospedes();
                    break;
                case 2:
                    CadastrarSuite();
                    break;
                case 3:
                    RealizarReserva();
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (opcao != 4);
    }

    static void CadastrarHospedes()
    {
        Console.WriteLine("===== Cadastro de Hospedes =====");
        Console.Write("Quantidade de hospedes a cadastrar: ");
        int quantidade = int.Parse(Console.ReadLine());

        for (int i = 0; i < quantidade; i++)
        {
            Console.Write($"Nome do hospede {i + 1}: ");
            string nome = Console.ReadLine();
            hospedes.Add(new Pessoa(nome));
        }

        Console.WriteLine("Hospedes cadastrados com sucesso!");
    }

    static void CadastrarSuite()
    {
        Console.WriteLine("===== Cadastro de Suíte =====");
        Console.Write("Tipo da suíte: ");
        string tipoSuite = Console.ReadLine();
        Console.Write("Capacidade da suíte: ");
        int capacidade = int.Parse(Console.ReadLine());
        Console.Write("Valor da diária: ");
        decimal valorDiaria = decimal.Parse(Console.ReadLine());

        suites.Add(new Suite(tipoSuite, capacidade, valorDiaria));

        Console.WriteLine("Suíte cadastrada com sucesso!");
    }

    static void ListarHospedes()
    {
        Console.WriteLine("===== Listagem de Hospedes =====");
        foreach (var hospede in hospedes)
        {
            Console.WriteLine($"Nome: {hospede.NomeCompleto}");
        }
    }

    static void ListarSuites()
    {
        Console.WriteLine("===== Listagem de Suítes =====");
        for (int i = 0; i < suites.Count; i++)
        {
            Console.WriteLine($"{i + 1} - Tipo: {suites[i].TipoSuite}, Capacidade: {suites[i].Capacidade}, Valor Diária: {suites[i].ValorDiaria:C}");
        }
    }

    static void ListarReservas()
    {
        Console.WriteLine("===== Listagem de Reservas =====");
        for (int i = 0; i < reservas.Count; i++)
        {
            Console.WriteLine($"Reserva {i + 1}:");
            Console.WriteLine($"  Suíte: {reservas[i].Suite.TipoSuite}");
            Console.WriteLine($"  Dias Reservados: {reservas[i].DiasReservados}");
            Console.WriteLine($"  Valor Total: {reservas[i].CalcularValorDiaria():C}");
            Console.WriteLine("  Hóspedes:");
            foreach (var hospede in reservas[i].Hospedes)
            {
                Console.WriteLine($"    {hospede.NomeCompleto}");
            }
        }
    }
}
