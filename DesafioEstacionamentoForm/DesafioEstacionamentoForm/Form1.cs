namespace DesafioEstacionamentoForm {
    public partial class FormEstacionamento : Form {
        private List<Veiculo> listaVeiculosSaida = new List<Veiculo>();
        private List<Veiculo> listaVeiculosNoEstacionamento = new List<Veiculo>();
        private DateTime dataHoraAtual;

        public FormEstacionamento() {
            dataHoraAtual = DateTime.Now;
            InitializeComponent();
        }

        private void timerDataHora_Tick(object sender, EventArgs e) {
            dataHoraAtual = DateTime.Now;
            labelDataHora.Text = dataHoraAtual.ToString("dd/MM/yyyy HH:mm");

            DateTime horaInicio = new DateTime(dataHoraAtual.Year, dataHoraAtual.Month, dataHoraAtual.Day, 7, 0, 0);
            DateTime horaFim = new DateTime(dataHoraAtual.Year, dataHoraAtual.Month, dataHoraAtual.Day, 20, 0, 0);
            if (dataHoraAtual < horaInicio || dataHoraAtual > horaFim) {
                timerDataHora.Enabled = false;
                MessageBox.Show("O estacionamento está fechado\nHorário de funcionamento: 7h às 20h", "Desculpe!");
                Application.Exit();
            }
        }

        private void FormEstacionamento_Load(object sender, EventArgs e) {
            DateTime dataAtual = dataHoraAtual.Date;
            textBoxData.Text = dataAtual.ToShortDateString();
        }

        private void buttonEntrada_Click(object sender, EventArgs e) {
            // Verificando se campos estão preenchidos corretamente
            if (textBoxPlaca.Text.Equals("")) {
                MessageBox.Show("Placa inválida", "Alerta!");
                return;
            }
            if (textBoxHora.Text.Equals("")) {
                MessageBox.Show("Hora inválida", "Alerta!");
                return;
            }

            textBoxPlaca.Text = textBoxPlaca.Text.Trim().ToUpper();
            // Verifica se o carro já não está no estacionamento
            if (Estacionamento.procurarVeiculo(textBoxPlaca.Text, listaVeiculosNoEstacionamento) != null) {
                MessageBox.Show("Carro já cadastrado.", "Alerta!");
                return;
            }
            // Verifica se estacionamento tem vaga disponivel
            if (Estacionamento.temLugar(listaVeiculosNoEstacionamento)) {
                // Adicionando veiculo na lista, arquivo e textBox da interface 
                listaVeiculosNoEstacionamento.Add(new Veiculo(textBoxPlaca.Text, DateTime.Parse(textBoxData.Text), TimeOnly.Parse(textBoxHora.Text)));
                textBoxListaVeiculosEntrada.AppendText($"{textBoxPlaca.Text} - {textBoxData.Text} - {textBoxHora.Text}\r\n");
                Persistencia.gravarArquivoVeiculoEntrada(listaVeiculosNoEstacionamento);
            }
            else {
                MessageBox.Show("Estacionamento lotado.", "Alerta!");
            }
        }
        private void buttonSaida_Click(object sender, EventArgs e) {
            // Buscando na lista qual veiculo vai sair
            Veiculo veiculo = Estacionamento.procurarVeiculo(textBoxPlaca.Text, listaVeiculosNoEstacionamento);

            // Verificando se veiculo está na lista
            if (veiculo == null) {
                MessageBox.Show("Este veiculo não está cadastrado.", "Alerta!");
                return;
            }

            // Verificando se campos estão preenchidos corretamente
            if (textBoxPlaca.Text.Equals("")) {
                MessageBox.Show("Placa inválida", "Alerta!");
                return;
            }
            if (textBoxHora.Text.Equals("") || veiculo.HoraEntrada > TimeOnly.Parse(textBoxHora.Text)) {
                MessageBox.Show("Hora inválida", "Alerta!");
                return;
            }

            textBoxPlaca.Text = textBoxPlaca.Text.Trim().ToUpper();
            double tempoPermanencia = Estacionamento.calcularTempoPermanencia(veiculo.HoraEntrada, TimeOnly.Parse(textBoxHora.Text));
            double valorCobrado = Estacionamento.calcularPreço(tempoPermanencia);

            // Incluindo tempo de permanencia e valor aos dados do veiculo
            veiculo.TempoPermanencia = tempoPermanencia;
            veiculo.ValorCobrado = valorCobrado;

            MessageBox.Show($"Valor a pagar: R${valorCobrado:F2}");

            // Adicionando veiculo na lista, arquivo e textBox da interface 
            listaVeiculosSaida.Add(veiculo);
            textBoxListaVeiculosSaida.AppendText($"{textBoxPlaca.Text} - {tempoPermanencia} Min - R${valorCobrado:F2}\r\n");
            Persistencia.gravarArquivoVeiculoSaida(listaVeiculosSaida);

            // Tirando veiculo da lista de veiculos no estacionamento e atualizando arquivo de veiculos no estacionamento
            Estacionamento.veiculoSaida(textBoxPlaca.Text, listaVeiculosNoEstacionamento);
            Persistencia.gravarArquivoVeiculoEntrada(listaVeiculosNoEstacionamento);
        }
    }
}