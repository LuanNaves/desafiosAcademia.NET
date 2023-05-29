using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioEstacionamentoForm {
    internal class Estacionamento {

        public static Veiculo procurarVeiculo(string placa, List<Veiculo> lista) {
            foreach (var veiculo in lista) {
                if(veiculo.Placa.Equals(placa)) {
                    return veiculo;
                }
            }
            return null;
        }

        public static void veiculoSaida(string placa, List<Veiculo> lista) {
            foreach(var veiculo in lista) {
                if (veiculo.Placa.Equals(placa)) {
                    lista.Remove(veiculo);
                    return;
                }
            }
        }

        public static double calcularTempoPermanencia(TimeOnly horaEntrada, TimeOnly horaSaida) {
            TimeSpan tempoPermanencia = horaSaida - horaEntrada;
            double permanenciaEmMin = tempoPermanencia.TotalMinutes;
            return permanenciaEmMin;
        }
        public static double calcularPreço(double tempoPermanencia) {
            int horas = (int)Math.Ceiling(tempoPermanencia / 60);
            double valor = horas * 5;
            return valor;
        }
        public static bool temLugar(List<Veiculo> lista) {
            if (lista.Count > 49) {
                return false;
            }
            return true;
        }
    }
}
