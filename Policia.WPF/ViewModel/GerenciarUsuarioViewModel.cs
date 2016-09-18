using Cronometrage.WPF.Property;
using Policia.WPF.View;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Policia.NH.Model;
using Policia.NH.Config;
using System.Windows;

namespace Policia.WPF.ViewModel
{
    public class GerenciarUsuarioViewModel : NotifyPropertyBase
    {
        public GerenciarUsuarioView View { get; set; }

        public ICommand ExcluirUsuarioCommand { get; set; }

        public ICommand AlterarUsuarioCommand { get; set; }

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

        public Usuario UsuarioSelecionado { get; set; }

        public string ParametroBusca { get; set; }

        public GerenciarUsuarioViewModel()
        {
            //Coloca todos os usuarios para exibir quando a tela é instanciada
            UpdateUsuarios();

            this.ExcluirUsuarioCommand = new Command((p) =>
            {
                if (UsuarioSelecionado != null)
                    ExcluirUsuario();
                else
                    MessageBox.Show("Selecione um usuário!");                
            });

            this.AlterarUsuarioCommand = new Command((p) => 
            {
                if (UsuarioSelecionado != null)
                {
                    var view = new CadastroUsuarioView();
                    var viewModel = new CadastroUsuarioViewModel();

                    viewModel.View = view;
                    view.DataContext = viewModel;

                    //Chama a tela de alterar e quando voltar atualiza a lista
                    viewModel.Alterar(UsuarioSelecionado);

                    UpdateUsuarios();
                }
                else
                {
                    MessageBox.Show("Selecione um usuário!");
                }
            });

            this.BuscarCommand = new Command((p) =>
            {
                //Se está vazio quero ver todos os usuarios novamente entao seto para a lista da tela todos os usuarios
                //E retorno para o método não continuar
                if (ParametroBusca == string.Empty)
                {
                    UpdateUsuarios();
                    return;
                }
                
                //Pega todos independente
                var usuarios = ConfigDB.Instance.UsuarioRepository.GetAll();

                //Busca todos que tenham alguma propriedade igual o parametro busca
                var busca = usuarios
                .Where(u => (u.Nome.Contains(ParametroBusca)) || (u.Login.Contains(ParametroBusca)) || (u.Patente.Contains(ParametroBusca)));

                //Seta a lista da tela para o resultado da busca
                this.Usuarios = new ObservableCollection<Usuario>(busca);
            });
        }

        public void Exibir()
        {
            this.View.ShowDialog();
        }

        private void ExcluirUsuario()
        {
            ConfigDB.Instance.UsuarioRepository.Excluir(UsuarioSelecionado);
            UpdateUsuarios();
        }

        private void UpdateUsuarios()
        {
            var usus = ConfigDB.Instance.UsuarioRepository.GetAll();
            this.Usuarios = new ObservableCollection<Usuario>(usus);
        }
    }
}
