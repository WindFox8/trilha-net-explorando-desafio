using System;
using System.Collections.Generic;

public class Pessoa
{
    public string Nome { get; set; }

    public Pessoa(string nome)
    {
        Nome = nome;
    }
}

public class Suite
{
    public string TipoSuite { get; set; }
    public int Capacidade { get; set; }
    public double ValorDiaria { get; set; }

    public Suite(string tipoSuite, int capacidade, double valorDiaria)
    {
        TipoSuite = tipoSuite;
        Capacidade = capacidade;
        ValorDiaria = valorDiaria;
    }
}

public class Reserva
{
    private Suite _suite;
    private List<Pessoa> _hospedes;
    private int _diasReservados;

    public Reserva(int diasReservados)
    {
        _diasReservados = diasReservados;
        _hospedes = new List<Pessoa>();
    }

    public void CadastrarSuite(Suite suite)
    {
        _suite = suite;
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        if (hospedes.Count > _suite.Capacidade)
        {
            throw new ArgumentException("A quantidade de hóspedes excede a capacidade da suíte.");
        }

        _hospedes = hospedes;
    }

    public int ObterQuantidadeHospedes()
    {
        return _hospedes.Count;
    }

    public double CalcularValorDiaria()
    {
        double valorTotal = _diasReservados * _suite.ValorDiaria;
        if (_diasReservados >= 10)
        {
            valorTotal *= 0.9; // Aplica o desconto de 10%
        }
        return valorTotal;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Pessoa> hospedes = new List<Pessoa>();

        Pessoa p1 = new Pessoa(nome: "Hóspede 1");
        Pessoa p2 = new Pessoa(nome: "Hóspede 2");

        hospedes.Add(p1);
        hospedes.Add(p2);

        Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

        Reserva reserva = new Reserva(diasReservados: 5);
        reserva.CadastrarSuite(suite);
        reserva.CadastrarHospedes(hospedes);

        Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");

        Console.ReadLine(); // Para manter a janela aberta
    }
}
