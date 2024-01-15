using AdaTech.ProjetoIndividual.Models.Business.TarefasBusiness;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness.Enums;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoIndividual.Models.Data
{
    internal class TarefasData
    {
        private static List<Tarefas> _tarefas = new List<Tarefas>();

        internal static void CarregarTarefas()
        {
            //_tarefas.Add(new Tarefas("PlanejarProximoSprint", "Separar issues para a próxima sprint", DateTime.Now, 2024 - 05 - 30, "Media", "11122233344", "7", "EmAndamento", "6"));
        }

        internal static List<Tarefas> ListarTarefas()
        {
            return _tarefas;
        }

        internal static bool VerificarId(int id)
        {
            return _tarefas.Any(x => x.Id == id);
            return false;
        }

        internal static List<Tarefas> PesquisarPorId(List<int> id)
        {
            List<Tarefas> listaTarefas = new List<Tarefas>();
            if (id != null)
            {
                return _tarefas.Where(x => id.Contains(x.Id)).ToList();
            }
            return _tarefas;
        }
        internal static bool AdicionarTarefa(string titulo, string descricao, DateTime dataInicio, TipoPrioridade prioridade, Usuario usuario, DateTime fim, TipoTamanho tamanho, TipoUsuario usuarioTipo, List<int> idTarefas)
        {
            try
            {
                List<int> tarefasRelacionadas = idTarefas;
                Tarefas tarefa;

                if (usuarioTipo == TipoUsuario.Desenvolvedor)
                {
                    tarefa = new Tarefas(titulo, descricao, dataInicio, prioridade, usuario, fim, tamanho, TipoUsuario.Desenvolvedor, tarefasRelacionadas);
                }
                else
                {
                    tarefa = new Tarefas(titulo, descricao, dataInicio, prioridade, usuario, fim, tamanho, TipoUsuario.TechLeader, tarefasRelacionadas);
                }

                _tarefas.Add(tarefa);
                return true;
            }
            catch
            {
                return false;
            }
        }
        internal static void ExcluirTarefa(Tarefas tarefa)
        {
            Tarefas tarefaExc = _tarefas.FirstOrDefault(t => t.Id == tarefa.Id);

            if (tarefaExc != null) 
            {
                _tarefas.Remove(tarefaExc);
            }
        }
    }
}
