using AdaTech.ProjetoIndividual.Models.Business.TarefasBusiness;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness.Enums;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;
using AdaTech.ProjetoIndividual.Models.Data;
using AdaTech.ProjetoIndividual.Views.Janelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaTech.ProjetoIndividual.Views.Janelas.JanelasTechLeader;

namespace AdaTech.ProjetoIndividual.Controllers
{
    internal class ListaEstatisticasController
    {
        private JanelaListaEstatistica form;

        public ListaEstatisticasController(JanelaListaEstatistica form)
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

                if(tarefa.Status == form.Status)
                {
                    form.AdicionarTarefasNaListBox(infoTarefa);
                }

            }
        }
    }
}
