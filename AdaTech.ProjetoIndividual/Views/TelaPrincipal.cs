using AdaTech.ProjetoIndividual.Controllers;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.Views
{
    public partial class TelaPrincipal : Form
    {
        internal TelaPrincipal(Usuario usuario)
        {
            Load += OnLoad;
            FormClosing += OnFormClosing;
            this._usuarioLogado = usuario;
            this._telaPrincipalController = new TelaPrincipalController(usuario);
        }

        private void OnLoad(object sender, EventArgs e)
        {

            InitializeComponent();

            SelecionarInterface(_telaPrincipalController.FiltrarLogin());
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !_confirmacaoSaidaExibida)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    _confirmacaoSaidaExibida = true;
                    Application.Exit();
                }
            }
        }

        private void SelecionarInterface(string tipoUsuarioLogado)
        {

            switch (tipoUsuarioLogado)
            {
                case "Desenvolvedor":
                    CriarPainelDesenvolvedor();
                    break;
                case "Tech Leader":
                    CriarPainelTechLeader();
                    break;
                case "Administrador":
                    CriarPainelAdm();
                    break;
            }

            Controls.Add(_painelTelaPrincipal);
        }
        #region Painel Desenvolvedor
        private void CriarPainelDesenvolvedor()
        {
            _painelTelaPrincipal.Controls.Clear();
        }
        #endregion

        #region Painel Tech Leader
        private void CriarPainelTechLeader()
        {
            _painelTelaPrincipal.Controls.Clear();
        }
        #endregion

        #region Painel Administrador
        private void CriarPainelAdm()
        {
            _painelTelaPrincipal.Controls.Clear();
        }
        #endregion

        private void OnClickLogout(object sender, EventArgs e)
        {
            _confirmacaoSaidaExibida = true;
            TelaLogin telaLogin = new TelaLogin();
            telaLogin.Show();

            this.Close();
        }
    }
}
