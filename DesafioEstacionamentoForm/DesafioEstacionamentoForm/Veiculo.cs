using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioEstacionamentoForm {
    public class Veiculo {

        public string Placa { get; set; }
        public DateTime DataEntrada { get; set; }
        public TimeOnly HoraEntrada { get; set; }
        public double ValorCobrado { get; set; }
        public double TempoPermanencia { get; set; }

        public Veiculo(string placa, DateTime dataEntrada, TimeOnly horaEntrada) {
            Placa = placa;
            DataEntrada = dataEntrada;
            HoraEntrada = horaEntrada;
        }

    }
}
