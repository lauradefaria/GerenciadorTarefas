using AdaTech.ProjetoIndividual.Models.Business.TarefasBusiness;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness.Enums;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AdaTech.ProjetoIndividual.Models.Business.DataBusiness
{
    internal class TarefasData
    {
        private static List<Tarefas> _tarefas = new List<Tarefas>();
        private static readonly string _DIRECTORY_PATH = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "\\Data";
        private static readonly string _FILE_PATH = Path.Combine(_DIRECTORY_PATH, "Tarefas.txt");

        internal static void CarregarTarefas()
        {
            _tarefas.Add(new Tarefas(6, "PlanejarProximoSprint", "Separar issues para a próxima sprint", DateTime.Now, DateTime.Now.AddDays(7), TipoPrioridade.Media, "0123456789", TipoTamanho.M, StatusTarefa.Pendente, null));
            _tarefas.Add(new Tarefas(8, "BotãoNaTela", "Acrescentar botão para adicionar CSV", DateTime.Now, DateTime.Now.AddDays(2), TipoPrioridade.Baixa, "4455667788", TipoTamanho.S, StatusTarefa.EmAndamento, null));
            //_tarefas = LerTarefasTxt();
        }

        internal static List<Tarefas> ListarTarefas()
        {
            return _tarefas;
        }
        internal static List<Tarefas> ListarTarefasAtivas()
        {
            List<Tarefas> lista = new List<Tarefas>();

            foreach (Tarefas tarefa in _tarefas)
            {
                if (tarefa.Status == StatusTarefa.EmAndamento || tarefa.Status == StatusTarefa.Impedimento || tarefa.Status == StatusTarefa.Atrasada)
                {
                    lista.Add(tarefa);
                }
            }

            return lista;
        }

        internal static List<Tarefas> ListarTarefasPorStatus(StatusTarefa status)
        {
            List<Tarefas> lista = new List<Tarefas>();

            foreach (Tarefas tarefa in _tarefas)
            {
                if (tarefa.Status == status)
                {
                    lista.Add(tarefa);
                }
            }

            return lista;
        }

        internal static void ConferirAtraso()
        {
            int contador = 0;

            foreach (Tarefas tarefa in _tarefas)
            {
                if (DateTime.Compare(DateTime.Now, tarefa.DataFimPrevista) >= 0 && tarefa.Status == StatusTarefa.EmAndamento)
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

                if (UsuariosData.UsuarioLogado().TipoUsuario == TipoUsuario.Desenvolvedor)
                {
                    tarefa = new Tarefas(titulo, descricao, dataInicio, prioridade, usuario, fim, tamanho, TipoUsuario.Desenvolvedor, tarefasRelacionadas);
                }
                else
                {
                    tarefa = new Tarefas(titulo, descricao, dataInicio, prioridade, usuario, fim, tamanho, TipoUsuario.TechLeader, tarefasRelacionadas);
                }

                _tarefas.Add(tarefa);
                //SalvarTarefasTxt(_tarefas);
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
                //SalvarTarefasTxt(_tarefas);
            }
        }

        internal static bool AlterarResponsavel(Tarefas tarefaEscolhida, Usuario novoResponsavel)
        {
            int contador = 0;
            bool flag = false;

            foreach (Tarefas tarefa in _tarefas)
            {
                if (tarefa.Id == tarefaEscolhida.Id)
                {
                    _tarefas[contador].Responsavel = novoResponsavel;
                    flag = true;
                    break;
                }
                contador++;
            }

            if (flag)
            {
                //SalvarTarefasTxt(_tarefas);
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

            if (flag)
            {
               // SalvarTarefasTxt(_tarefas);
            }

            return flag;
        }

        internal static List<Tarefas> LerTarefasTxt()
        {
            var tarefas = new List<Tarefas>();

            if (File.Exists(_FILE_PATH))
            {
                using (StreamReader sr = new StreamReader(_FILE_PATH))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        Tarefas tarefa = ConverterLinha(linha);
                        tarefas.Add(tarefa);
                    }
                }
            }
            return tarefas;
        }

        internal static Tarefas ConverterLinha(string linha)
        {
            var dados = linha.Split(',');
            var titulo = dados[1];
            var descricao = dados[2];
            var dataInicio = DateTime.Parse(dados[3]);
            var dataFimPrevista = DateTime.Parse(dados[4]);
            var prioridade = (TipoPrioridade)Enum.Parse(typeof(TipoPrioridade), dados[5]);
            Usuario usuario = UsuariosData.SelecionarUsuario(dados[6]);
            var tamanho = (TipoTamanho)Enum.Parse(typeof(TipoTamanho), dados[7]);
            var status = (StatusTarefa)Enum.Parse(typeof(StatusTarefa), dados[8]);
            var id = int.Parse(dados[0]);

            var tarefa = new Tarefas(id, titulo, descricao, dataInicio, dataFimPrevista, prioridade, usuario.Cpf, tamanho, status, null);

            if (dados.Length >= 9)
            {
                List<int> idTarefas = dados[9].Split('/').Select(x => int.Parse(x)).ToList();
                tarefa.TarefasRelacionadas = idTarefas;
            }

            return tarefa;
        }

        internal static void SalvarTarefasTxt(List<Tarefas> tarefas)
        {
            try
            {
                List<string> linhas = new List<string>();

                foreach (var tarefa in tarefas)
                {
                    string dataConclusao = tarefa.DataConclusao.Date.ToString("yyyy-MM-dd");
                    if (tarefa.DataConclusao == DateTime.MinValue)
                    {
                        dataConclusao = "";
                    }

                    var linha = $"{tarefa.Titulo},{tarefa.Descricao},{tarefa.DataInicio.Date.ToString("yyyy-MM-dd")},{tarefa.DataFimPrevista.Date.ToString("yyyy-MM-dd")}," +
                    $"{tarefa.Prioridade},{tarefa.Responsavel.Cpf},{tarefa.Id},{tarefa.Status},{dataConclusao}," +
                    $"{string.Join("/", tarefa.TarefasRelacionadas)}";

                    linhas.Add(linha);
                }


                File.AppendAllLines(_FILE_PATH, linhas);

                _tarefas = LerTarefasTxt();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar tarefas", ex);
            }
        }
    }
}
