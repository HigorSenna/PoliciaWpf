using Cronometrage.WPF.Property;
using Policia.WPF.View;
using System.Windows.Input;
using Policia.NH.Model;
using Policia.NH.Config;

namespace Policia.WPF.ViewModel
{
    public class CadastroDesaparecidoViewModel : NotifyPropertyBase
    {
        public CadastroDesaparecidoView View { get; set; }

        public Desaparecido Desaparecido { get; set; }

        public ICommand BotaoCadastrar { get; set; }

        public CadastroDesaparecidoViewModel() 
        {
            Desaparecido = new Desaparecido();
            Desaparecido.Caracteristica = new Caracteristica();

            BotaoCadastrar = new Command( p =>
            {
                Gravar(this.Desaparecido);
            });
        }

        private void Gravar(Desaparecido desaparecido)
        {
            ConfigDB.Instance.DesaparecidoRepository.Gravar(desaparecido);
            this.View.Close();
        }

        public void Exibir() 
        {
            this.View.ShowDialog();
        }
    }
}
