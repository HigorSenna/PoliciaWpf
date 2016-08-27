using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policia.Model.Model
{
    public class Desaparecido
    {
        public Desaparecido()
        {
            this.Caracteristica = new Caracteristica();
        }

        public int Id { get; set; }
        public string Nome{get;set;}
        public string UltimoLugarVisto { get; set; }
        public string Contato { get; set; }
        public byte[] Imagem { get; set; }
        public DateTime DataDesaparecimento { get; set; }
        public Caracteristica Caracteristica { get; set; }
    }
}
