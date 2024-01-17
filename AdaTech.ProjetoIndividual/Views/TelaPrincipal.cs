using AdaTech.ProjetoIndividual.Controllers;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;
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

namespace AdaTech.ProjetoIndividual.Views
{
    public partial class TelaPrincipal : Form
    {
        internal TelaPrincipal(Usuario usuario)
        {
            Load += OnLoad;
            FormClosing += OnFormClosing;
            this._usuarioLogado = usuario;
            UsuariosData.SetUsuarioLogado(usuario);
            this._telaPrincipalController = new TelaPrincipalController(usuario);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            int larguraTela = this.ClientSize.Width;
            int alturaTela = this.ClientSize.Height;

            SelecionarInterface(_telaPrincipalController.FiltrarLogin(), InitializeComponent(larguraTela, alturaTela));
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !_confirmacaoSaidaExibida)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    _confirmacaoSaidaExibida = true;
                    Application.Exit();
                }
            }
        }

        private void SelecionarInterface(string tipoUsuarioLogado, Panel painel)
        {

            switch (tipoUsuarioLogado)
            {
                case "Desenvolvedor":
                    CriarPainelDesenvolvedor(painel);
                    break;
                case "Tech Leader":
                    CriarPainelTechLeader(painel);
                    break;
                case "Administrador":
                    CriarPainelAdm(painel);
                    break;
            }

            if (painel != null)
            {
                Controls.Add(painel);
            }
        }
        #region Painel Desenvolvedor
        private Panel CriarPainelDesenvolvedor(Panel painelDesenvolvedor)
        {
            painelDesenvolvedor.Controls.Clear();
                        
            return painelDesenvolvedor;
        }
        #endregion

        #region Painel Tech Leader
        private Panel CriarPainelTechLeader(Panel painelTechLeader)
        {
            painelTechLeader.Controls.Clear();

            #region Botão VizualizarTarefas

            Button bntVisualizarTarefas = new Button();
            bntVisualizarTarefas.Size = new Size(160, 30);
            bntVisualizarTarefas.Location = new Point(20, 50);
            bntVisualizarTarefas.Anchor = AnchorStyles.Right;
            bntVisualizarTarefas.Text = "Visualizar Tarefas";
            bntVisualizarTarefas.Click += OnClickVisualizarTarefas;

            #endregion

            #region Botão CriarTarefas

            Button bntCriarTarefas = new Button();
            bntCriarTarefas.Size = new Size(160, 30);
            bntCriarTarefas.Location = new Point(20, 90);
            bntCriarTarefas.Anchor = AnchorStyles.Right;
            bntCriarTarefas.Text = "Criar Tarefa";
            bntCriarTarefas.Click += OnClickCriarTarefas;

            #endregion

            #region Botão AlterarStatus

            Button bntAlterarStatus = new Button();
            bntAlterarStatus.Size = new Size(160, 30);
            bntAlterarStatus.Location = new Point(20, 130);
            bntAlterarStatus.Anchor = AnchorStyles.Right;
            bntAlterarStatus.Text = "Alterar Status";
            bntAlterarStatus.Click += OnClickAlterarStatus;

            #endregion

            #region Botão AlterarResponsavel

            Button bntAlterarResponsavel = new Button();
            bntAlterarResponsavel.Size = new Size(160, 30);
            bntAlterarResponsavel.Location = new Point(20, 170);
            bntAlterarResponsavel.Anchor = AnchorStyles.Right;
            bntAlterarResponsavel.Text = "Alterar Responsavel";
            bntAlterarResponsavel.Click += OnClickAlterarResponsavel;

            #endregion

            #region Botão Estatísticas

            Button bntEstatistica = new Button();
            bntEstatistica.Size = new Size(160, 30);
            bntEstatistica.Location = new Point(20, 210);
            bntEstatistica.Anchor = AnchorStyles.Right;
            bntEstatistica.Text = "Estatísticas";
            bntEstatistica.Click += OnClickEstatistica;

            #endregion

            painelTechLeader.Controls.Add(bntVisualizarTarefas);
            painelTechLeader.Controls.Add(bntCriarTarefas);
            painelTechLeader.Controls.Add(bntAlterarStatus);
            painelTechLeader.Controls.Add(bntAlterarResponsavel);
            painelTechLeader.Controls.Add(bntEstatistica);
            return painelTechLeader;
        }
        #endregion

        #region OnClick Tech Leader

        private void OnClickAlterarStatus(object sender, EventArgs e)
        {
            //JanelaAlterarStatus status = new JanelaAlterarStatus();
            //status.ShowDialog();
        }
        private void OnClickAlterarResponsavel(object sender, EventArgs e)
        {
            //JanelaAlterarResponsavel responsavel = new JanelaAlterarResponsavel();
            //responsavel.ShowDialog();
        }
        private void OnClickEstatistica(object sender, EventArgs e)
        {
            //JanelaEstatistica estatistica = new JanelaEstatistica();
            //estatistica.ShowDialog();
        }

        #endregion

        #region Painel Administrador
        private Panel CriarPainelAdm(Panel painelAdm)
        {
            painelAdm.Controls.Clear();
            return painelAdm;
        }
        #endregion

        #region OnClick Em Comum
        private void OnClickVisualizarTarefas(object sender, EventArgs e)
        {
            //JanelaVisualizar visualizar = new JanelaVisualizar();
            //visualizar.ShowDialog();
        }

        private void OnClickCriarTarefas(object sender, EventArgs e)
        {
            //JanelaCriarTarefas criar = new JanelaCriarTarefas();
            //criar.ShowDialog();
        }
        #endregion

        private void OnClickLogout(object sender, EventArgs e)
        {
            _confirmacaoSaidaExibida = true;
            TelaLogin telaLogin = new TelaLogin();
            telaLogin.Show();

            this.Close();
        }
    }
}
