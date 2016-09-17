using Policia.WPF.View;
using System.Windows.Input;
using Cronometrage.WPF.Property;
using Policia.NH.Model;

namespace Policia.WPF.ViewModel
{
    public class CadastroUsuarioViewModel
    {
        public CadastroUsuarioView View { get; set; }

        public ICommand GravarUsuarioCommand { get; set; }

        public ICommand CancelarUsuarioCommand { get; set; }

        public Usuario Usuario { get; set; }

        public CadastroUsuarioViewModel()
        {
            Usuario = new Usuario();

            this.GravarUsuarioCommand = new Command((p) => 
            {
                Gravar(Usuario);
            });

            this.CancelarUsuarioCommand = new Command((p) =>
            {
                Usuario = null;
                this.View.Close();
            });
        }

        private void Gravar(Usuario usuario) 
        {
            //DAO.USUARIO.gravar(Usuario);
        }

        public void Show()
        {
            this.View.ShowDialog();
        }        
    }
}
