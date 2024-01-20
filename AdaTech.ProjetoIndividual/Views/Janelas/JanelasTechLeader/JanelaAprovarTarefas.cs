using AdaTech.ProjetoIndividual.Controllers;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness.Enums;
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
    public partial class JanelaAprovarTarefas : Form
    {
        public event EventHandler btnAprovarClick;
        public event EventHandler btnReprovarClick;
        private StatusTarefa _status;

        internal StatusTarefa Status
        {
            get { return _status; }
            set { _status = value; }
        }

        internal JanelaAprovarTarefas(StatusTarefa status)
        {
            InitializeComponent();
            _status = status;

            AprovarTarefaController controller = new AprovarTarefaController(this);
            controller.CarregarTarefas();

            this.WindowState = FormWindowState.Maximized;
        }

        public void MostrarMensagem(string mensagem, char tipo)
        {
            lblMensagem.Text = mensagem;
            if (tipo == 'g')
            {
                lblMensagem.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
            }
        }

        internal ComboBox CmbTarefas { get => cmbTarefas; private set => cmbTarefas = value; }
    }
}
