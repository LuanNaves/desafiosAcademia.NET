namespace DesafioEstacionamentoForm {
    partial class FormEstacionamento {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            labelPlaca = new Label();
            textBoxPlaca = new TextBox();
            buttonEntrada = new Button();
            buttonSaida = new Button();
            textBoxData = new TextBox();
            textBoxHora = new TextBox();
            labelData = new Label();
            labelHora = new Label();
            textBoxListaVeiculosEntrada = new TextBox();
            textBoxListaVeiculosSaida = new TextBox();
            labelListaVeiculosEntrada = new Label();
            labelListaVeiculosSaida = new Label();
            labelDataHora = new Label();
            timerDataHora = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // labelPlaca
            // 
            labelPlaca.AutoSize = true;
            labelPlaca.Location = new Point(12, 32);
            labelPlaca.Name = "labelPlaca";
            labelPlaca.Size = new Size(41, 15);
            labelPlaca.TabIndex = 0;
            labelPlaca.Text = "Placa: ";
            // 
            // textBoxPlaca
            // 
            textBoxPlaca.AcceptsTab = true;
            textBoxPlaca.Location = new Point(50, 29);
            textBoxPlaca.Name = "textBoxPlaca";
            textBoxPlaca.Size = new Size(184, 23);
            textBoxPlaca.TabIndex = 1;
            // 
            // buttonEntrada
            // 
            buttonEntrada.Location = new Point(50, 203);
            buttonEntrada.Name = "buttonEntrada";
            buttonEntrada.Size = new Size(75, 23);
            buttonEntrada.TabIndex = 3;
            buttonEntrada.Text = "Entrada";
            buttonEntrada.UseVisualStyleBackColor = true;
            buttonEntrada.Click += buttonEntrada_Click;
            // 
            // buttonSaida
            // 
            buttonSaida.Location = new Point(159, 203);
            buttonSaida.Name = "buttonSaida";
            buttonSaida.Size = new Size(75, 23);
            buttonSaida.TabIndex = 4;
            buttonSaida.Text = "Saída";
            buttonSaida.UseVisualStyleBackColor = true;
            buttonSaida.Click += buttonSaida_Click;
            // 
            // textBoxData
            // 
            textBoxData.Enabled = false;
            textBoxData.Location = new Point(50, 124);
            textBoxData.Name = "textBoxData";
            textBoxData.Size = new Size(184, 23);
            textBoxData.TabIndex = 4;
            textBoxData.TabStop = false;
            // 
            // textBoxHora
            // 
            textBoxHora.Location = new Point(50, 153);
            textBoxHora.Name = "textBoxHora";
            textBoxHora.Size = new Size(184, 23);
            textBoxHora.TabIndex = 2;
            // 
            // labelData
            // 
            labelData.AutoSize = true;
            labelData.Location = new Point(14, 127);
            labelData.Name = "labelData";
            labelData.Size = new Size(34, 15);
            labelData.TabIndex = 6;
            labelData.Text = "Data:";
            // 
            // labelHora
            // 
            labelHora.AutoSize = true;
            labelHora.Location = new Point(12, 156);
            labelHora.Name = "labelHora";
            labelHora.Size = new Size(36, 15);
            labelHora.TabIndex = 7;
            labelHora.Text = "Hora:";
            // 
            // textBoxListaVeiculosEntrada
            // 
            textBoxListaVeiculosEntrada.Enabled = false;
            textBoxListaVeiculosEntrada.Location = new Point(295, 25);
            textBoxListaVeiculosEntrada.Multiline = true;
            textBoxListaVeiculosEntrada.Name = "textBoxListaVeiculosEntrada";
            textBoxListaVeiculosEntrada.ScrollBars = ScrollBars.Vertical;
            textBoxListaVeiculosEntrada.Size = new Size(226, 201);
            textBoxListaVeiculosEntrada.TabIndex = 8;
            // 
            // textBoxListaVeiculosSaida
            // 
            textBoxListaVeiculosSaida.Enabled = false;
            textBoxListaVeiculosSaida.Location = new Point(527, 25);
            textBoxListaVeiculosSaida.Multiline = true;
            textBoxListaVeiculosSaida.Name = "textBoxListaVeiculosSaida";
            textBoxListaVeiculosSaida.ScrollBars = ScrollBars.Vertical;
            textBoxListaVeiculosSaida.Size = new Size(226, 201);
            textBoxListaVeiculosSaida.TabIndex = 9;
            // 
            // labelListaVeiculosEntrada
            // 
            labelListaVeiculosEntrada.AutoSize = true;
            labelListaVeiculosEntrada.Location = new Point(331, 6);
            labelListaVeiculosEntrada.Name = "labelListaVeiculosEntrada";
            labelListaVeiculosEntrada.Size = new Size(155, 15);
            labelListaVeiculosEntrada.TabIndex = 10;
            labelListaVeiculosEntrada.Text = "Veiculos no Estacionamento";
            labelListaVeiculosEntrada.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelListaVeiculosSaida
            // 
            labelListaVeiculosSaida.AutoSize = true;
            labelListaVeiculosSaida.Location = new Point(577, 6);
            labelListaVeiculosSaida.Name = "labelListaVeiculosSaida";
            labelListaVeiculosSaida.Size = new Size(111, 15);
            labelListaVeiculosSaida.TabIndex = 11;
            labelListaVeiculosSaida.Text = "Veiculos que sairam";
            labelListaVeiculosSaida.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelDataHora
            // 
            labelDataHora.AutoSize = true;
            labelDataHora.Location = new Point(658, 239);
            labelDataHora.Name = "labelDataHora";
            labelDataHora.Size = new Size(95, 15);
            labelDataHora.TabIndex = 12;
            labelDataHora.Text = "00/00/0000 00:00";
            // 
            // timerDataHora
            // 
            timerDataHora.Enabled = true;
            timerDataHora.Interval = 1000;
            timerDataHora.Tick += timerDataHora_Tick;
            // 
            // FormEstacionamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(800, 450);
            Controls.Add(labelDataHora);
            Controls.Add(labelListaVeiculosSaida);
            Controls.Add(labelListaVeiculosEntrada);
            Controls.Add(textBoxListaVeiculosSaida);
            Controls.Add(textBoxListaVeiculosEntrada);
            Controls.Add(labelHora);
            Controls.Add(labelData);
            Controls.Add(textBoxHora);
            Controls.Add(textBoxData);
            Controls.Add(buttonSaida);
            Controls.Add(buttonEntrada);
            Controls.Add(textBoxPlaca);
            Controls.Add(labelPlaca);
            Name = "FormEstacionamento";
            Text = "Gerenciamento do Estacionamento";
            Load += FormEstacionamento_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPlaca;
        private TextBox textBoxPlaca;
        private Button buttonEntrada;
        private Button buttonSaida;
        private TextBox textBoxData;
        private TextBox textBoxHora;
        private Label labelData;
        private Label labelHora;
        private TextBox textBoxListaVeiculosEntrada;
        private TextBox textBoxListaVeiculosSaida;
        private Label labelListaVeiculosEntrada;
        private Label labelListaVeiculosSaida;
        private Label labelDataHora;
        private System.Windows.Forms.Timer timerDataHora;
    }
}