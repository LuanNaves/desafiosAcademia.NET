using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioEstacionamentoForm {
    internal class Persistencia {

        public static void gravarArquivoVeiculoEntrada(List<Veiculo> lista) {
            try {
                StreamWriter escritor = new StreamWriter("D:\\Codiguinhos - Luan\\Academia .NET\\Desafios\\DesafioEstacionamentoForm\\DesafioEstacionamentoForm\\veiculosEntrada.dat");

                foreach (var item in lista) {
                    escritor.WriteLine(item.Placa + ";" + item.DataEntrada.Date.ToString("dd/MM/yyyy") + ";" + item.HoraEntrada);
                    escritor.Flush();
                }
                escritor.Close();
            }
            catch (Exception) {
                MessageBox.Show("Problemas com arquivo");
            }
        }
        public static void gravarArquivoVeiculoSaida(List<Veiculo> lista) {
            try {
                StreamWriter escritor = new StreamWriter("D:\\Codiguinhos - Luan\\Academia .NET\\Desafios\\DesafioEstacionamentoForm\\DesafioEstacionamentoForm\\veiculosSaida.dat");

                foreach (var item in lista) {
                    escritor.WriteLine($"{item.Placa};{item.DataEntrada.Date.ToString("dd/MM/yyyy")};" +
                        $"{item.HoraEntrada};{item.TempoPermanencia};{item.ValorCobrado}");
                    escritor.Flush();
                }
                escritor.Close();
            }
            catch (Exception) {
                MessageBox.Show("Problemas com arquivo");
            }
        }

    }
}
