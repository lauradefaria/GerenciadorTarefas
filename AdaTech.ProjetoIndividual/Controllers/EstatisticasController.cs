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
    internal class EstatisticasController
    {
        private readonly JanelaEstatisticas _form;
        internal EstatisticasController(JanelaEstatisticas form)
        {
            _form = form;
            _form.EmAndamentoClick += EmAndamentoClick;
            _form.AtrasadasClick += AtrasadasClick;
            _form.ImpedidasClick += ImpedidasClick;
            _form.ConcluidasClick += ConcluidasClick;
            _form.AnaliseClick += AnaliseClick;
            _form.PendentesClick += PendentesClick;
            _form.CanceladasClick += CanceladasClick;
        }

        internal void CarregarEstatisticas()
        {
            List<Tarefas> tarefas = TarefasData.ListarTarefas();

            foreach(Tarefas tarefa in tarefas)
            {
                switch(tarefa.Status)
                {
                    case StatusTarefa.Analise:
                        _form.QuantAnalise++;
                        break;
                    case StatusTarefa.Atrasada:
                        _form.QuantAtrasadas++;
                        break;
                    case StatusTarefa.Cancelada:
                        _form.QuantCanceladas++;
                        break;
                    case StatusTarefa.Concluida:
                        _form.QuantConcluidas++;
                        break;
                    case StatusTarefa.Pendente:
                        _form.QuantPendente++;
                        break;
                    case StatusTarefa.EmAndamento:
                        _form.QuantEmAndamento++;
                        break;
                    case StatusTarefa.Impedimento:
                        _form.QuantImpedidas++;
                        break;
                    default: 
                        break;
                }
            }
        }

        private void EmAndamentoClick(object sender, EventArgs e)
        {
            JanelaListaEstatistica estatistica = new JanelaListaEstatistica(StatusTarefa.EmAndamento);
            estatistica.ShowDialog();
        }
        private void AtrasadasClick(object sender, EventArgs e)
        {
            JanelaListaEstatistica estatistica = new JanelaListaEstatistica(StatusTarefa.Atrasada);
            estatistica.ShowDialog();
        }
        private void ImpedidasClick(object sender, EventArgs e)
        {
            JanelaListaEstatistica estatistica = new JanelaListaEstatistica(StatusTarefa.Impedimento);
            estatistica.ShowDialog();
        }
        private void ConcluidasClick(object sender, EventArgs e)
        {
            JanelaListaEstatistica estatistica = new JanelaListaEstatistica(StatusTarefa.Concluida);
            estatistica.ShowDialog();
        }
        private void AnaliseClick(object sender, EventArgs e)
        {
            JanelaListaEstatistica estatistica = new JanelaListaEstatistica(StatusTarefa.Analise);
            estatistica.ShowDialog();
        }
        private void PendentesClick(object sender, EventArgs e)
        {
            JanelaListaEstatistica estatistica = new JanelaListaEstatistica(StatusTarefa.Pendente);
            estatistica.ShowDialog();
        }
        private void CanceladasClick(object sender, EventArgs e)
        {
            JanelaListaEstatistica estatistica = new JanelaListaEstatistica(StatusTarefa.Cancelada);
            estatistica.ShowDialog();
        }
    }
}
