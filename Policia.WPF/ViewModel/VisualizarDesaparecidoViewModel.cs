using Cronometrage.WPF.Property;
using Policia.NH.Model;
using Policia.WPF.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Policia.WPF.ViewModel
{
    public class VisualizarDesaparecidoViewModel : NotifyPropertyBase
    {
        public VisualizarDesaparecidoView View { get; set; }

        public Desaparecido Desaparecido { get; set; }

        public ImageSource Imagem
        {
            get
            {
                using (var strema = new MemoryStream(this.Desaparecido.Imagem))
                {
                    var img = new Bitmap(strema);

                    var hBitmap = img.GetHbitmap();

                    var wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap(
                                hBitmap, IntPtr.Zero, Int32Rect.Empty,
                                BitmapSizeOptions.FromEmptyOptions()
                              );

                    return wpfBitmap;
                }   
            }
        }

        public string DataDesaparecimento
        {
            get
            {
                return Desaparecido.DataDesaparecimento.ToShortDateString();
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
