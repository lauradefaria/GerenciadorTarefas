using AdaTech.ProjetoIndividual.Controllers;
using AdaTech.ProjetoIndividual.Models.Data;
using AdaTech.ProjetoIndividual.Views;

namespace AdaTech.ProjetoIndividual
{
    public partial class TelaLogin : Form
    {
        private readonly TelaInicialController _telaInicialController;


        internal TelaLogin()
        {
            InitializeComponent();
            _telaInicialController = new TelaInicialController(this);
        }

        private void OnClickEntrar(object sender, EventArgs e)
        {

            if (_telaInicialController.RealizarLogin())
            {
                this.Hide();
                TelaPrincipal homePage = new TelaPrincipal(UsuariosData.SelecionarUsuario(TxtUsuario.Text));
                homePage.ShowDialog();
            }
        }
    }
}
