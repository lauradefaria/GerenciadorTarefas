using AdaTech.ProjetoIndividual.Models.Business.DataBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoIndividual.Controllers
{
    internal class TelaInicialController
    {
        private readonly TelaLogin _telaLogin;

        internal TelaInicialController(TelaLogin telaLogin)
        {
            _telaLogin = telaLogin;
        }

        internal bool RealizarLogin()
        {
            bool verificador = false;
            try
            {
                var usuario = UsuariosData.SelecionarUsuario(_telaLogin.TxtUsuario.Text);
                if (_telaLogin.TxtUsuario.Text != null && usuario != null && _telaLogin.TxtUsuario.Text == usuario.Cpf && usuario.Ativo)
                {
                    if (usuario.FazerLogin(_telaLogin.TxtUsuario.Text, _telaLogin.TxtSenha.Text))
                    {
                        MessageBox.Show("Login realizado com sucesso!");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Senha incorreta!");
                        return verificador;
                    }
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado! Verifique se está ativo!");
                }
            }
            catch
            {
                MessageBox.Show("Usuário não encontrado!");
            }
            return verificador;

        }
    }
}
