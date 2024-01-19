using AdaTech.ProjetoIndividual.Controllers;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;
using AdaTech.ProjetoIndividual.Models.Data;
using AdaTech.ProjetoIndividual.Views.Janelas;
using AdaTech.ProjetoIndividual.Views.Janelas.JanelasTechLeader;
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

            SelecionarInterface(_telaPrincipalController.FiltrarLogin(), InicializarComponente(larguraTela, alturaTela));
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

        private Panel InicializarComponente(int largura, int altura)
        {
            var painelLogin = new Panel();
            painelLogin.Size = new Size(largura - 200, altura - 200);
            painelLogin.Location = new Point((largura - painelLogin.Width) / 2, (altura - painelLogin.Height) / 2);
            painelLogin.BackColor = Color.LightGray;
            painelLogin.BorderStyle = BorderStyle.FixedSingle;
            painelLogin.Anchor = AnchorStyles.None;
            painelLogin.AutoScroll = true;

            _lblBemVindo = new Label();
            _lblBemVindo.Text = $"Bem-vindo, {_usuarioLogado.Nome}\nCargo: {_telaPrincipalController.FiltrarLogin()} ";
            _lblBemVindo.BackColor = Color.Transparent;
            _lblBemVindo.ForeColor = Color.Black;
            _lblBemVindo.AutoSize = true;
            _lblBemVindo.Font = new Font("Arial", 20, FontStyle.Bold);
            _lblBemVindo.Location = new System.Drawing.Point((largura - painelLogin.Width) / 2, 20);

            Button btnLogout = new Button();
            btnLogout.Size = new Size(100, 30);
            btnLogout.Location = new Point(painelLogin.Width + 100, painelLogin.Height + 100);
            btnLogout.Text = "Logout";
            btnLogout.Click += OnClickLogout;

            Controls.Add(_lblBemVindo);
            Controls.Add(btnLogout);

            return painelLogin;
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

            painelDesenvolvedor.Controls.Add(bntVisualizarTarefas);
            painelDesenvolvedor.Controls.Add(bntCriarTarefas);
            painelDesenvolvedor.Controls.Add(bntAlterarStatus);
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

            #region Botão AdicionarDesenvolvedor

            Button bntAdicionarDesenvolvedor = new Button();
            bntAdicionarDesenvolvedor.Size = new Size(160, 30);
            bntAdicionarDesenvolvedor.Location = new Point(20, 250);
            bntAdicionarDesenvolvedor.Anchor = AnchorStyles.Right;
            bntAdicionarDesenvolvedor.Text = "Adicionar Desenvolvedor";
            bntAdicionarDesenvolvedor.Click += OnClickAdicionarDesenvolvedor;

            #endregion

            painelTechLeader.Controls.Add(bntVisualizarTarefas);
            painelTechLeader.Controls.Add(bntCriarTarefas);
            painelTechLeader.Controls.Add(bntAlterarStatus);
            painelTechLeader.Controls.Add(bntAlterarResponsavel);
            painelTechLeader.Controls.Add(bntEstatistica);
            painelTechLeader.Controls.Add(bntAdicionarDesenvolvedor);
            return painelTechLeader;
        }
        #endregion

        #region OnClick Tech Leader

        private void OnClickAlterarResponsavel(object sender, EventArgs e)
        {
            JanelaAlterarResponsavel responsavel = new JanelaAlterarResponsavel();
            responsavel.ShowDialog();
        }
        private void OnClickEstatistica(object sender, EventArgs e)
        {
            JanelaEstatisticas estatistica = new JanelaEstatisticas();
            estatistica.ShowDialog();
        }

        #endregion

        #region Painel Administrador
        private Panel CriarPainelAdm(Panel painelAdm)
        {
            painelAdm.Controls.Clear();

            #region Botão AdicionarDesenvolvedor

            Button bntAdicionarDesenvolvedor = new Button();
            bntAdicionarDesenvolvedor.Size = new Size(160, 30);
            bntAdicionarDesenvolvedor.Location = new Point(20, 50);
            bntAdicionarDesenvolvedor.Anchor = AnchorStyles.Right;
            bntAdicionarDesenvolvedor.Text = "Adicionar Desenvolvedor";
            bntAdicionarDesenvolvedor.Click += OnClickAdicionarDesenvolvedor;

            #endregion

            #region Botão AdicionarTech

            Button bntAdicionarTech = new Button();
            bntAdicionarTech.Size = new Size(160, 30);
            bntAdicionarTech.Location = new Point(20, 90);
            bntAdicionarTech.Anchor = AnchorStyles.Right;
            bntAdicionarTech.Text = "Adicionar Tech Leader";
            bntAdicionarTech.Click += OnClickAdicionarTech;

            #endregion

            #region Botão RemoverUsuario

            Button bntRemoverUsuario = new Button();
            bntRemoverUsuario.Size = new Size(160, 30);
            bntRemoverUsuario.Location = new Point(20, 130);
            bntRemoverUsuario.Anchor = AnchorStyles.Right;
            bntRemoverUsuario.Text = "Remover Usuario";
            bntAdicionarTech.Click += OnClickRemoverUsuario;

            #endregion

            painelAdm.Controls.Add(bntAdicionarDesenvolvedor);
            painelAdm.Controls.Add(bntAdicionarTech);
            painelAdm.Controls.Add(bntRemoverUsuario);
            return painelAdm;
        }
        #endregion

        #region OnClick Adm
        private void OnClickAdicionarTech(object sender, EventArgs e)
        {
            //JanelaAdicionarTech tech = new JanelaAdicionarTech();
            //tech.ShowDialog();
        }
        private void OnClickRemoverUsuario(object sender, EventArgs e)
        {
            //JanelaRemoverUsuario user = new JanelaRemoverUsuario();
            //user.ShowDialog();
        }
        #endregion

        #region OnClick Em Comum
        private void OnClickVisualizarTarefas(object sender, EventArgs e)
        {
            using (MessageBoxCustomizada customMessageBox = new MessageBoxCustomizada("Escolha o tipo de tarefa que deseja visualizar:", "Ver Tarefas Ativas", "Ver Tarefas Desativadas"))
            {
                DialogResult result = customMessageBox.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    JanelaTarefasAtivas ativa = new JanelaTarefasAtivas();
                    ativa.ShowDialog();;
                }
                else if (result == DialogResult.No)
                {
                    JanelaTarefasDesativadas desativada = new JanelaTarefasDesativadas();
                    desativada.ShowDialog(); ;
                }
            }
        }

        private void OnClickCriarTarefas(object sender, EventArgs e)
        {
            JanelaCriarTarefas criar = new JanelaCriarTarefas(_usuarioLogado);
            criar.ShowDialog();
        }
        private void OnClickAdicionarDesenvolvedor(object sender, EventArgs e)
        {
            //JanelaAdicionarDev dev = new JanelaAdicionarDev();
            //dev.ShowDialog();
        }
        private void OnClickAlterarStatus(object sender, EventArgs e)
        {
            JanelaAlterarStatus status = new JanelaAlterarStatus();
            status.ShowDialog();
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
