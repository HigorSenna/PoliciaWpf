using Cronometrage.WPF.Property;
using Policia.Model.Model;
using Policia.WPF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Policia.WPF.ViewModel
{
    public class GerenciarUsuarioViewModel : NotifyPropertyBase
    {
        public GerenciarUsuarioView View { get; set; }

        public ICommand ExcluirUsuarioCommand { get; set; }

        public ICommand BuscarCommand { get; set; }

        private ObservableCollection<Usuario> usuarios;
        public ObservableCollection<Usuario> Usuarios
        {
            get
            {
                return this.usuarios;
            }
            set
            {
                this.usuarios = value;
                OnPropertyChanged("Usuarios");
            }
        }

        private ObservableCollection<Usuario> todosUsuarios;

        public Usuario UsuarioSelecionado { get; set; }

        public string ParametroBusca { get; set; }

        public GerenciarUsuarioViewModel(ObservableCollection<Usuario> usuarios)
        {
            this.Usuarios = usuarios;
            this.todosUsuarios = this.Usuarios;

            this.ExcluirUsuarioCommand = new Command((p) =>
            {
                if (UsuarioSelecionado != null)
                    this.Usuarios.Remove(UsuarioSelecionado);
            });

            this.BuscarCommand = new Command((p) =>
            {
                //Se está vazio quero ver todos os usuarios novamente entao seto para a lista da tela todos os usuarios
                //E retorno para o método não continuar
                if (ParametroBusca == string.Empty)
                {
                    this.Usuarios = this.todosUsuarios;
                    return;
                }

                //Busta todos que tenham alguma propriedade igual o parametro busca
                var busca = this.todosUsuarios
                .Where(u => (u.Nome == ParametroBusca) || (u.Login == ParametroBusca) || (u.Patente == ParametroBusca));

                //Seta a lista da tela para o resultado da busca
                this.Usuarios = new ObservableCollection<Usuario>(busca);
            });
        }

        public void Exibir()
        {
            //this.Usuarios = PEGARDOBANCO

            this.View.ShowDialog();
        }
    }
}
