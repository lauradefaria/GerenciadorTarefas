using AdaTech.ProjetoIndividual.Controllers;
using AdaTech.ProjetoIndividual.Models.Business.DataBusiness;
using AdaTech.ProjetoIndividual.Views;

namespace AdaTech.ProjetoIndividual
{
    public partial class TelaLogin : Form
    {
        private readonly TelaInicialController _telaInicialController;

        public TelaLogin()
        {
            Load += OnLoad;
            FormClosing += OnFormClosing;
            this._telaInicialController = new TelaInicialController(this);

            InitializeComponent();

        }


        private void OnLoad(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            largura = this.ClientSize.Width;
            altura = this.ClientSize.Height;
        }


        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void OnClickEntrar(object sender, EventArgs e)
        {
            string usuarioDigitado = txtUsuario.Text = "4455667788";
            string senhaDigitada = txtSenha.Text;

            if (_telaInicialController.RealizarLogin())
            {
                this.Hide();
                var telaPrincipal = new TelaPrincipal(UsuariosData.SelecionarUsuario(usuarioDigitado));
                telaPrincipal.Show();
            }
        }
    }
}
