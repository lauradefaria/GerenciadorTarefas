using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness.Enums;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaTech.ProjetoIndividual.Models.Business.TarefasBusiness;

namespace AdaTech.ProjetoIndividual.Models.Business.DataBusiness
{
    internal class UsuariosData
    {
        private static List<TechLeader> _techLeader = new List<TechLeader>();
        private static List<Administrador> _administrador = new List<Administrador>();
        private static List<Desenvolvedor> _desenvolvedor = new List<Desenvolvedor>();
        private static List<Usuario> _usuarios = new List<Usuario>();

        public static List<Desenvolvedor> Desenvolvedores { get => _desenvolvedor; set => _desenvolvedor = value; }
        public static List<TechLeader> TechLeaders { get => _techLeader; set => _techLeader = value; }
        public static List<Administrador> Administrador { get => _administrador; set => _administrador = value; }

        private static readonly string _FILE_PATH_DESENVOLVEDOR = "C:\\Users\\lauraa\\Documents\\POO\\Gerenciador\\GerenciadorTarefas\\AdaTech.ProjetoIndividual\\Models\\Data\\Desenvolvedor.txt"; //Altere para o seu caminho do arquivo
        private static readonly string _FILE_PATH_TECH_LEADER = "C:\\Users\\lauraa\\Documents\\POO\\Gerenciador\\GerenciadorTarefas\\AdaTech.ProjetoIndividual\\Models\\Data\\TechLeader.txt"; //Altere para o seu caminho do arquivo
        private static readonly string _FILE_PATH_ADMINISTRADOR = "C:\\Users\\lauraa\\Documents\\POO\\Gerenciador\\GerenciadorTarefas\\AdaTech.ProjetoIndividual\\Models\\Data\\Administrador.txt"; //Altere para o seu caminho do arquivo
        private static Usuario _usuarioLogin;

        internal static Usuario UsuarioLogado()
        {
            return _usuarioLogin;
        }

        internal static void SetUsuarioLogado(Usuario usuario)
        {
            foreach (Usuario usuarioLogin in _usuarios)
            {
                if (usuarioLogin.Cpf == usuario.Cpf)
                {
                    _usuarioLogin = usuarioLogin;
                }
            }
        }

        internal static void CarregarTechLeader()
        {
           _techLeader = LerTlTxt();
        }
        internal static void CarregarDesenvolvedor()
        {
            _desenvolvedor = LerDevTxt();
        }

        internal static void CarregarAdm()
        {
           _administrador = LerAdmTxt();
        }

        internal static List<Usuario> CarregarUsuariosAtivos()
        {
            CarregarTechLeader();
            CarregarDesenvolvedor();
            CarregarAdm();

            _usuarios.AddRange(_techLeader);
            _usuarios.AddRange(_desenvolvedor);
            _usuarios.AddRange(_administrador);

            return _usuarios;
        }

        internal static bool AdicionarUsuario(string senha, string nome, string cpf, string email, TipoUsuario usuarioTipo)
        {
            try
            {

                if (usuarioTipo == TipoUsuario.Desenvolvedor)
                {
                    Desenvolvedor usuario = new Desenvolvedor(senha, nome, cpf, email, true);
                    _desenvolvedor.Add(usuario);
                    _usuarios.Add(usuario);
                    //SalvarDesenvolvedorTxt(_desenvolvedor);
                }
                else
                {
                    TechLeader usuario = new TechLeader(senha, nome, cpf, email, true);
                    _techLeader.Add(usuario);
                    _usuarios.Add(usuario);
                    //SalvarTechLeaderTxt(_techLeader);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static bool ExcluirUsuario(Usuario usuario)
        {
            Usuario user = _usuarios.FirstOrDefault(t => t.Cpf == usuario.Cpf);

            if (user != null && user.TipoUsuario == TipoUsuario.TechLeader)
            {
                _techLeader.Remove(SelecionarTechLeader(user.Cpf));
                _usuarios.Remove(SelecionarUsuario(user.Cpf));
                //SalvarTechLeaderTxt(_techLeader);
                return true;

            }
            else if (user != null && user.TipoUsuario == TipoUsuario.Desenvolvedor)
            {
                _desenvolvedor.Remove(SelecionarDesenvolvedor(user.Cpf));
                _usuarios.Remove(SelecionarUsuario(user.Cpf));
                //SalvarDesenvolvedorTxt(_desenvolvedor);
                return true;
            }
            return false;
        }

        internal static bool VerificarUsuarioExistenteCpf(string cpf)
        {
            Usuario usuario = SelecionarUsuario(cpf);

            if (usuario != null)
            {
                return true;
            }

            return false;
        }

        internal static bool VerificarUsuarioExistenteEmail(string email)
        {
            Usuario usuario = SelecionarUsuario(email);

            if (usuario != null)
            {
                return true;
            }

            return false;
        }

        internal static List<Usuario> ListarUsuariosAtivos()
        {
            if (_usuarios.Count <= 0)
            {
                MessageBox.Show("Sem usuários ativos no sistema");
            }
            else
            {
                List<Usuario> lista = new List<Usuario>();

                foreach (Usuario u in _usuarios)
                {
                    if (u.Ativo == true)
                    {
                        if (u.TipoUsuario == TipoUsuario.Desenvolvedor || u.TipoUsuario == TipoUsuario.TechLeader)
                        {
                            lista.Add(u);
                        }
                    }
                }

                return lista;
            }

            return _usuarios;
        }
        internal static List<Administrador> ListarAdministrador()
        {
            return _administrador.Where(u => u.TipoUsuario == TipoUsuario.Administrador).ToList();
        }
        internal static List<TechLeader> ListarTechLeader()
        {
            return _techLeader.Where(u => u.TipoUsuario == TipoUsuario.TechLeader).ToList();
        }
        internal static List<Desenvolvedor> ListarDesenvolvedor()
        {
            return _desenvolvedor.Where(u => u.TipoUsuario == TipoUsuario.Desenvolvedor).ToList();
        }

        internal static Usuario SelecionarUsuario(string usuario)
        {
            foreach (Usuario usuarioComparacao in _usuarios)
            {
                if (usuarioComparacao.Cpf == usuario)
                {
                    return usuarioComparacao;
                }
            }
            return null;
        }

        internal static TechLeader SelecionarTechLeader(string usuario)
        {
            foreach (TechLeader usuarioComparacao in _usuarios)
            {
                if (usuarioComparacao.Cpf == usuario)
                {
                    return usuarioComparacao;
                }
            }
            return null;
        }
        internal static Desenvolvedor SelecionarDesenvolvedor(string usuario)
        {
            foreach (Desenvolvedor usuarioComparacao in _usuarios)
            {
                if (usuarioComparacao.Cpf == usuario)
                {
                    return usuarioComparacao;
                }
            }
            return null;
        }


        internal static List<Usuario> LerUsuariosTxt(string _FILE_PATH, int tipoUsuario)
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                if (File.Exists(_FILE_PATH))
                {

                    using (StreamReader sr = new StreamReader(_FILE_PATH))
                    {
                        while (!sr.EndOfStream)
                        {
                            string linha = sr.ReadLine();
                            if (tipoUsuario == 0)
                            {
                                Desenvolvedor dev = ConverterLinhaParaDev(linha);
                                listaUsuarios.Add(dev);
                            }
                            else if (tipoUsuario == 1)
                            {
                                TechLeader tl = ConverterLinhaParaTl(linha);
                                listaUsuarios.Add(tl);
                            }
                            else if (tipoUsuario == 2)
                            {
                                Administrador adm = ConverterLinhaParaAdm(linha);
                                listaUsuarios.Add(adm);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo txt não existe.");
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("O arquivo não pôde ser aberto: " + e.Message);
            }
            return listaUsuarios;
        }

        internal static List<Desenvolvedor> LerDevTxt()
        {
            List<Desenvolvedor> listaDev = new List<Desenvolvedor>();

            try
            {
                if (File.Exists(_FILE_PATH_DESENVOLVEDOR))
                {
                    List<Usuario> lista = LerUsuariosTxt(_FILE_PATH_DESENVOLVEDOR, 0);
                    if (lista.OfType<Desenvolvedor>().ToList().Count > 0)
                    {
                        listaDev = lista.OfType<Desenvolvedor>().ToList();
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo txt de desenvolvedor não existe.");
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("O arquivo não pôde ser aberto: " + e.Message);
            }
            return listaDev;
        }

        internal static List<TechLeader> LerTlTxt()
        {
            List<TechLeader> listaTl = new List<TechLeader>();

            try
            {
                if (File.Exists(_FILE_PATH_TECH_LEADER))
                {
                    List<Usuario> lista = LerUsuariosTxt(_FILE_PATH_TECH_LEADER, 1);
                    if (lista.OfType<TechLeader>().ToList().Count > 0)
                    {
                        listaTl = lista.OfType<TechLeader>().ToList();
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo txt de tech leader não existe.");
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("O arquivo não pôde ser aberto: " + e.Message);
            }
            return listaTl;
        }

        internal static List<Administrador> LerAdmTxt()
        {
            List<Administrador> listaAdm = new List<Administrador>();

            try
            {
                if (File.Exists(_FILE_PATH_ADMINISTRADOR))
                {
                    List<Usuario> lista = LerUsuariosTxt(_FILE_PATH_ADMINISTRADOR, 2);
                    if (lista.OfType<Administrador>().ToList().Count > 0)
                    {
                        listaAdm = lista.OfType<Administrador>().ToList();
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo txt de administrador não existe.");
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("O arquivo não pôde ser aberto: " + e.Message);
            }
            return listaAdm;
        }

        private static Tuple<List<string>, bool> ConverterLinhaParaUsuario(string linha)
        {
            string[] objetoString = linha.Split(',');

            string senha = objetoString[0];
            MessageBox.Show($"{senha}");
            string nomeCompleto = objetoString[1];
            string cpf = objetoString[2];
            string email = objetoString[3];
            if (objetoString.Length > 4)
            {
                bool ativo = bool.Parse(objetoString[4]);

                return new Tuple<List<string>, bool>(new List<string> { senha, nomeCompleto, cpf, email }, ativo);
            }

            return new Tuple<List<string>, bool>(new List<string> { senha, nomeCompleto, cpf, email }, true);
        }

        internal static Desenvolvedor ConverterLinhaParaDev(string linha)
        {
            return new Desenvolvedor(ConverterLinhaParaUsuario(linha).Item1[0],
                                    ConverterLinhaParaUsuario(linha).Item1[1],
                                        ConverterLinhaParaUsuario(linha).Item1[2],
                                            ConverterLinhaParaUsuario(linha).Item1[3],
                                                    ConverterLinhaParaUsuario(linha).Item2);
        }

        internal static Administrador ConverterLinhaParaAdm(string linha)
        {
            return new Administrador(ConverterLinhaParaUsuario(linha).Item1[0],
                                        ConverterLinhaParaUsuario(linha).Item1[1],
                                            ConverterLinhaParaUsuario(linha).Item1[2],
                                                ConverterLinhaParaUsuario(linha).Item1[3],
                                                    ConverterLinhaParaUsuario(linha).Item2);
        }

        internal static TechLeader ConverterLinhaParaTl(string linha)
        {
            return new TechLeader(ConverterLinhaParaUsuario(linha).Item1[0],
                                            ConverterLinhaParaUsuario(linha).Item1[1],
                                                ConverterLinhaParaUsuario(linha).Item1[2],
                                                    ConverterLinhaParaUsuario(linha).Item1[3],
                                                            ConverterLinhaParaUsuario(linha).Item2);
        }

        internal static void SalvarUsuariosTxt<T>(List<T> usuarios, string _FILE_PATH)
        {
            try
            {
                List<string> linhas = new List<string>();
                if (typeof(T) == typeof(Desenvolvedor))
                {
                    foreach (Desenvolvedor dev in usuarios.OfType<Desenvolvedor>())
                    {
                        string linha = ConverterUsuarioParaLinha(dev);
                        linhas.Add(linha);
                    }
                }
                else if (typeof(T) == typeof(TechLeader))
                {
                    foreach (TechLeader tl in usuarios.OfType<TechLeader>())
                    {
                        string linha = ConverterUsuarioParaLinha(tl);
                        linhas.Add(linha);
                    }
                }
                else if (typeof(T) == typeof(Administrador))
                {
                    foreach (Administrador adm in usuarios.OfType<Administrador>())
                    {
                        string linha = ConverterUsuarioParaLinha(adm);
                        linhas.Add(linha);
                    }
                }

                File.AppendAllLines(_FILE_PATH, linhas);

                MessageBox.Show($"Alterações adicionadas com sucesso no arquivo.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar as alterações no arquivo: {ex.Message}");
            }
        }

        internal static void SalvarTechLeaderTxt(List<TechLeader> techLeaders)
        {
            try
            {
                SalvarUsuariosTxt(techLeaders, _FILE_PATH_TECH_LEADER);

                _techLeader = LerTlTxt();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar as alterações no arquivo: {ex.Message}");
            }
        }

        internal static void SalvarDesenvolvedorTxt(List<Desenvolvedor> desenvolvedores)
        {
            try
            {
                SalvarUsuariosTxt(desenvolvedores, _FILE_PATH_DESENVOLVEDOR);

                _desenvolvedor.AddRange(LerDevTxt());

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar as alterações no arquivo: {ex.Message}");
            }
        }

        internal static string ConverterUsuarioParaLinha(Usuario usuario)
        {
            if (usuario is TechLeader || usuario is Desenvolvedor)
            {
                return $"{usuario.Senha},{usuario.Nome},{usuario.Cpf},{usuario.Email},{usuario.Ativo}";
            }
            return $"{usuario.Senha},{usuario.Nome},{usuario.Cpf},{usuario.Email},{usuario.Ativo}";
        }
    }
}
