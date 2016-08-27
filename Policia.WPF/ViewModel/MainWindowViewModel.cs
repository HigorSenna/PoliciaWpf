using Cronometrage.WPF.Property;
using Policia.Model.Model;
using Policia.WPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Policia.WPF.ViewModel
{
    public class MainWindowViewModel : NotifyPropertyBase
    {
        
        public ICommand CadastrarUsuarioCommand { get; set; }

        public ICommand GerenciarUsuarioCommand { get; set; }

        public ICommand CadastrarDesaparecidoCommand { get; set; }

        public ICommand GerenciarDesaparecidoCommand { get; set; }

        public ICommand LoginCommand { get; set; }

        public Usuario UsuarioLogado;
        
        public List<Desaparecido> Desaparecidos;
        public List<Usuario> Usuarios;

        public MainWindowViewModel()
        {
            #region Usuario
            Usuarios = new List<Usuario>();

            CadastrarUsuarioCommand = new Command((p) =>
            {
                var view = new CadastroUsuarioView();
                var viewModel = new CadastroUsuarioViewModel();

                view.DataContext = viewModel;
                viewModel.View = view;

                viewModel.Show();
            });

            GerenciarUsuarioCommand = new Command((p) =>
            {
                var view = new GerenciarUsuarioView();
                var viewModel = new GerenciarUsuarioViewModel(new System.Collections.ObjectModel.ObservableCollection<Usuario>(Usuarios));

                view.DataContext = viewModel;
                viewModel.View = view;

                viewModel.Exibir();
            });

            #endregion

            #region Desaparecido
                CadastrarDesaparecidoCommand = new Command(p =>
                {
                    var view = new CadastroDesaparecidoView();
                    var viewModel = new CadastroDesaparecidoViewModel();

                    view.DataContext = viewModel;
                    viewModel.View = view;

                    viewModel.Show();
                });
            
            #endregion
        }
    }
}