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
    public partial class JanelaListaEstatistica : Form
    {
        private ListBox listBoxTarefas = new ListBox();
        private StatusTarefa _status;

        internal StatusTarefa Status
        {
            get { return _status; }
            set { _status = value; }
        }

        internal JanelaListaEstatistica(StatusTarefa status)
        {
            InitializeComponent();
            ConfigurarListBox();
            _status = status;  

            ListaEstatisticasController controller = new ListaEstatisticasController(this);
            this.Text = "Visualizar Estatíticas";
        }

        private void ConfigurarListBox()
        {
            listBoxTarefas.Dock = DockStyle.Fill;
            listBoxTarefas.ScrollAlwaysVisible = true;
            listBoxTarefas.SelectionMode = SelectionMode.None;

            Controls.Add(listBoxTarefas);

            listBoxTarefas.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxTarefas.MeasureItem += listBoxTarefas_MeasureItem;
            listBoxTarefas.DrawItem += listBoxTarefas_DrawItem;
        }

        public void AdicionarTarefasNaListBox(string infoTarefa)
        {
            listBoxTarefas.Items.Add(infoTarefa);
        }

        private void listBoxTarefas_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        private void listBoxTarefas_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.Graphics.DrawString(listBoxTarefas.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 5);

            e.Graphics.DrawLine(Pens.Gray, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }
    }
}
