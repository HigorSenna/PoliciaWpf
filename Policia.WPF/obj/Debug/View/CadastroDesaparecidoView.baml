   M S B A M L   `   `   `  ����  Policia.WPF/    )Policia.WPF.View.CadastroDesaparecidoView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  CadastroDesaparecidoView��5   	   $��381.276��6*   $��598.996��6;   .��5      � $��0,0,0,-1q�6   .+�5   
   �� ���	#FFF4F4F5$
��Left=�6%   $	��148��6@   $��	10,10,0,0q�6M   
���   �$	��Top=�6o   $	��570��6�   �� 5   
   ���	#FFF4F4F5$
��Left=�6%   $	��132��6@   $��
10,163,0,0q�6M   
���   �$	��Top=�6p   $	��570��6�   �� 5	   
   $��Nome:��6   $
��Left=�6    $��	10,41,0,0q�6;   $	��Top=�6N   $��46��6f   �� 5
   
   $��Ultimo Lugar Visto:��6   $
��Left=�6.   $��	10,69,0,0q�6I   $	��Top=�6\   �� 5   
   $��Telefone da família:��6   $
��Left=�6/   $��
297,72,0,0q�6J   $	��Top=�6^    J� RenderTransformOrigin$ 0.546,-0.778&�6v   �� 5   
   $��Imagem:��6   $
��Left=�6"   $��
10,100,0,0q�6=   $	��Top=�6Q   �� 5   
   $��Data Desaparecimento:��6   $
��Left=�60   $��
297,41,0,0q�6K   $	��Top=�6_   �� 5   
   $��CARACTERISTICAS:��6   $
��Left=�6+   $��
10,163,0,0q�6F   $	��Top=�6Z   $
��Bold"�6r   �� 5   
   $��DESAPARECIDO:��6   $
��Left=�6(   $��	10,10,0,0q�6C   $	��Top=�6V   $
��Bold"�6n   �� 5   
   $��Cor Do Cabelo:
��6   $
��Left=�63   $��
10,194,0,0q�6N   $	��Top=�6b   $��26��6z   �� 5   
   $��Cor Dos Olhos:��6   $
��Left=�6)   $��
11,256,0,0q�6D   $	��Top=�6X   �� 5   
   $��Cor Da Pele:��6   $
��Left=�6'   $��
10,225,0,0q�6B   $	��Top=�6V   �� 5   
   $
��Left=�6   $��
29,285,0,0q�6+   $	��Top=�6?   $��2��6W   �� 5   
   $��Peso:��6   $
��Left=�6    $��297,194,0,0q�6;   $	��Top=�6P   �� 5   
   $��Idade��6   $
��Left=�6    $��297,253,0,0q�6;   $	��Top=�6P   �� 5   
   $��Altura Aproximada:��6   $
��Left=�6-   $��297,222,0,0q�6H   $	��Top=�6]   �� 5   
   $
��Left=�6e   $��23��6�   $��
126,44,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��166��6�   ��6   �� *Desaparecido.Nome+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   (  "System.Windows.Controls.DatePicker  5   
   $
��Left=�6�   $��
435,43,0,0q�6�   $	��Top=�6�   $	��111��6�    � DataContext 6   �� *" Desaparecido.DataDesaparecimento+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   $
��Left=�6q   $��23��6�   $��
126,72,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��166��6�   ��6   �� *Desaparecido.UltimoLugarVisto+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   $
��Left=�6h   $��23��6�   $��
435,72,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��111��6�   ��6   �� *Desaparecido.Contato+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   -   5         ��Name$ button��5   m   $��
Escolher..��6}   $
��Left=�6�   $��
81,103,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *EscolherArquivoCommand+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   -   5         ��Name$ label��5      $
��Left=�6q   $��161,101,0,0q�6�   $	��Top=�6�   ��6   �� *NomeArquivo+$ TwoWay=�$ PropertyChanged=�6�   �� 5!   
   $
��Left=�6{   $��23��6�   $��105,194,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��166��6�   ��6   �� *)'Desaparecido.Caracteristica.CorDoCabelo+$ TwoWay=�$ PropertyChanged=�6�   �� 5"   
   $
��Left=�6y   $��23��6�   $��105,225,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��166��6�   ��6   �� *'%Desaparecido.Caracteristica.CorDaPele+$ TwoWay=�$ PropertyChanged=�6�   �� 5#   
   $
��Left=�6{   $��23��6�   $��105,256,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��166��6�   ��6   �� *)'Desaparecido.Caracteristica.CorDosOlhos+$ TwoWay=�$ PropertyChanged=�6�   �� 5$   
   $
��Left=�6t   $��23��6�   $��409,197,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��137��6�   ��6   �� *" Desaparecido.Caracteristica.Peso+$ TwoWay=�$ PropertyChanged=�6�   �� 5%   
   $
��Left=�6�   $��23��6�   $��409,225,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��137��6�   ��6   �� *.,Desaparecido.Caracteristica.AlturaAproximada+$ TwoWay=�$ PropertyChanged=�6�   �� 5&   
   -   5         ��Name$ txtIdade��5&   w   $
��Left=�6�   $��23��6�   $��409,256,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��137��6�   ��6   �� *#!Desaparecido.Caracteristica.Idade+$ TwoWay=�$ PropertyChanged=�6�   �� 5(   
   $��	Cadastrar��6f   $
��Left=�6z   $��282,313,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *CadastrarCommand+$ TwoWay=�$ PropertyChanged=�6�   �� 5)   
   $��Cancelar��6e   $
��Left=�6x   $��196,313,0,0q�6�   $	��Top=�6�   $��75��6�   $ -0.755,0.591&�6�   ��6   �� *CancelarCommand+$ TwoWay=�$ PropertyChanged=�6�   5,      5-      