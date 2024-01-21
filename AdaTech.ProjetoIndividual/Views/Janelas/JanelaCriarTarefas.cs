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

namespace AdaTech.ProjetoIndividual.Views.Janelas
{
    public partial class JanelaCriarTarefas : Form
    {
        internal JanelaCriarTarefas(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
            CarregarUsuarios();
            CarregarTarefasRelacionadas();

            this.WindowState = FormWindowState.Maximized;
        }

        private void DateTimePickerDataInicio_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;

            if (dtp.Value > DateTime.Today)
            {
                dtp.Value = DateTime.Today;
            }
        }

        private void DateTimePickerFim_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;

            if (dtp.Value < dateTimePickerDataInicio.Value)
            {
                dtp.Value = dateTimePickerDataInicio.Value;
            }
        }
        private void CarregarUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            if (usuarioLogado is TechLeader)
            {
                List<Usuario> usuarios = UsuariosData.ListarUsuariosAtivos();
                listaUsuarios.AddRange(usuarios);
            }
            else
            {
                listaUsuarios.Add(usuarioLogado);
            }

            cmbUsuario.DataSource = listaUsuarios;
            cmbUsuario.DisplayMember = "NomeEstilo";
        }


        private void CarregarTarefasRelacionadas()
        {
            List<Tarefas> tarefas = TarefasData.ListarTarefas();

            listBoxTarefasRelacionadas.DataSource = tarefas;
            listBoxTarefasRelacionadas.DisplayMember = "NomeEstilo";
            listBoxTarefasRelacionadas.SelectionMode = SelectionMode.MultiSimple;
        }


        private void btnCadastrarTarefa_Click(object sender, EventArgs e)
        {
            if (txtTitulo != null && txtDescricao != null && cmbPrioridade.SelectedItem != null && cmbTamanho.SelectedItem != null && cmbUsuario.SelectedItem != null)
            {
                string titulo = txtTitulo.Text;
                string descricao = txtDescricao.Text;
                DateTime dataInicio = dateTimePickerDataInicio.Value;
                TipoPrioridade prioridade = (TipoPrioridade)cmbPrioridade.SelectedItem;
                Usuario usuarioResponsavel = cmbUsuario.SelectedItem as Usuario;
                DateTime dataFim = dateTimePickerFim.Value;
                TipoTamanho tamanho = (TipoTamanho)cmbTamanho.SelectedItem; ;

                List<int> idTarefasRelacionadas = ObterIdsTarefasRelacionadas();
                if (TarefasData.AdicionarTarefa(titulo, descricao, dataInicio, prioridade, usuarioResponsavel, dataFim, tamanho, usuarioResponsavel.TipoUsuario, idTarefasRelacionadas))
                {
                    lblMensagem.Text = "Tarefa cadastrada com sucesso!";
                    lblMensagem.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMensagem.Text = "Erro ao cadastrar a tarefa. Verifique os campos!";
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                }

                LimparCampos();
            }
            else
            {
                MessageBox.Show("Preencha todos os campos necessários");
            }
        }

        private List<int> ObterIdsTarefasRelacionadas()
        {
            List<int> ids = new List<int>();

            foreach (Tarefas tarefa in listBoxTarefasRelacionadas.SelectedItems)
            {
                ids.Add(tarefa.Id);
            }

            return ids;
        }

        private void LimparCampos()
        {
            txtTitulo.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            dateTimePickerDataInicio.Value = DateTime.Today;
            cmbPrioridade.SelectedIndex = -1;
            cmbUsuario.SelectedIndex = -1;
            dateTimePickerFim.Value = DateTime.Today;
            listBoxTarefasRelacionadas.ClearSelected();
        }
    }
}
