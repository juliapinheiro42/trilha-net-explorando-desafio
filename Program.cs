using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

try
{
    Console.WriteLine("======= Reserva na capacidade =======");

    List<Pessoa> hospedes = new List<Pessoa>()
    {
        new Pessoa(nome: "Hóspede 1"),
        new Pessoa(nome: "Hóspede 2")
    };

    Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

    Reserva reserva = new Reserva(diasReservados: 5);
    reserva.CadastrarSuite(suite);
    reserva.CadastrarHospedes(hospedes);

    Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
    Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");

    Console.WriteLine("======= Reserva com mais hóspedes do que o permitido =======");

    List<Pessoa> muitosHospedes = new List<Pessoa>()
    {
        new Pessoa(nome: "Hóspede 1"),
        new Pessoa(nome: "Hóspede 2"),
        new Pessoa(nome: "Hóspede 3")
    };

    Suite suitePequena = new Suite(tipoSuite: "Simples", capacidade: 2, valorDiaria: 50);

    Reserva reservaInvalida = new Reserva(diasReservados: 3);
    reservaInvalida.CadastrarSuite(suitePequena);

    try
    {
        reservaInvalida.CadastrarHospedes(muitosHospedes);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Erro esperado: {ex.Message}");
    }

    Console.WriteLine("======= Reserva com 10 dias (desconto) =======");

    List<Pessoa> UmHospede = new List<Pessoa>()
    {
        new Pessoa( "João", "Silva")
    };

    Suite suiteLuxo = new Suite(tipoSuite: "Luxo", capacidade: 1, valorDiaria: 100);

    Reserva reservaComDesconto = new Reserva(diasReservados: 10);
    reservaComDesconto.CadastrarSuite(suiteLuxo);
    reservaComDesconto.CadastrarHospedes(UmHospede);

    Console.WriteLine($"Hóspedes: {reservaComDesconto.ObterQuantidadeHospedes()}");
    Console.WriteLine($"Valor diária com desconto: {reservaComDesconto.CalcularValorDiaria()}");

    Console.WriteLine("======= Reserva com menos de 10 dias (sem desconto) =======");

    Reserva reservaSemDesconto = new Reserva(diasReservados: 7);
    reservaSemDesconto.CadastrarSuite(suiteLuxo);
    reservaSemDesconto.CadastrarHospedes(UmHospede);

    Console.WriteLine($"Hóspedes: {reservaSemDesconto.ObterQuantidadeHospedes()}");
    Console.WriteLine($"Valor diária sem desconto: {reservaSemDesconto.CalcularValorDiaria()}");

}
catch (Exception ex)
{
    Console.WriteLine($"Erro inesperado: {ex.Message}");
}
