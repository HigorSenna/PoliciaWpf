using Policia.WPF.ViewModel;
using System.Windows;

namespace Policia.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var viewmodel = new MainWindowViewModel();
            //viewmodel.view = this;
            this.DataContext = viewmodel;
        }
    }
}
