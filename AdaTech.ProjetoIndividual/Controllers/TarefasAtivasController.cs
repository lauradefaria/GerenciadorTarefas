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
    internal class TarefasAtivasController
    {
        private JanelaTarefasAtivas form;

        public TarefasAtivasController(JanelaTarefasAtivas form)
        {
            this.form = form;
            form.Load += (sender, e) => ExibirTarefas();
        }

        public void ExibirTarefas()
        {
            List<Tarefas> listaTarefas = TarefasData.ListarTarefas();

            foreach (Tarefas tarefa in listaTarefas)
            {
                string infoTarefa = $"{tarefa.Titulo} - Prioridade {tarefa.Prioridade} - Data Início: {tarefa.DataInicio.ToShortDateString()} - {tarefa.Status} - Id tarefa: {tarefa.Id}";

                if (tarefa.Status == StatusTarefa.EmAndamento || tarefa.Status == StatusTarefa.Atrasada || tarefa.Status == StatusTarefa.Impedimento || tarefa.Status == StatusTarefa.Analise)
                {
                    form.AdicionarTarefasNaListBox(infoTarefa);
                }
            }
        }
    }
}
