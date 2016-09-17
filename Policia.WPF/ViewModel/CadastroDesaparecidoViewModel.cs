using Cronometrage.WPF.Property;
using Policia.WPF.View;
using System.Windows.Input;
using Policia.NH.Model;

namespace Policia.WPF.ViewModel
{
    public class CadastroDesaparecidoViewModel : NotifyPropertyBase
    {
        public CadastroDesaparecidoView View { get; set; }
        public Desaparecido Desaparecido { get; set; }
        public Caracteristica Caracteristica { get; set; }
        public ICommand BotaoCadastrar { get; set; }

        public CadastroDesaparecidoViewModel() 
        {
            Desaparecido = new Desaparecido();
            this.Caracteristica = new Caracteristica();
            Desaparecido.Caracteristica = this.Caracteristica;

            BotaoCadastrar = new Command(p=>
            {
                Gravar(this.Desaparecido);
            });
        }

        private void Gravar(Desaparecido desaparecido)
        {
            this.View.Close();
            //CaracteristicaDAO.Gravar(this.Caracteristica)
            //DAO.gravar(this.Desaparecido);
        }

        public void Show() 
        {
            this.View.ShowDialog();
        }
    }
}
