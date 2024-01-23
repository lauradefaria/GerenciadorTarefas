using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;

namespace AdaTech.ProjetoIndividual.Views.Janelas.JanelaAdm
{
    partial class JanelaRemoverUsuario
    {
        private ComboBox cmbUsuario;
        private Button btnRemoverUsuario;
        private Label lblMensagem;
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
            this.Text = "Janela Remover Usuario";

            cmbUsuario = new ComboBox();
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.Location = new System.Drawing.Point(20, 20);
            cmbUsuario.Size = new System.Drawing.Size(300, 25);
            Controls.Add(cmbUsuario);

            Label lblUsuario = new Label();
            lblUsuario.Text = "Usuário Responsável:";
            lblUsuario.Location = new System.Drawing.Point(330, 20);
            lblUsuario.AutoSize = true;
            Controls.Add(lblUsuario);

            btnRemoverUsuario = new Button();
            btnRemoverUsuario.Text = "Remover Usuario";
            btnRemoverUsuario.Location = new System.Drawing.Point(20, 330);
            btnRemoverUsuario.Click += btnRemoverUsuarioClick;
            Controls.Add(btnRemoverUsuario);

            lblMensagem = new Label();
            lblMensagem.Location = new System.Drawing.Point(20, 520);
            lblMensagem.AutoSize = true;
            Controls.Add(lblMensagem);
        }

        #endregion
    }
}