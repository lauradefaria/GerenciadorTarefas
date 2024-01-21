using AdaTech.ProjetoIndividual.Controllers;
using AdaTech.ProjetoIndividual.Models.Business.DataBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.Views.Janelas.JanelasTechLeader
{
    public partial class JanelaEstatisticas : Form
    {
        private int quantEmAndamento, quantAtrasadas, quantImpedidas, quantAnalise, quantPendente, quantConcluidas, quantCanceladas;
        
        public event EventHandler EmAndamentoClick;
        public event EventHandler AtrasadasClick;
        public event EventHandler ImpedidasClick;
        public event EventHandler ConcluidasClick;
        public event EventHandler AnaliseClick;
        public event EventHandler PendentesClick;
        public event EventHandler CanceladasClick;

        internal int QuantEmAndamento
        {
            get { return quantEmAndamento; }
            set { quantEmAndamento = value;}
        }

        internal int QuantAtrasadas
        {
            get { return quantAtrasadas; }
            set { quantAtrasadas = value;}
        }

        internal int QuantImpedidas
        {
            get { return quantImpedidas; }
            set {  quantImpedidas = value;}
        }

        internal int QuantAnalise
        {
            get { return quantAnalise; }
            set { quantAnalise = value; }
        }

        internal int QuantPendente
        {
            get { return quantPendente; }
            set { quantPendente = value; }
        }

        internal int QuantConcluidas
        {
            get { return quantConcluidas; }
            set { quantConcluidas = value; }
        }

        internal int QuantCanceladas
        {
            get { return quantCanceladas; }
            set { quantCanceladas = value; }
        }

        internal JanelaEstatisticas()
        {
            quantEmAndamento = quantAtrasadas = quantImpedidas = quantAnalise = quantPendente = quantConcluidas = quantCanceladas = 0;
            EstatisticasController controller = new EstatisticasController(this);
            TarefasData.ConferirAtraso();
            controller.CarregarEstatisticas();

            InitializeComponent();
        }

        internal void MostrarMensagem(string mensagem)
        {
            MessageBox.Show(mensagem);
        }
    }
}
