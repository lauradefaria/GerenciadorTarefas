using AdaTech.ProjetoIndividual.Models.Business.TarefasBusiness;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness.Enums;
using AdaTech.ProjetoIndividual.Models.Data;
using AdaTech.ProjetoIndividual.Views.Janelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoIndividual.Controllers
{
    internal class TarefasDesativadasController
    {
        private JanelaTarefasDesativadas form;

        public TarefasDesativadasController(JanelaTarefasDesativadas form)
        {
            this.form = form;
            form.Load += (sender, e) => ExibirTarefas();
        }

        public void ExibirTarefas()
        {
            List<Tarefas> listaTarefas = TarefasData.ListarTarefas();

            foreach (Tarefas tarefa in listaTarefas)
            {
                string infoTarefa = $"{tarefa.Titulo} - Prioridade {tarefa.Prioridade} - Data Início: {tarefa.DataInicio.ToShortDateString()} - {tarefa.Status} - Responsável: {tarefa.NomeResponsavel} - Id tarefa: {tarefa.Id}";

                if (tarefa.Status == StatusTarefa.Concluida || tarefa.Status == StatusTarefa.Cancelada || tarefa.Status == StatusTarefa.Pendente)
                {
                    form.AdicionarTarefasNaListBox(infoTarefa);
                }
            }
        }
    }
}
