   M S B A M L   `   `   `  ����C  ?ClientUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ClientUI.ViewClientUI.View  5      !    ClientUI.View.ServisiraView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:ClientUI.View     5      $��Stretch=�5      $��Stretch=�6,   .��5	      � $��5 5 5 5q�6     � RowDefinitions  5
   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   �� -   5         ��Name$ 
lblNetData��5      $��0��6$   $��Center=�61   ���	#FF3AFF00$	��400��6e   $��Center=�6q   $��Center=�6�   $��24(�6�   $
��Bold"�6�   $��Italic$�6�   ��6�   ��  �� Path$ LabelaServisira� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
    �� Orientation$ Vertical=�6   $��Stretch=�6-   $��1��6K   .+�5      �� $��14��6   � 5      y�6   �� $ Autorizacija�$ TwoWay=�$ PropertyChanged=� � ColumnDefinitions 5      �� 5      $��* �6'   63   �� 5      $
��Auto �6'   66   �� 5      $��* �6'   63   .+�5      �� $��5��6   $y�Hidden=�6&   �� 5      $ Vertical=�6   $��0��64   .+�5      �� $y�Hidden=�6    $��15��64   6B   �� 5      $ 
Horizontal=�6!   .+�5       �� -   5         ��Name$ textBlockVl��5    $   $��Serviser iz servisa:��69   ���	#FF3AFF00 �� Padding$ 8q�6l   $��Center=�6x   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�   	 �� TextAlignment$	 Center=�6�   �� 5!      -   5        
 ��Name$
 cmbBoxVlasnik��5!   #   $��34��6:   $	��160��6F   $��Center=�6R   $
��Bold"�6t   $��2q�6�   ���	#FF3AFF00$��Center=�6�   $��Center=�6�   ��6�   �� *	RadiSet+$ TwoWay=�$ PropertyChanged=� �� SelectedItem 6<  �� *
CmbBoxRadi+5"      �� 5#      $��2��6    $y�Hidden=�6*   �� 5$      $ 
Horizontal=�6!   .+�5%      �� -   5        $ textBlockRac��5%   $   $��Doneseni računar:��6:   ���	#FF3AFF00$ 8q�6j   $��Center=�6v   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�   $	 Center=�6�   �� 5&      -   5        $
 cmbBoxRacunar��5&   #   $��34��6:   $	��160��6F   $��Center=�6R   $
��Bold"�6t   $��2q�6�   ���	#FF3AFF00$��Center=�6�   $��Center=�6�   ��6�   �� *	DonosiSet+$ TwoWay=�$ PropertyChanged=� 6>  �� *CmbBoxDonosi+5'      �� 5(      $��2��6    $y�Hidden=�6*   �� 5)      $ 
Horizontal=�6!   .+�5*      �� -   5        $ textBlockRac1��5*   $   $��Dodaj garanciju[ID]:��6;   ���	#FF3AFF00$ 8q�6n   $��Center=�6z   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�   $	 Center=�6�   �� 5+      -   5        $
 cmbBoxGarList��5+   #   $��34��6:   $	��160��6F   $��Center=�6R   $
��Bold"�6t   $��2q�6�   ���	#FF3AFF00$��Center=�6�   $��Center=�6�   ��6�   �� *GarantniListovi+$ TwoWay=�$ PropertyChanged=� 6D  �� *CmbBoxGar_listovi+5,      �� 5-      $��2��6    $y�Hidden=�6*   �� 5.      $ 
Horizontal=�6!   .+�5/      �� -   5        $ textBlockRac2��5/   $   $��Cijena serv.[RSD]:��6;   ���	#FF3AFF00$ 8q�6l   $��Center=�6x   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�   $	 Center=�6�   �� 50      -	   5         ��Name$ txTBoxCijena��50   "   $��34��68   $��Center=�6D   $	��160��6f   $
��Bold"�6�   $��12(�6�   ��6r   �� $ TxTBoxCijena�$ TwoWay=�$ PropertyChanged=�6�   51      �� 52      $��2��6    $y�Hidden=�6*   �� 53      $ 
Horizontal=�6!   .+�54      �� -
   5        $ textBlockDat_rodj_s��54   $   $��Datum servisiranja:��6A   ���	#FF3AFF00$ 8q�6s   $��Center=�6   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�   $	 Center=�6�   (  "System.Windows.Controls.DatePicker  55      -   5          Name$ dpDat_s��55   %   $��34��66   $��Center=�6C   $
��Bold"�6�   $��12(�6�   $	��160��6�      SelectedDate 6f   �� $ DpDat_s�$ TwoWay=�$ PropertyChanged=�6�   56      57      �� 5:      $��5��6   $y�Hidden=�6&   �� 5;      $	��275��6   $��1��6)   $��Center=�69   .+�5<      �� $
��Auto=�6#   $
��Auto=�6H   $
��Auto��6k   $	��140��6x   $	��350��6�   .��5=      �� -   5        $ lblDodat��5=   $   $	��265��66   $
��Wrap=�6B   $��Center=�6W   $ 10q�6r   $	��150��6�   $
��Bold"�62  $��12(�6D  ��6�   �� $ 
Foreground�$ OneWay=�$ PropertyChanged=���6�   �� $	 LBL�$ OneWay=�$ PropertyChanged=�6D  5>      5?      �� 5@      $��5��6   $y�Hidden=�6&   �� 5A      $ Vertical=�6   $��Center=�64   $��2��6O   $��Right=�6_   .+�5B      �� $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�5C      �� -   5         ��Name$ btnAdd��5C   !   $��Dodaj��61   $	��100��6A   
���   �$��34��6`   $
��Bold"�6l   $��2q�6~   ���	#FF3AFF00��6�   �� *
AddCommand+5D      �� 5E      $��0��6    $y�Hidden=�6+   �� 5F      $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�5G      �� -   5        $ 	btnUpdate��5G   !   $��	Ažuriraj��64   $	��100��6G   
���   �$��34��6f   $
��Bold"�6r   $��2q�6�   ���	#FF3AFF00��6�   �� *UpdateCommand+5H      �� 5I      $��0��6    $y�Hidden=�6+   �� 5J      $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�5K      �� -   5        $ 	btnDelete��5K   !   $��Obriši��64   ���	#FF3AFF00$��2q�6]   
���   �$	��100��6�   $��34��6�   $
��Bold"�6�   ��6�   �� *DeleteCommand+5L      5M      �� 5N      $ Vertical=�6   .+�5O      �� $�� ��6    $��13��6(   5P      5Q      �� 5R      $��20��6   6&   5S      &   System.Windows.Controls.DataGrid  5T   
   -   5          Name$ dataGridSerRacunaraData��5T      
���   �$��2q�6�   ���	#FF3AFF00   AutoGenerateColumns .  $��Stretch=�6j  $��Stretch=�6�     
IsReadOnly . $��Center=�6�  $��Center=�6�  ��6G   �� $ AutorizacijaRaspored�$ TwoWay=�$ PropertyChanged=���6�   �� $ ServisiraSet�$ PropertyChanged=� 6?  �� *SelectedServisira+   Columns 5V      0  *System.Windows.Controls.DataGridTextColumn  5W      ,  &System.Windows.Controls.DataGridColumn   Header$ Ime vlasnika��6%      
FontWeight$
 Bold"�6;      
Foreground
 �   �   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6a   �� $ Donosi.Pposjeduje.Ime_vl�6�     5X      $ Prezime vlasnika��6%   $
 Bold"�6?   
 �   �$ * 6�    6d   �� *Donosi.Pposjeduje.Prezime_vl+6�     5Y      $ ID računara��6%   $
 Bold"�6:   
 �   �$ * 6�    6_   �� *$"Donosi.PosjedujeRacunarID_racunara+6�     5Z      $ Tip računara��6%   $
 Bold"�6;   
 �   �$ * 6�    6`   �� *" Donosi.Pposjeduje.Vrsta_racunara+6�     5[      $ Ime servisera��6%   $
 Bold"�6<   
 �   �$ * 6�    6a   �� *Radi.Serviser_racunara.Ime_s+6�     5\      $ Naziv servisa��6%   $
 Bold"�6<   
 �   �$ * 6�    6a   �� *#!Radi.Racunarski_servis.Naziv_serv+6�     5]      $ Datum servisiranja��6%   $
 Bold"�6A   
 �   �$ * 6�    6f   �� *
Dat_potp+6�     5^      $ Cijena��6%   $
 Bold"�65   
 �   �$ * 6z    6Z   �� *Cijena_serv+6z     5_      $ Garancija važi do��6%   $
 Bold"�6@   
 �   �$ * 6�    6e   �� *Garantni_list.Period_vazenja+ �� StringFormat$ {0:dd.MM.yyyy}��6�   5a      5b      5c      