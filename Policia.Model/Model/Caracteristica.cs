using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policia.Model.Model
{
    public class Caracteristica
    {
        public int Id { get; set; }
        public string CorDoCabelo { get; set; }
        public string CorDosOlhos { get; set; }
        public string CorDaPele { get; set; }
        public double AlturaAproximada { get; set; }
        public double Peso { get; set; }
        public int Idade { get; set; }
    }
}
