using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness.Enums;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaTech.ProjetoIndividual.Models.Data;

namespace AdaTech.ProjetoIndividual.Models.Business.TarefasBusiness
{
    internal class Tarefas
    {
        private int _id;
        private string _titulo;
        private string _descricao;
        private DateTime _dataInicio;
        private DateTime _dataFimPrevista;
        private TipoTamanho _tamanho;
        private StatusTarefa _status;
        private TipoPrioridade _prioridade;
        private DateTime _dataConclusao;
        private DateTime _dataCancelamento;
        private Usuario _usuario;
        private List<int> _tarefasRelacionadas;

        public int Id { get => _id; set => _id = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Descricao { get => _descricao; set => _descricao = value; }
        public DateTime DataInicio { get => _dataInicio; set => _dataInicio = value; }
        public DateTime DataFimPrevista { get => _dataFimPrevista; set => _dataFimPrevista = value; }
        public StatusTarefa Status { get => _status; set => _status = value; }
        public TipoPrioridade Prioridade { get => _prioridade; set => _prioridade = value; }
        public DateTime DataConclusao { get => _dataConclusao; set => _dataConclusao = value; }
        public DateTime DataCancelamento { get => _dataCancelamento; set => _dataCancelamento = value; }
        public Usuario Responsavel { get => _usuario; set => _usuario = value; }
        public List<int> TarefasRelacionadas { get => _tarefasRelacionadas; set => _tarefasRelacionadas = value; }

        public string NomeResponsavel { get => _usuario.Nome; }

        public string NomeEstilo
        {
            get
            {
                return $"{Id} - {Titulo}";
            }
        }
        public TipoTamanho TipoTamanho
        {
            get { return _tamanho; }
            set { _tamanho = value; }
        }
        public TipoUsuario TipoUsuario
        {
            get
            {
                return _usuario.TipoUsuario;
            }
        }


        internal Tarefas(string titulo, string descricao, DateTime dataInicio, TipoPrioridade prioridade, Usuario usuario, DateTime fim, TipoTamanho tamanho, TipoUsuario tipo, List<int> tarefasRelacionada = null)
        {
            _titulo = titulo;
            _descricao = descricao;
            _dataInicio = dataInicio;
            _dataFimPrevista = fim;
            _prioridade = prioridade;
            _usuario = usuario;
            _tamanho = tamanho;
            _tarefasRelacionadas = tarefasRelacionada;

            if (tipo == TipoUsuario.Desenvolvedor)
            {
                _status = StatusTarefa.Pendente;
            }
            else
            {
                if (fim >= DateTime.Now)
                {
                    _status = StatusTarefa.EmAndamento;
                }
                else
                {
                    _status = StatusTarefa.Atrasada;
                }
            }

            _id = GerarId();
        }

        internal Tarefas(int id, string titulo, string descricao, DateTime dataInicio, DateTime fim, TipoPrioridade prioridade, string usuarioCpf, TipoTamanho tamanho, StatusTarefa status, List<int> tarefasRelacionada = null)
        {
            _titulo = titulo;
            _descricao = descricao;
            _dataInicio = dataInicio;
            _dataFimPrevista = fim;
            _prioridade = prioridade;
            _usuario = UsuariosData.SelecionarUsuario(usuarioCpf);
            _tarefasRelacionadas = tarefasRelacionada;
            _id = id;
            _status = status;
        }

        internal int GerarId()
        {
            int id;
            do
            {
                id = new Random().Next(1, 1000);
            } while (TarefasData.VerificarId(_id));

            return id;
        }
    }
}
