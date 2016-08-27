using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policia.Model.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Departamento { get; set; }
        public string Patente { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int Idade { get; set; }
    }
}
