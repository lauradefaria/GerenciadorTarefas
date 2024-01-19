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
            _tarefas.Add(new Tarefas(6, "PlanejarProximoSprint", "Separar issues para a próxima sprint", DateTime.Now, DateTime.Now.AddDays(7), TipoPrioridade.Media, "4455667788", TipoTamanho.M, StatusTarefa.EmAndamento, null));
        }

        internal static List<Tarefas> ListarTarefas()
        {
            return _tarefas;
        }
        internal static List<Tarefas> ListarTarefasAtivas()
        {
            List<Tarefas> lista = new List<Tarefas>();

            foreach(Tarefas tarefa in _tarefas)
            {
                if(tarefa.Status == StatusTarefa.EmAndamento || tarefa.Status == StatusTarefa.Impedimento || tarefa.Status == StatusTarefa.Atrasada)
                {
                    lista.Add(tarefa);
                }
            }

            return lista;
        }

        internal static void ConferirAtraso()
        {
            int contador = 0;

            foreach(Tarefas tarefa in _tarefas)
            {
                if(DateTime.Compare(DateTime.Now, tarefa.DataFimPrevista) >= 0 && tarefa.Status == StatusTarefa.EmAndamento)
                {
                    _tarefas[contador].Status = StatusTarefa.Atrasada;
                }
                contador++;
            }
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
        internal static Tarefas SelecionarTarefa(int idTarefa)
        {
            foreach (Tarefas tarefa in _tarefas)
            {
                if (tarefa.Id == idTarefa)
                {
                    return tarefa;
                }
            }
            return null;
        }
        internal static void ExcluirTarefa(Tarefas tarefa)
        {
            Tarefas tarefaExc = _tarefas.FirstOrDefault(t => t.Id == tarefa.Id);

            if (tarefaExc != null) 
            {
                _tarefas.Remove(tarefaExc);
            }
        }

        internal static bool AlterarResponsavel(Tarefas tarefaEscolhida, Usuario novoResponsavel)
        {
            int contador = 0;
            bool flag = false;

            foreach (Tarefas tarefa in _tarefas)
            {
                if(tarefa.Id == tarefaEscolhida.Id)
                {
                    _tarefas[contador].Responsavel = novoResponsavel;
                    flag = true;
                    break;
                }
                contador++;
            }

            return flag;
        }

        internal static bool AlterarStatus(Tarefas tarefaEscolhida, StatusTarefa novoStatus)
        {
            int contador = 0;
            bool flag = false;

            foreach (Tarefas tarefa in _tarefas)
            {
                if (tarefa.Id == tarefaEscolhida.Id)
                {
                    _tarefas[contador].Status = novoStatus;
                    flag = true;
                    break;
                }
                contador++;
            }

            return flag;
        }
    }
}
