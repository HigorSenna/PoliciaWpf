using Cronometrage.WPF.Property;
using Policia.NH.Config;
using Policia.NH.Model;
using Policia.WPF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Policia.WPF.ViewModel
{
    public class GerenciarDesaparecidoViewModel : NotifyPropertyBase
    {
        public GerenciarDesaparecidoView View { get; set; }

        public ICommand ExcluirDesaparecidoCommand { get; set; }

        public ICommand AlterarDesaparecidoCommand { get; set; }

        public ICommand VisualizarDesaparecidoCommand { get; set; }

        public ICommand BuscarCommand { get; set; }

        public Desaparecido DesaparecidoSelecionado { get; set; }

        private ObservableCollection<Desaparecido> desaparecidos;
        public ObservableCollection<Desaparecido> Desaparecidos
        {
            get
            {
                return this.desaparecidos;
            }
            set
            {
                if(desaparecidos != value)
                    this.desaparecidos = value;

                OnPropertyChanged("Usuarios");
            }
        }

        public GerenciarDesaparecidoViewModel()
        {
            UpdateDesaparecidos();

            ExcluirDesaparecidoCommand = new Command((p) =>
            {
                if (DesaparecidoSelecionado != null)
                {
                    ConfigDB.Instance.DesaparecidoRepository.Excluir(DesaparecidoSelecionado);
                    UpdateDesaparecidos();
                }   
                else
                    MessageBox.Show("Selecione um registro!");
            });

            AlterarDesaparecidoCommand = new Command((p) =>
            {
                if (DesaparecidoSelecionado != null)
                {
                    var view = new CadastroDesaparecidoView();
                    var viewModel = new CadastroDesaparecidoViewModel();

                    viewModel.View = view;
                    view.DataContext = viewModel;

                    viewModel.Alterar(DesaparecidoSelecionado);

                    UpdateDesaparecidos();
                }
                else
                    MessageBox.Show("Selecione um registro!");
            });

            VisualizarDesaparecidoCommand = new Command((p) =>
            {
                if (DesaparecidoSelecionado != null)
                {
                    var view = new VisualizarDesaparecidoView();
                    var viewModel = new VisualizarDesaparecidoViewModel();

                    viewModel.View = view;
                    view.DataContext = viewModel;

                    viewModel.Exibir(DesaparecidoSelecionado);
                }
                else
                    MessageBox.Show("Selecione um registro!");
            });
        }

        public void Exibir()
        {
            this.View.ShowDialog();
        }

        public void UpdateDesaparecidos()
        {
            Desaparecidos = new ObservableCollection<Desaparecido>(ConfigDB.Instance.DesaparecidoRepository.GetAll());
        }
    }
}
