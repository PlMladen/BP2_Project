   M S B A M L   `   `   `  ����C  ?ClientUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ClientUI.ViewClientUI.View  5          ClientUI.View.ServisView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:ClientUI.View     5      $��Stretch=�5      $��Stretch=�6,   .��5
      � $�� 5 5 5 5q�6     � RowDefinitions  5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   �� -   5         ��Name$ 
lblNetData��5      $��0��6$   $��Center=�61   ���	#FF3AFF00$	��400��6e   $��Center=�6q   $��Center=�6�   $��24(�6�   $
��Bold"�6�   $��Italic$�6�   $��Servisi ��6�   �� 5   
    �� Orientation$ Vertical=�6   $��Stretch=�6-   $��1��6K   y�6X   ��  �� Path$ Autorizacija� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.+�5      �� $��14��6   � 5       � ColumnDefinitions 5      �� 5      $��3* �6'   64   �� 5      $
��Auto �6'   66   �� 5      $��* �6'   63   .+�5      �� $��5��6   $y�Hidden=�6&   �� 5      $ Vertical=�6   $��0��64   .+�5      �� $ 
Horizontal=�6!   .+�5      �� -   5         ��Name$ textBlockNazivServisa��5   $   $��Naziv servisa:��6C   ���	#FF3AFF00 �� Padding$ 8q�6p   $��Center=�6|   $
��Bold"�6�   $��12(�6�   $	��100��6�   $��Center=�6�   $��34��6�   	 �� TextAlignment$
	 Left=�6�   �� 5      $y�Hidden=�6$   $��20��68   6E   �� 5       -   5        
 ��Name$
 txtBoxNazivServisa��5    "   $��34��6>   $��Center=�6J   $	��160��6l   $
��Bold"�6�   $��12(�6�   ��6x   �� $ TxTBoxNazivServ�$ TwoWay=�$ PropertyChanged=�6�   5!      �� 5"      $��2��6    $y�Hidden=�6*   �� 5#      $ 
Horizontal=�6!   .+�5$      �� -   5        $ textBlockType��5$   $   $��Tip servisa:��6;   ���	#FF3AFF00$ 8q�6f   $��Center=�6r   $
��Bold"�6�   $��12(�6�   $	��100��6�   $��Center=�6�   $��34��6�   $
	 Left=�6�   �� 5%      $y�Hidden=�6$   $��20��68   6E   �� 5&      -   5         ��Name$ cmbType��5&   #   $��34��64   $	��160��6@   $��Center=�6L   $
��Bold"�6n   $��2q�6�   ���	#FF3AFF00$��Center=�6�   $��Center=�6�   ��6�   �� *ServisTypes+$ TwoWay=�$ PropertyChanged=� �� SelectedItem 6:  �� *SelectedTypeServis+5'      �� 5(      $��2��6    $y�Hidden=�6*   �� 5)      $ Vertical=�6!   $
��Left=�68   .+�5*      �� $ 
Horizontal=�6%   .+�5+      �� -   5        $ textBlockAdresaServisa��5+   (   $��Adresa servisa:��6H   ���	#FF3AFF00$ 8q�6v   $��Center=�6�   $
��Bold"�6�   $��12(�6�   $	��100��6�   $��Center=�6�   $��34��6�   $	 Center=�6�   5,      �� 5-      $ 
Horizontal=�6%   .+�5.      �� $��20��6(   $y�Hidden=�63   6I   �� 5/      -   5        $! textBlockAdresaServisaUlica��5/   (   $��Ulica:��6M   ���	#FF3AFF00$ 8q�6r   $
��Left=�6~   $
��Bold"�6�   $��12(�6�   $	��100��6�   $��Center=�6�   $��34��6�   $
	 Left=�6�   �� 50      -   5        $
 txtBoxAdresaUlica��50   &    � ToolTip$ Adresa - ulica��6A   $��34��6Z   $��Center=�6f   $
��Bold"�6�   $��12(�6�   $	��160��6  ��6�   �� $ TxTBoxAdresaUlica�$ TwoWay=�$ PropertyChanged=�6  51      �� 52      $��2��6$   $y�Hidden=�6.   �� 53      $ 
Horizontal=�6%   .+�54      �� $��20��6(   $y�Hidden=�63   6I   �� 55      -	   5        $  textBlockAdresaServisaBroj��55   (   $��Broj:��6L   ���	#FF3AFF00$ 8q�6p   $
��Left=�6|   $
��Bold"�6�   $��12(�6�   $	��100��6�   $��Center=�6�   $��34��6�   $
	 Left=�6�   �� 56      -
   5        $
 txtBoxAdresaBroj��56   &   $ Adresa - broj��6@   $
��Bold"�6�   $��12(�6�   $��Center=�6�   $��Center=�6�   $��34��6  $��83��6  ��6X   �� $ TxTBoxAdresaBroj�$ TwoWay=�$ PropertyChanged=�6'  57      �� 58      $��2��6$   $y�Hidden=�6.   �� 59      $ 
Horizontal=�6%   .+�5:      �� $��20��6(   $y�Hidden=�63   6I   �� 5;      -   5        $  textBlockAdresaServisaGrad��5;   (   $��Grad:��6L   ���	#FF3AFF00$ 8q�6p   $
��Left=�6|   $
��Bold"�6�   $��12(�6�   $	��100��6�   $��Center=�6�   $��34��6�   $
	 Left=�6�   �� 5<      -   5        $
 txtBoxAdresaGrad��5<   &   $��34��6@   $	��160��6L   $ Adresa - grad��6X   $��Center=�6p   $
��Bold"�6�   $��12(�6�   ��6�   �� $ TxTBoxAdresaGrad�$ TwoWay=�$ PropertyChanged=�6  5=      �� 5>      $��2��6$   $y�Hidden=�6.   �� 5?      $ 
Horizontal=�6%   .+�5@      �� $��20��6(   $y�Hidden=�63   6I   �� 5A      -   5        $! textBlockAdresaServisaPBroj��5A   (   $��Poštanski broj:��6M   ���	#FF3AFF00$ 8q�6{   $
��Left=�6�   $
��Bold"�6�   $��12(�6�   $	��100��6�   $��Center=�6�   $��34��6�   $
	 Left=�6�   �� 5B      -   5        $
 txtBoxAdresaPPT��5B   &   $��34��6?   $��83��6K   $ Adresa - postanski broj��6V   $��Center=�6x   $
��Bold"�6�   $��12(�6  ��6�   �� $ TxTBoxAdresaPPTBroj�$ TwoWay=�$ PropertyChanged=�6  5C      5D      �� 5E      $��2��6    $y�Hidden=�6*   �� 5F      $ 
Horizontal=�6!   .+�5G      �� -   5        $ textBlockBrojServisa��5G   $   $��Br. tel. servisa:��6B   ���	#FF3AFF00$ 8q�6r   $��Center=�6~   $
��Bold"�6�   $��12(�6�   $	��100��6�   $��Center=�6�   $��34��6�   $
	 Left=�6�   �� 5H      $y�Hidden=�6$   $��20��68   6E   �� 5I      -   5        $
 txtBoxPozivniBroj��5I   "   $��34��6=   $��Center=�6I   $ Pozivni broj (00381)��6k   $
��Bold"�6�   $��12(�6�   $��40��6  ��6�   �� $ TxTBoxBrTelPozBroj�$ TwoWay=�$ PropertyChanged=�6  �� 5J      $��2��6$   $y�Hidden=�6.   �� 5K      -   5        $
 txtBoxBrojOkruga��5K   "   $ Broj okruga (65)��6<   $
��Bold"�6�   $��12(�6�   $��Center=�6�   $��Center=�6�   $��34��6  $��40��6  ��6W   �� $ TxTBoxBrTelBrojOkruga�$ TwoWay=�$ PropertyChanged=�6+  �� 5L      $��2��6$   $y�Hidden=�6.   �� 5M      -   5        $
 
txtBoxBroj��5M   "   $��34��66   $��75��6B   $ Broj korisnika (1234567)��6M   $��Center=�6p   $
��Bold"�6�   $��12(�6�   ��6�   �� $ TxTBoxBrTelBroj�$ TwoWay=�$ PropertyChanged=�6  5N      5O      �� 5R      $��5��6   $y�Hidden=�6&   �� 5S      $
��Auto��6   $��1��6*   .+�5T      �� $
��Auto=�6#   $
��Auto=�6H   $
��Auto��6k   $	��140��6x   $	��350��6�   .��5U      �� -   5        $ lblDodat��5U   $   $
��Wrap=�66   $	��285��6J   $	��Top=�6V   $ 10q�6n   $	��150��6|   $
��Bold"�6.  $��12(�6@  ��6�   �� $ 
Foreground�$ OneWay=�$ PropertyChanged=���6�   �� $	 LBL�$ OneWay=�$ PropertyChanged=�6@  5V      5W      �� 5X      $��5��6   $y�Hidden=�6&   �� 5Y      $ Vertical=�6   $��Center=�64   $��Right=�6O   $��2��6k   .+�5Z      �� $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�5[      �� -   5         ��Name$ btnAdd��5[   !   $��Dodaj��61   $	��100��6A   
���   �$��34��6`   $
��Bold"�6l   $��2q�6~   ���	#FF3AFF00��6�   �� *
AddCommand+5\      �� 5]      $��0��6    $y�Hidden=�6+   �� 5^      $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�5_      �� -   5        $ 	btnUpdate��5_   !   $��	Ažuriraj��64   $	��100��6G   
���   �$��34��6f   $
��Bold"�6r   $��2q�6�   ���	#FF3AFF00��6�   �� *UpdateCommand+5`      �� 5a      $��0��6    $y�Hidden=�6+   �� 5b      $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�5c      �� -   5        $ 	btnDelete��5c   !   $��Obriši��64   ���	#FF3AFF00$��2q�6]   
���   �$	��100��6�   $��34��6�   $
��Bold"�6�   ��6�   �� *DeleteCommand+5d      5e      �� 5f      $ Vertical=�6   .+�5g      �� $�� ��6    $��13��6(   5h      5i      �� 5j      $��20��6   6&   5k      &   System.Windows.Controls.DataGrid  5l   
   -   5          Name$ dataGridNetData��5l      
���   �$��2q�6�   ���	#FF3AFF00   AutoGenerateColumns .  $��Stretch=�6Z  $��Stretch=�6x     
IsReadOnly . $��Center=�6�  $��Center=�6�  ��6,   �� $ AutorizacijaRaspored�$ TwoWay=�$ PropertyChanged=���6�   �� $ Servisi�$ PropertyChanged=� 62  �� *SelectedServis+   Columns 5n      0  *System.Windows.Controls.DataGridTextColumn  5o      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      
FontWeight$
 Bold"�61      
Foreground
 �   �   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6u   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6V   �� *
ID_servisa+6u     5p      $ Naziv��6%   $
 Bold"�64   
 �   �$ * 6y    6Z   �� *
Naziv_serv+6y     5q      $	 Tip��6%   $
 Bold"�62   
 �   �$ * 6t    6W   �� *
Tip_serv+6t     5r      $ Adresa��6%   $
 Bold"�65   
 �   �$ * 6z    6Z   �� *Adresa_serv+6z     5s      $ Kontakt��6%   $
 Bold"�66   
 �   �$ * 6{    6[   �� *Br_tel_serv+6{   5u      5v      5w      