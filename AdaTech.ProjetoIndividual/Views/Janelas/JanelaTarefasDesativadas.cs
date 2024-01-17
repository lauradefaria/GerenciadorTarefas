using AdaTech.ProjetoIndividual.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.Views.Janelas
{
    public partial class JanelaTarefasDesativadas : Form
    {
        private ListBox listBoxTarefasDesativadas = new ListBox();

        public JanelaTarefasDesativadas()
        {
            InitializeComponent();
            ConfigurarListBox();

            TarefasDesativadasController controller = new TarefasDesativadasController(this);
            this.Text = "Visualizar Tarefas Ativas";
        }

        private void ConfigurarListBox()
        {
            listBoxTarefasDesativadas.Dock = DockStyle.Fill;
            listBoxTarefasDesativadas.ScrollAlwaysVisible = true;
            listBoxTarefasDesativadas.SelectionMode = SelectionMode.None;

            Controls.Add(listBoxTarefasDesativadas);

            listBoxTarefasDesativadas.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxTarefasDesativadas.MeasureItem += ListBoxTarefasDesativadas_MeasureItem;
            listBoxTarefasDesativadas.DrawItem += ListBoxTarefasDesativadas_DrawItem;
        }

        public void AdicionarTarefasNaListBox(string infoTarefa)
        {
            listBoxTarefasDesativadas.Items.Add(infoTarefa);
        }

        private void ListBoxTarefasDesativadas_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        private void ListBoxTarefasDesativadas_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.Graphics.DrawString(listBoxTarefasDesativadas.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 5);

            e.Graphics.DrawLine(Pens.Gray, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }
    }
}
