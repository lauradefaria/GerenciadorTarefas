using AdaTech.ProjetoIndividual.Controllers;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;

namespace AdaTech.ProjetoIndividual.Views
{
    partial class TelaPrincipal
    {
        private bool _confirmacaoSaidaExibida = false;
        private Label _lblBemVindo;
        private Usuario _usuarioLogado;
        private TelaPrincipalController _telaPrincipalController;
        private Panel _painelTelaPrincipal;
        private Button _btnLogout;
        private Button btnVisualizarTarefas;
        private Button btnCriarTarefa;
        private Button btnVisualizarUsuarios;
        private Button btnAlterarSenha;
        private Button btnCadastrarDev;
        private Button btnAdicionarProjeto;
        private Button btnVisualizarProjeto;
        private Button btnCadastrarTechLeader;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            WindowState = FormWindowState.Maximized;
            int largura = this.ClientSize.Width;
            int altura = this.ClientSize.Height;
            this.Text = "Tela Principal";

            _painelTelaPrincipal = new Panel();
            _painelTelaPrincipal.Size = new Size(largura - 200, altura - 200);
            _painelTelaPrincipal.Location = new Point((largura - _painelTelaPrincipal.Width) / 2, (altura - _painelTelaPrincipal.Height) / 2);
            _painelTelaPrincipal.BackColor = Color.LightGray;
            _painelTelaPrincipal.BorderStyle = BorderStyle.FixedSingle;
            _painelTelaPrincipal.Anchor = AnchorStyles.None;
            _painelTelaPrincipal.AutoScroll = true;

            _lblBemVindo = new Label();
            _lblBemVindo.Text = $"Bem-vindo, {_usuarioLogado.Nome}\nCargo: {_telaPrincipalController.FiltrarLogin()} ";
            _lblBemVindo.BackColor = Color.Transparent;
            _lblBemVindo.ForeColor = Color.Black;
            _lblBemVindo.AutoSize = true;
            _lblBemVindo.Font = new Font("Arial", 20, FontStyle.Bold);
            _lblBemVindo.Location = new System.Drawing.Point((largura - _painelTelaPrincipal.Width) / 2, 20);

            _btnLogout = new Button();
            _btnLogout.Size = new Size(100, 30);
            _btnLogout.Location = new Point(_painelTelaPrincipal.Width + 100, _painelTelaPrincipal.Height + 100);
            _btnLogout.Text = "Logout";
            _btnLogout.Click += OnClickLogout;
            
            Controls.Add(_lblBemVindo);
            Controls.Add(_btnLogout);
        }
    }
}