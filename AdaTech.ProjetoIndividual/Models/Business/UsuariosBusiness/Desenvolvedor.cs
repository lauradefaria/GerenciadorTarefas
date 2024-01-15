using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoIndividual.Models.Business.UsuariosBusiness
{
    internal class Desenvolvedor : Usuario
    {
        internal Desenvolvedor(string senha, string nome, string cpf, string email, bool ativo = true)
            : base(nome, email, senha, cpf)
        {
            TipoUsuario = Enums.TipoUsuario.Desenvolvedor;
        }
    }
}
