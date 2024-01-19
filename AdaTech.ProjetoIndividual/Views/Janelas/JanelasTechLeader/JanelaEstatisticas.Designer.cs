using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;

namespace AdaTech.ProjetoIndividual.Views.Janelas.JanelasTechLeader
{
    partial class JanelaEstatisticas
    {
        private Button btnEmAndamento;
        private Button btnAtrasadas;
        private Button btnImpedidas;
        private Button btnAnalise;
        private Button btnConcluidas;
        private Button btnCanceladas;
        private Button btnPendentes;
        private Usuario usuarioLogado;
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Janela Estatísticas";

            Label lblEmAndamento = new Label();
            lblEmAndamento.Text = "Tarefas Em Andamento:";
            lblEmAndamento.Location = new System.Drawing.Point(20, 20);
            lblEmAndamento.AutoSize = true;
            Controls.Add(lblEmAndamento);

            Label lblQuantEmAndamento = new Label();
            lblQuantEmAndamento.Text = quantEmAndamento.ToString();
            lblQuantEmAndamento.Location = new System.Drawing.Point(170, 20);
            lblQuantEmAndamento.AutoSize = true;
            Controls.Add(lblQuantEmAndamento);

            btnEmAndamento = new Button();
            btnEmAndamento.Text = "Visualizar Tarefas";
            btnEmAndamento.Location = new System.Drawing.Point(330, 20);
            btnEmAndamento.Click += (sender, e) => EmAndamentoClick?.Invoke(sender, e);
            Controls.Add(btnEmAndamento);

            Label lblAtrasada = new Label();
            lblAtrasada.Text = "Tarefas Atrasadas:";
            lblAtrasada.Location = new System.Drawing.Point(20, 60);
            lblAtrasada.AutoSize = true;
            Controls.Add(lblAtrasada);

            Label lblQuantAtrasada = new Label();
            lblQuantAtrasada.Text = quantAtrasadas.ToString();
            lblQuantAtrasada.Location = new System.Drawing.Point(170, 60);
            lblQuantAtrasada.AutoSize = true;
            Controls.Add(lblQuantAtrasada);

            btnAtrasadas = new Button();
            btnAtrasadas.Text = "Visualizar Tarefas";
            btnAtrasadas.Location = new System.Drawing.Point(330, 60);
            btnAtrasadas.Click += (sender, e) => AtrasadasClick?.Invoke(sender, e);
            Controls.Add(btnAtrasadas);

            Label lblImpedida = new Label();
            lblImpedida.Text = "Tarefas Com Impedimento:";
            lblImpedida.Location = new System.Drawing.Point(20, 100);
            lblImpedida.AutoSize = true;
            Controls.Add(lblImpedida);

            Label lblQuantImpedida = new Label();
            lblQuantImpedida.Text = quantImpedidas.ToString();
            lblQuantImpedida.Location = new System.Drawing.Point(170, 100);
            lblQuantImpedida.AutoSize = true;
            Controls.Add(lblQuantImpedida);

            btnImpedidas = new Button();
            btnImpedidas.Text = "Visualizar Tarefas";
            btnImpedidas.Location = new System.Drawing.Point(330, 100);
            btnImpedidas.Click += (sender, e) => ImpedidasClick?.Invoke(sender, e);
            Controls.Add(btnImpedidas);

            Label lblAnalise = new Label();
            lblAnalise.Text = "Tarefas Em Análise:";
            lblAnalise.Location = new System.Drawing.Point(20, 140);
            lblAnalise.AutoSize = true;
            Controls.Add(lblAnalise);

            Label lblQuantAnalise = new Label();
            lblQuantAnalise.Text = quantAnalise.ToString();
            lblQuantAnalise.Location = new System.Drawing.Point(170, 140);
            lblQuantAnalise.AutoSize = true;
            Controls.Add(lblQuantAnalise);

            btnAnalise = new Button();
            btnAnalise.Text = "Visualizar Tarefas";
            btnAnalise.Location = new System.Drawing.Point(330, 140);
            btnAnalise.Click += (sender, e) => AnaliseClick?.Invoke(sender, e);
            Controls.Add(btnAnalise);

            Label lblConcluidas = new Label();
            lblConcluidas.Text = "Tarefas Concluídas:";
            lblConcluidas.Location = new System.Drawing.Point(20, 180);
            lblConcluidas.AutoSize = true;
            Controls.Add(lblConcluidas);

            Label lblQuantConcluidas = new Label();
            lblQuantConcluidas.Text = quantAnalise.ToString();
            lblQuantConcluidas.Location = new System.Drawing.Point(170, 180);
            lblQuantConcluidas.AutoSize = true;
            Controls.Add(lblQuantConcluidas);

            btnConcluidas = new Button();
            btnConcluidas.Text = "Visualizar Tarefas";
            btnConcluidas.Location = new System.Drawing.Point(330, 180);
            btnConcluidas.Click += (sender, e) => ConcluidasClick?.Invoke(sender, e);
            Controls.Add(btnConcluidas);

            Label lblPendentes = new Label();
            lblPendentes.Text = "Tarefas Pendentes:";
            lblPendentes.Location = new System.Drawing.Point(20, 220);
            lblPendentes.AutoSize = true;
            Controls.Add(lblPendentes);

            Label lblQuantPendentes = new Label();
            lblQuantPendentes.Text = quantPendente.ToString();
            lblQuantPendentes.Location = new System.Drawing.Point(170, 220);
            lblQuantPendentes.AutoSize = true;
            Controls.Add(lblQuantPendentes);

            btnPendentes = new Button();
            btnPendentes.Text = "Visualizar Tarefas";
            btnPendentes.Location = new System.Drawing.Point(330, 220);
            btnPendentes.Click += (sender, e) => PendentesClick?.Invoke(sender, e);
            Controls.Add(btnPendentes);

            Label lblCanceladas = new Label();
            lblCanceladas.Text = "Tarefas Abandonadas:";
            lblCanceladas.Location = new System.Drawing.Point(20, 260);
            lblCanceladas.AutoSize = true;
            Controls.Add(lblCanceladas);

            Label lblQuantCanceladas = new Label();
            lblQuantCanceladas.Text = quantCanceladas.ToString();
            lblQuantCanceladas.Location = new System.Drawing.Point(170, 260);
            lblQuantCanceladas.AutoSize = true;
            Controls.Add(lblQuantCanceladas);

            btnCanceladas = new Button();
            btnCanceladas.Text = "Visualizar Tarefas";
            btnCanceladas.Location = new System.Drawing.Point(330, 260);
            btnCanceladas.Click += (sender, e) => CanceladasClick?.Invoke(sender, e);
            Controls.Add(btnCanceladas);
        }

        #endregion
    }
}