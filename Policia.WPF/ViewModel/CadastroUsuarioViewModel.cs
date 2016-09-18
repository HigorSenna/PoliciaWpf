using Policia.WPF.View;
using System.Windows.Input;
using Cronometrage.WPF.Property;
using Policia.NH.Model;
using Policia.NH.Config;
using System.Windows;

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
                if (!Gravar(Usuario))
                    MessageBox.Show("Ocorreu um erro!");

                this.View.Close();
            });

            this.CancelarUsuarioCommand = new Command((p) =>
            {
                Usuario = null;
                this.View.Close();
            });
        }

        private bool Gravar(Usuario usuario) 
        {
            return ConfigDB.Instance.UsuarioRepository.Gravar(usuario);
        }

        public void Exibir()
        {
            this.View.ShowDialog();
        }

        public void Alterar(Usuario usuario)
        {
            this.Usuario = usuario;
            this.View.ShowDialog();
        }
    }
}
