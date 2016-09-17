using Cronometrage.WPF.Property;
using Policia.WPF.View;
using System.Collections.Generic;
using System.Windows.Input;
using Policia.NH.Model;

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