using AdaTech.ProjetoIndividual.Models.Business.TarefasBusiness;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness.Enums;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;
using AdaTech.ProjetoIndividual.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.Views.Janelas.JanelasTechLeader
{
    public partial class JanelaAlterarResponsavel : Form
    {
        internal JanelaAlterarResponsavel()
        {
            InitializeComponent();
            CarregarUsuarios();
            CarregarTarefas();

            this.WindowState = FormWindowState.Maximized;
        }
        private void CarregarUsuarios()
        {
            List<Usuario> usuarios = UsuariosData.ListarUsuariosAtivos();
            cmbUsuario.DataSource = usuarios;
            cmbUsuario.DisplayMember = "NomeEstilo";
        }


        private void CarregarTarefas()
        {
            List<Tarefas> tarefas = TarefasData.ListarTarefasAtivas();
            cmbTarefas.DataSource = tarefas;
            cmbTarefas.DisplayMember = "NomeEstilo";
        }


        private void btnAlterarResponsavel_Click(object sender, EventArgs e)
        {
            if (cmbTarefas.SelectedItem != null && cmbUsuario.SelectedItem != null)
            {
                Usuario usuarioResponsavel = cmbUsuario.SelectedItem as Usuario;
                Tarefas tarefa = cmbTarefas.SelectedItem as Tarefas;

                if (TarefasData.AlterarResponsavel(tarefa, usuarioResponsavel))
                {
                    lblMensagem.Text = "Tarefa alterada com sucesso!";
                    lblMensagem.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMensagem.Text = "Erro ao alterar a tarefa. Verifique os campos!";
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                }

                LimparCampos();
            }
            else
            {
                MessageBox.Show("Preencha todos os campos necessários");
            }
        }

        private void LimparCampos()
        {
            cmbTarefas.SelectedIndex = -1;
            cmbUsuario.SelectedIndex = -1;
        }
    }
}
