using Cronometrage.WPF.Property;
using Policia.NH.Model;
using Policia.WPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Policia.WPF.ViewModel
{
    public class VisualizarDesaparecidoViewModel : NotifyPropertyBase
    {
        public VisualizarDesaparecidoView View { get; set; }

        public Desaparecido Desaparecido { get; set; }

        public BitmapSource Imagem
        {
            get
            {              
              return null;                
            }
        }

        public VisualizarDesaparecidoViewModel()
        {

        }

        public void Exibir(Desaparecido desaparecido)
        {
            Desaparecido = desaparecido;
            this.View.ShowDialog();
        }
    }
}
