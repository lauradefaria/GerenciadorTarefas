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

        internal void SetUsuarioLogado(Usuario usuario)
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

        internal static List<Usuario> CarregarUsuariosAtivos()
        {
            CarregarTechLeader();

            _usuarios.AddRange(_techLeader);
            _usuarios.AddRange(_desenvolvedor);
            _usuarios.AddRange(_administrador);

            return _usuarios;
        }
        internal static List<Usuario> ListarUsuariosAtivos()
        {
            return _usuarios.Where(u => u.Ativo == true).ToList();
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
