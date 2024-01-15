using AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoIndividual.Controllers
{
    internal class TelaPrincipalController
    {
        private readonly Usuario _usuarioLogado;

        internal TelaPrincipalController(Usuario usuario)
        {
            _usuarioLogado = usuario;
        }

        internal string FiltrarLogin()
        {
            if (_usuarioLogado is Desenvolvedor)
            {
                return "Desenvolvedor";
            }
            else if (_usuarioLogado is TechLeader)
            {
                return "Tech Leader";
            }
            else
            {
                return "Administrador";
            }
        }
    }
}
