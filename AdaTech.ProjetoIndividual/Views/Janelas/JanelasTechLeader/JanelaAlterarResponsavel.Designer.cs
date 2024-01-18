using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness.Enums;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;

namespace AdaTech.ProjetoIndividual.Views.Janelas.JanelasTechLeader
{
    partial class JanelaAlterarResponsavel
    {
        private ComboBox cmbTarefas;
        private ComboBox cmbUsuario;
        private Button btnAlterarResponsavel;
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
            this.Text = "Janela Alterar Responsavel";

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

            cmbUsuario = new ComboBox();
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.Location = new System.Drawing.Point(20, 60);
            cmbUsuario.Size = new System.Drawing.Size(300, 25);
            Controls.Add(cmbUsuario);

            Label lblUsuario = new Label();
            lblUsuario.Text = "Usuário Responsável:";
            lblUsuario.Location = new System.Drawing.Point(330, 60);
            lblUsuario.AutoSize = true;
            Controls.Add(lblUsuario);

            btnAlterarResponsavel = new Button();
            btnAlterarResponsavel.Text = "Alterar Responsável";
            btnAlterarResponsavel.Location = new System.Drawing.Point(20, 480);
            btnAlterarResponsavel.Click += btnAlterarResponsavel_Click;
            Controls.Add(btnAlterarResponsavel);

            lblMensagem = new Label();
            lblMensagem.Location = new System.Drawing.Point(20, 520);
            lblMensagem.AutoSize = true;
            Controls.Add(lblMensagem);
        }

        #endregion
    }
}