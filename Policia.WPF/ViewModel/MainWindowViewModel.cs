using Cronometrage.WPF.Property;
using Policia.WPF.View;
using System.Collections.Generic;
using System.Windows.Input;
using Policia.NH.Model;
using Policia.WPF.Service;

namespace Policia.WPF.ViewModel
{
    public class MainWindowViewModel : NotifyPropertyBase
    {

        public ICommand CadastrarUsuarioCommand { get; set; }

        public ICommand GerenciarUsuarioCommand { get; set; }

        public ICommand CadastrarDesaparecidoCommand { get; set; }

        public ICommand GerenciarDesaparecidoCommand { get; set; }

        public ICommand LoginCommand { get; set; }

        private bool isLogado = false;
        public bool IsLogado
        {
            get
            {
                return isLogado;
            }
            set
            {
                if (value != isLogado)
                    isLogado = value;

                OnPropertyChanged("IsLogado");
            }
        }

        public string Login { get; set; }

        public string Senha { get; set; }

        public MainWindowViewModel()
        {
            #region Main

            LoginCommand = new Command((p) => 
            {
                var usuario = new Usuario()
                {
                    Login = this.Login,
                    Senha = this.Senha
                };

                IsLogado = AutenticacaoService.Autenticado(usuario);
            });

            #endregion

            #region Usuario            

            CadastrarUsuarioCommand = new Command((p) =>
            {
                var view = new CadastroUsuarioView();
                var viewModel = new CadastroUsuarioViewModel();

                view.DataContext = viewModel;
                viewModel.View = view;

                viewModel.Exibir();
            });

            GerenciarUsuarioCommand = new Command((p) =>
            {
                var view = new GerenciarUsuarioView();
                var viewModel = new GerenciarUsuarioViewModel();

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

                viewModel.Exibir();
            });

            GerenciarDesaparecidoCommand = new Command(p =>
            {
                var view = new GerenciarDesaparecidoView();
                var viewModel = new GerenciarDesaparecidoViewModel();

                view.DataContext = viewModel;
                viewModel.View = view;

                viewModel.Exibir();
            });

            #endregion
        }
    }
}