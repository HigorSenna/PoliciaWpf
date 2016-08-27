using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Policia.WPF.View;
using Policia.Model.Model;
using System.Windows.Input;
using Cronometrage.WPF.Property;

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
