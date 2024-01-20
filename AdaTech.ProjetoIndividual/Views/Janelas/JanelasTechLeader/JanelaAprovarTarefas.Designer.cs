using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;

namespace AdaTech.ProjetoIndividual.Views.Janelas.JanelasTechLeader
{
    partial class JanelaAprovarTarefas
    {
        private ComboBox cmbTarefas;
        private ComboBox cmbStatus;
        private Button btnAprovar;
        private Button btnRecusar;
        private Label lblMensagem;
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
            this.Text = "Janela Aprovar Tarefas";

            cmbTarefas = new ComboBox();
            cmbTarefas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTarefas.Location = new System.Drawing.Point(20, 20);
            cmbTarefas.Size = new System.Drawing.Size(300, 25);
            Controls.Add(cmbTarefas);

            Label lblTarefas = new Label();
            lblTarefas.Text = "Tarefa:";
            lblTarefas.Location = new System.Drawing.Point(330, 20);
            lblTarefas.AutoSize = true;
            Controls.Add(lblTarefas);

            btnAprovar = new Button();
            btnAprovar.Text = "Aprovar";
            btnAprovar.Location = new System.Drawing.Point(20, 480);
            btnAprovar.Click += (sender, e) => btnAprovarClick?.Invoke(sender, e);
            Controls.Add(btnAprovar);

            btnRecusar = new Button();
            btnRecusar.Text = "Aprovar";
            btnRecusar.Location = new System.Drawing.Point(70, 480);
            btnRecusar.Click += (sender, e) => btnReprovarClick?.Invoke(sender, e);
            Controls.Add(btnRecusar);

            lblMensagem = new Label();
            lblMensagem.Location = new System.Drawing.Point(20, 520);
            lblMensagem.AutoSize = true;
            Controls.Add(lblMensagem);
        }

        #endregion
    }
}