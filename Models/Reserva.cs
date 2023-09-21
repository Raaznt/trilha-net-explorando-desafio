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
            bool efetivarCadastro = hospedes.Count() <= Suite.Capacidade;

            if (efetivarCadastro)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Quantidade de hóspedes excede a capacidade da suite");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes is not null ? Hospedes.Count : 0;  
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = 0;
            valor = Suite.ValorDiaria * DiasReservados;

            bool aplicarDesconto = DiasReservados >= 10;
            if (aplicarDesconto)
            {
                valor = Convert.ToDecimal(Convert.ToDouble(valor) * 0.9);
            }

            return valor;
        }
    }
}