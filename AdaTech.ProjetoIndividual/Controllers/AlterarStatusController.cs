using AdaTech.ProjetoIndividual.Models.Business.TarefasBusiness;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness.Enums;
using AdaTech.ProjetoIndividual.Models.Data;
using AdaTech.ProjetoIndividual.Views.Janelas.JanelasTechLeader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoIndividual.Controllers
{
    internal class AlterarStatusController
    {
        private readonly JanelaAlterarStatus _alterarStatus;

        internal AlterarStatusController(JanelaAlterarStatus alterarStatus)
        {
            _alterarStatus = alterarStatus;
            _alterarStatus.btnAlterarStatusClick += btnAlterarStatusClick;
        }

        internal void CarregarStatus()
        {
            _alterarStatus.CmbStatus.DisplayMember = "NomeEstilo";
            if (UsuariosData.UsuarioLogado().TipoUsuario == TipoUsuario.Desenvolvedor)
            {
                _alterarStatus.CmbStatus.DataSource = new List<string> { "Em Andamento", "Análise", "Impedimento" };
            }
            else
            {
                _alterarStatus.CmbStatus.DataSource = new List<string> { "Em Andamento", "Análise", "Impedimento", "Abandonada" };
            }
        }


        internal void CarregarTarefas()
        {
            TarefasData.ConferirAtraso();
            List<Tarefas> tarefas = TarefasData.ListarTarefasAtivas();

            _alterarStatus.CmbTarefas.DataSource = tarefas;
            _alterarStatus.CmbTarefas.DisplayMember = "NomeEstilo";
        }

        private void btnAlterarStatusClick(object sender, EventArgs e)
        {
            if (_alterarStatus.CmbTarefas.SelectedItem != null && _alterarStatus.CmbStatus.SelectedItem != null)
            {
                Tarefas tarefa = _alterarStatus.CmbTarefas.SelectedItem as Tarefas;
                StatusTarefa status = EscolheStatus(tarefa.Status);

                if (tarefa.Status == StatusTarefa.Atrasada && status == StatusTarefa.EmAndamento)
                {
                    _alterarStatus.MostrarMensagem("A tarefa já está em andamento, não é permitido mudar o status de atraso", 'r');
                }
                else
                {
                    if (TarefasData.AlterarStatus(tarefa, status))
                    {
                        _alterarStatus.MostrarMensagem("Tarefa alterada com sucesso!", 'g');
                    }
                    else
                    {
                        _alterarStatus.MostrarMensagem("Erro ao alterar a tarefa. Verifique os campos", 'r');
                    }

                    LimparCampos();
                }
            }
            else
            {
                _alterarStatus.MostrarMensagem("Preencha todos os campos necessários", 'r');
            }
        }

        internal void LimparCampos()
        {
            _alterarStatus.CmbTarefas.SelectedIndex = -1;
            _alterarStatus.CmbStatus.SelectedIndex = -1;
        }

        internal StatusTarefa EscolheStatus(StatusTarefa statusAtual)
        {
            if (_alterarStatus.CmbStatus.Text == "Impedimento")
            {
                return StatusTarefa.Impedimento;
            }

            if (_alterarStatus.CmbStatus.Text == "Análise")
            {
                return StatusTarefa.Analise;
            }

            if (_alterarStatus.CmbStatus.Text == "Em Andamento")
            {
                return StatusTarefa.EmAndamento;
            }
            if (_alterarStatus.CmbStatus.Text == "Abandonada")
            {
                return StatusTarefa.Cancelada;
            }
            return statusAtual;
        }
    }
}
