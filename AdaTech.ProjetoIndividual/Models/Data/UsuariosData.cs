using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness.Enums;
using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoIndividual.Models.Data
{
    internal class UsuariosData
    {
        private static List<TechLeader> _techLeader = new List<TechLeader>();
        private static List<Administrador> _administrador = new List<Administrador>();
        private static List<Desenvolvedor> _desenvolvedor = new List<Desenvolvedor>();
        private static List<Usuario> _usuarios = new List<Usuario>();
        private static Usuario _usuarioLogin;

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
            _techLeader.Add(new TechLeader("123456", "Laura de Faria", "4455667788", "laura.faria@gmail.com"));
        }
        internal static void CarregarDesenvolvedor()
        {
            _desenvolvedor.Add(new Desenvolvedor("000000", "Carolina de Faria", "0123456789", "carolina.faria@gmail.com"));
        }

        internal static List<Usuario> CarregarUsuariosAtivos()
        {
            CarregarTechLeader();
            CarregarDesenvolvedor();

            _usuarios.AddRange(_techLeader);
            _usuarios.AddRange(_desenvolvedor);
            _usuarios.AddRange(_administrador);

            return _usuarios;
        }
        internal static List<Usuario> ListarUsuariosAtivos()
        {
            if(_usuarios.Count <= 0)
            {
                MessageBox.Show("Sem usuários ativos no sistema");
            }
            else
            {
                List<Usuario> lista = new List<Usuario>();

                foreach(Usuario u in _usuarios)
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
    }
}
