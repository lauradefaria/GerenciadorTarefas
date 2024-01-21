using AdaTech.ProjetoIndividual.Models.Business.DataBusiness;
using AdaTech.ProjetoIndividual.Models.Business.TarefasBusiness;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;
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

namespace AdaTech.ProjetoIndividual.Views.Janelas.JanelaAdm
{
    public partial class JanelaRemoverUsuario : Form
    {
        public JanelaRemoverUsuario()
        {
            InitializeComponent();
            CarregarUsuarios();
        }

        private void CarregarUsuarios()
        {
            List<Usuario> usuarios = UsuariosData.ListarUsuariosAtivos();
            
            foreach(Usuario user in usuarios)
            {
                if(user.TipoUsuario == TipoUsuario.Administrador)
                {
                    usuarios.Remove(user);
                }
            }

            cmbUsuario.DataSource = usuarios;
            cmbUsuario.DisplayMember = "NomeEstilo";
        }

        private void btnRemoverUsuarioClick(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedItem != null)
            {
                Usuario usuario = cmbUsuario.SelectedItem as Usuario;

                if (UsuariosData.ExcluirUsuario(usuario))
                {
                    lblMensagem.Text = "Usuario excluido com sucesso!";
                    lblMensagem.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMensagem.Text = "Erro ao excluir usuario. Verifique os campos";
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                }

                LimparCampos();
            }
            else
            {
                MessageBox.Show("Escolha um usuário para excluir");
            }
        }

        private void LimparCampos()
        {
            cmbUsuario.SelectedIndex = -1;
        }
    }
}
