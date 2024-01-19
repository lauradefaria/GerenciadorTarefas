using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness.Enums;

namespace AdaTech.ProjetoIndividual.Views.Janelas.JanelasTechLeader
{
    partial class JanelaAlterarStatus
    {
        private ComboBox cmbTarefas;
        private ComboBox cmbStatus;
        private Button btnAlterarStatus;
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
            this.Text = "Janela Alterar Status";

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

            cmbStatus = new ComboBox();
            cmbStatus.Location = new System.Drawing.Point(20, 60);
            cmbStatus.Size = new System.Drawing.Size(300, 25);
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            Controls.Add(cmbStatus);

            Label lblStatus = new Label();
            lblStatus.Text = "Status:";
            lblStatus.Location = new System.Drawing.Point(330, 60);
            lblStatus.AutoSize = true;
            Controls.Add(lblStatus);

            btnAlterarStatus = new Button();
            btnAlterarStatus.Text = "Alterar Status";
            btnAlterarStatus.Location = new System.Drawing.Point(20, 480);
            btnAlterarStatus.Click += (sender, e) => btnAlterarStatusClick?.Invoke(sender, e);
            Controls.Add(btnAlterarStatus);

            lblMensagem = new Label();
            lblMensagem.Location = new System.Drawing.Point(20, 520);
            lblMensagem.AutoSize = true;
            Controls.Add(lblMensagem);
        }

        #endregion
    }
}