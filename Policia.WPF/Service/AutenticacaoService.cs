using Policia.NH.Config;
using Policia.NH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policia.WPF.Service
{
    public class AutenticacaoService
    {
        public static bool Autenticado(Usuario usuario)
        {
            return ConfigDB.Instance.UsuarioRepository
                .GetAll()
                .Where(u => u.Login == usuario.Login && u.Senha == usuario.Senha)
                .Any();
        }
    }
}
