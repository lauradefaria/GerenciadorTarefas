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
    public partial class JanelaTarefasAtivas : Form
    {
        private ListBox listBoxTarefasAtivas = new ListBox();

        public JanelaTarefasAtivas()
        {
            InitializeComponent();
            ConfigurarListBox();

            TarefasAtivasController controller = new TarefasAtivasController(this);
            this.Text = "Visualizar Tarefas Ativas";
        }

        private void ConfigurarListBox()
        {
            listBoxTarefasAtivas.Dock = DockStyle.Fill;
            listBoxTarefasAtivas.ScrollAlwaysVisible = true;
            listBoxTarefasAtivas.SelectionMode = SelectionMode.None;

            Controls.Add(listBoxTarefasAtivas);

            listBoxTarefasAtivas.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxTarefasAtivas.MeasureItem += ListBoxTarefasAtivas_MeasureItem;
            listBoxTarefasAtivas.DrawItem += ListBoxTarefasAtivas_DrawItem;
        }

        public void AdicionarTarefasNaListBox(string infoTarefa)
        {
            listBoxTarefasAtivas.Items.Add(infoTarefa);
        }

        private void ListBoxTarefasAtivas_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        private void ListBoxTarefasAtivas_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.Graphics.DrawString(listBoxTarefasAtivas.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 5);

            e.Graphics.DrawLine(Pens.Gray, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }
    }
}
