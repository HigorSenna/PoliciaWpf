using Cronometrage.WPF.Property;
using Policia.WPF.View;
using System.Windows.Input;
using Policia.NH.Model;
using Policia.NH.Config;
using System;
using System.IO;
using Policia.WPF.Utils;

namespace Policia.WPF.ViewModel
{
    public class CadastroDesaparecidoViewModel : NotifyPropertyBase
    {
        public CadastroDesaparecidoView View { get; set; }

        public Desaparecido Desaparecido { get; set; }

        private string nomeArquivo;
        public string NomeArquivo
        {
            get
            {
                return nomeArquivo;
            }

            set
            {
                if (nomeArquivo != value)
                    nomeArquivo = value;

                OnPropertyChanged("NomeArquivo");
            }
        }

        public ICommand CadastrarCommand { get; set; }

        public ICommand CancelarCommand { get; set; }

        public ICommand EscolherArquivoCommand { get; set; }

        public CadastroDesaparecidoViewModel()
        {
            Desaparecido = new Desaparecido();
            Desaparecido.Caracteristica = new Caracteristica() { Desaparecido = this.Desaparecido };

            CadastrarCommand = new Command( p =>
            {
                Gravar(this.Desaparecido);
                this.View.Close();
            });

            CancelarCommand = new Command((p) => 
            {
                Desaparecido = null;
                this.View.Close();                
            });

            EscolherArquivoCommand = new Command((p) => 
            {
                var arquivo = EscolherArquivo();

                if(arquivo != null)
                {
                    this.Desaparecido.Imagem = FileWriter.StreamToByteArray(arquivo);
                }
            });
        }

        private Stream EscolherArquivo()
        {
            //Cria uma tela de seleção de arquivo
            var fileDialog = new System.Windows.Forms.OpenFileDialog();

            fileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";

            //Mostra a tela e guarda a resposta no resultado
            var result = fileDialog.ShowDialog();
            switch (result)
            {
                //Se o resultado foi: escolheu um arquivo, retorna o arquivo
                case System.Windows.Forms.DialogResult.OK:
                    this.NomeArquivo = fileDialog.FileName;
                    return fileDialog.OpenFile();

                //Se o resultado foi: Cancelou ou qualquer outro(fechou), retorna nulo
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    this.NomeArquivo = string.Empty;
                    return null;
            }
        }

        private void Gravar(Desaparecido desaparecido)
        {
            ConfigDB.Instance.DesaparecidoRepository.Gravar(desaparecido);
            this.View.Close();
        }

        public void Exibir() 
        {
            this.View.ShowDialog();
        }

        public void Alterar(Desaparecido desaparecido)
        {
            this.Desaparecido = desaparecido;
            this.View.ShowDialog();
        }
    }
}
