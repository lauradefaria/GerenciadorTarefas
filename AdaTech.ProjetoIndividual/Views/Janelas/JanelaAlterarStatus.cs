using AdaTech.ProjetoIndividual.Controllers;
using AdaTech.ProjetoIndividual.Models.Business.TarefasBusiness;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness.Enums;
using AdaTech.ProjetoIndividual.Models.Data;
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
    public partial class JanelaAlterarStatus : Form
    {
        public event EventHandler btnAlterarStatusClick;

        internal JanelaAlterarStatus()
        {
            InitializeComponent();

            AlterarStatusController controller = new AlterarStatusController(this);

            TarefasData.ConferirAtraso();
            controller.CarregarStatus();
            controller.CarregarTarefas();

            this.WindowState = FormWindowState.Maximized;
        }

        public void MostrarMensagem(string mensagem, char tipo)
        {
            lblMensagem.Text = mensagem;
            if(tipo == 'g'){
                lblMensagem.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
            }
        }

        internal ComboBox CmbStatus { get => cmbStatus; private set => cmbStatus = value; }
        internal ComboBox CmbTarefas { get => cmbTarefas; private set => cmbTarefas = value; }
    }
}
