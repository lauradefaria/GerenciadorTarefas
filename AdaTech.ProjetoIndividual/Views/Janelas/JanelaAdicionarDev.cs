using AdaTech.ProjetoIndividual.Models.Business.DataBusiness;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.Views.Janelas
{
    public partial class JanelaAdicionarDev : Form
    {
        public JanelaAdicionarDev()
        {
            InitializeComponent();
        }

        private void btnCadastrarDesenvolvedor_Click(object sender, EventArgs e)
        {
            string senha = txtSenha.Text;
            string nome = txtNome.Text;
            string cpf = txtCpf.Text;
            string email = txtEmail.Text;

            if (UsuariosData.VerificarUsuarioExistenteCpf(cpf))
            {
                MessageBox.Show("CPF já cadastrado no sistema. Escolha um CPF diferente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UsuariosData.VerificarUsuarioExistenteEmail(email))
            {
                MessageBox.Show("E-mail já cadastrado no sistema. Escolha um e-mail diferente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(senha != null && cpf != null & email != null && nome != null && UsuariosData.AdicionarUsuario(senha, nome, cpf, email, TipoUsuario.Desenvolvedor))
            {
                MessageBox.Show("Desenvolvedor cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar Desenvolvedor, veifique os campos");
            }
        }

        private void LimparCampos()
        {
            txtSenha.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }
    }
}
