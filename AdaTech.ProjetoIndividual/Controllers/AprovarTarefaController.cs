using AdaTech.ProjetoIndividual.Models.Business.DataBusiness;
using AdaTech.ProjetoIndividual.Models.Business.TarefasBusiness;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness.Enums;
using AdaTech.ProjetoIndividual.Views.Janelas.JanelasTechLeader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoIndividual.Controllers
{
    internal class AprovarTarefaController
    {
        private readonly JanelaAprovarTarefas _form;

        internal AprovarTarefaController(JanelaAprovarTarefas form)
        {
            _form = form;
            _form.btnAprovarClick += btnAprovarClick;
            _form.btnReprovarClick += btnReprovarClick;
        }

        internal void CarregarTarefas()
        {
            List<Tarefas> tarefas = TarefasData.ListarTarefas();
            List<Tarefas> lista = new List<Tarefas>();

            foreach (Tarefas tarefa in tarefas)
            {
                if (tarefa.Status == _form.Status)
                {
                    lista.Add(tarefa);
                }
            }

            if (tarefas == null)
            {
                _form.MostrarMensagem("O usuário não possui nenhuma tarefa para aprovar", 'r');
            }

            _form.CmbTarefas.DataSource = lista;
            _form.CmbTarefas.DisplayMember = "NomeEstilo";
        }

        private void btnAprovarClick(object sender, EventArgs e)
        {
            if (_form.CmbTarefas.SelectedItem != null)
            {
                Tarefas tarefa = _form.CmbTarefas.SelectedItem as Tarefas;
                StatusTarefa status;

                if(_form.Status == StatusTarefa.Analise)
                {
                    status = StatusTarefa.Concluida;
                }
                else
                {
                    status = StatusTarefa.EmAndamento;
                }


                if (tarefa != null && TarefasData.AlterarStatus(tarefa, status))
                {
                    _form.MostrarMensagem("Tarefa aprovada com sucesso!", 'g');
                }
                else
                {
                    _form.MostrarMensagem("Erro ao aprovar a tarefa. Verifique os campos", 'r');
                }

                LimparCampos();
            }
            else
            {
                _form.MostrarMensagem("Erro ao aprovar a tarefa.Verifique os campos", 'r');
            }
        }

        internal void LimparCampos()
        {
            _form.CmbTarefas.SelectedIndex = -1;
            CarregarTarefas();
        }
    
        private void btnReprovarClick(object sender, EventArgs e)
        {
            if (_form.CmbTarefas.SelectedItem != null)
            {
                Tarefas tarefa = _form.CmbTarefas.SelectedItem as Tarefas;
                StatusTarefa status = StatusTarefa.Pendente;

                if (_form.Status == StatusTarefa.Analise)
                {
                    status = StatusTarefa.EmAndamento;

                    if (status != StatusTarefa.Pendente && tarefa != null && TarefasData.AlterarStatus(tarefa, status))
                    {
                        _form.MostrarMensagem("Tarefa reprovada com sucesso!", 'g');
                    }
                    else
                    {
                        _form.MostrarMensagem("Erro ao reprovar a tarefa. Verifique os campos", 'r');
                    }
                }
                else
                {
                    TarefasData.ExcluirTarefa(tarefa);
                    _form.MostrarMensagem("Tarefa reprovada com sucesso!", 'g');

                }

                LimparCampos();
            }
            else
            {
                _form.MostrarMensagem("Erro ao reprovar a tarefa.Verifique os campos", 'r');
            }
        }
    }
}
