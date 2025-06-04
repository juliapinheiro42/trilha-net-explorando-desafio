namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // ✅ Verifica se a capacidade da suíte é suficiente para os hóspedes
            if (Suite != null && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new ArgumentException("Capacidade da suíte é insuficiente para a quantidade de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // ✅ Retorna a quantidade de hóspedes
            return Hospedes != null ? Hospedes.Count : 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
                throw new InvalidOperationException("A suíte não foi cadastrada.");

            // ✅ Cálculo: DiasReservados x Suite.ValorDiaria
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // ✅ Regra: desconto de 10% se dias >= 10
            if (DiasReservados >= 10)
            {
                valor *= 0.9m; // Aplica 10% de desconto
            }

            return valor;
        }
    }
}
