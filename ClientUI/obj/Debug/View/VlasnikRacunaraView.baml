   M S B A M L   `   `   `  ����C  ?ClientUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ClientUI.ViewClientUI.View  5      '    !ClientUI.View.VlasnikRacunaraView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:ClientUI.View     5      $��Stretch=�5      $��Stretch=�6,   .��5
      � $��5 5 5 5q�6     � RowDefinitions  5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   ��  �� Orientation$ Vertical=�6   $��Stretch=�6-   $��0��6K   .+�5      �� -   5         ��Name$ 
lblNetData��5      $��Center=�6(   ���	#FF3AFF00$	��400��6\   $��Center=�6h   $��Center=�6�   $��24(�6�   $
��Bold"�6�   $��Italic$�6�   $��Vlasnici računara ��6�   �� 5      $��14��6   � 5      y�6   ��  �� Path$ Autorizacija� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� � ColumnDefinitions 5      �� 5      $��3* �6'   64   �� 5      $
��Auto �6'   66   �� 5      $��* �6'   63   .+�5      �� $��5��6   $y�Hidden=�6&   �� 5      $ Vertical=�6   $��0��64   .+�5       �� $��2��6    $y�Hidden=�6*   �� 5!      $ 
Horizontal=�6!   .+�5"      �� -   5         ��Name$ textBlockIme_v��5"   $   $��Ime vlasnika:��6<   ���	#FF3AFF00 �� Padding$ 8q�6h   $��Center=�6t   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�   	 �� TextAlignment$
	 Left=�6�   �� 5#      -   5        
 ��Name$
 txTBoxIme_vl��5#   "   $��34��68   $��Center=�6D   $	��160��6f   $
��Bold"�6�   $��12(�6�   ��6r   �� $ TxTBoxIme_vl�$ TwoWay=�$ PropertyChanged=�6�   5$      �� 5%      $��2��6    $y�Hidden=�6*   �� 5&      $ 
Horizontal=�6!   .+�5'      �� -   5        $ textBlockPrezime_vl��5'   $   $��Prezime vlasnika:��6A   ���	#FF3AFF00$ 8q�6q   $��Center=�6}   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�   $
	 Left=�6�   �� 5(      -   5        $
 txtBoxPrezime_vl��5(   "   $��34��6<   $��Center=�6H   $
��Bold"�6�   $��12(�6�   $	��160��6�   ��6j   �� $ TxtBoxPrezime_vl�$ TwoWay=�$ PropertyChanged=�6�   5)      �� 5*      $��2��6    $y�Hidden=�6*   �� 5+      $ 
Horizontal=�6!   .+�5,      �� -   5        $ textBlockDat_rodj_vl��5,   $   $��Datum rođenja:��6B   ���	#FF3AFF00$ 8q�6o   $��Center=�6{   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�   $
	 Left=�6�   (  "System.Windows.Controls.DatePicker  5-      -   5          Name$ dpDat_rodj_vl��5-   %   $��34��6<   $��Center=�6I   $
��Bold"�6�   $��12(�6�   $	��160��6�      SelectedDate 6l   �� $ DpDat_rodj_vl�$ TwoWay=�$ PropertyChanged=�6�   5.      �� 5/      $ Vertical=�6!   $
��Left=�68   .+�50      �� $ 
Horizontal=�6%   .+�51      �� -   5        $ textBlockAdresaServisa��51   (   $��Adresa vlasnika:��6H   ���	#FF3AFF00$ 8q�6w   $��Center=�6�   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�   $
	 Left=�6�   52      �� 53      $ 
Horizontal=�6%   .+�54      �� $��20��6(   $y�Hidden=�63   6I   �� 55      -	   5        $ textBlockAdresaVlUlica��55   (   $��Ulica:��6H   ���	#FF3AFF00$ 8q�6m   $
��Left=�6y   $
��Bold"�6�   $��12(�6�   $	��100��6�   $��Center=�6�   $��34��6�   $
	 Left=�6�   �� 56      -
   5        $
 txtBoxAdresaVl_Ulica��56   &   $��34��6D   $��Center=�6P    � ToolTip$ Naziv ulice��6r   $
��Bold"�6�   $��12(�6�   $	��160��6  ��6�   �� $ TxtBoxAdresaVl_Ulica�$ TwoWay=�$ PropertyChanged=�6  57      �� 58      $��2��6$   $y�Hidden=�6.   �� 59      $ 
Horizontal=�6%   .+�5:      �� $��20��6(   $y�Hidden=�63   6I   �� 5;      -   5        $ textBlockAdresaVlBroj��5;   (   $��Broj:��6G   ���	#FF3AFF00$ 8q�6k   $
��Left=�6w   $
��Bold"�6�   $��12(�6�   $	��100��6�   $��Center=�6�   $��34��6�   $
	 Left=�6�   �� 5<      -   5        $
 txtBoxAdresaVl_Broj��5<   &   $ Adresa - broj��6C   $
��Bold"�6�   $��12(�6�   $��Center=�6�   $��Center=�6�   $��34��6  $��83��6   ��6[   �� $ TxtBoxAdresaVl_Broj�$ TwoWay=�$ PropertyChanged=�6-  5=      �� 5>      $��2��6$   $y�Hidden=�6.   �� 5?      $ 
Horizontal=�6%   .+�5@      �� $��20��6(   $y�Hidden=�63   6I   �� 5A      -   5        $ textBlockAdresaVlGrad��5A   (   $��Grad:��6G   ���	#FF3AFF00$ 8q�6k   $
��Left=�6w   $
��Bold"�6�   $��12(�6�   $	��100��6�   $��Center=�6�   $��34��6�   $
	 Left=�6�   �� 5B      -   5        $
 txtBoxAdresaVl_Grad��5B   &   $��34��6C   $ Naziv grada��6O   $	��160��6e   $��Center=�6q   $
��Bold"�6�   $��12(�6  ��6�   �� $ TxtBoxAdresaVl_Grad�$ TwoWay=�$ PropertyChanged=�6  5C      �� 5D      $��2��6$   $y�Hidden=�6.   �� 5E      $ 
Horizontal=�6%   .+�5F      �� $��20��6(   $y�Hidden=�63   6I   �� 5G      -   5        $! textBlockAdresaServisaUlica��5G   (   $��Poštnski broj:��6M   ���	#FF3AFF00$ 8q�6z   $
��Left=�6�   $
��Bold"�6�   $��12(�6�   $	��100��6�   $��Center=�6�   $��34��6�   $
	 Left=�6�   �� 5H      -   5        $
 txtBoxAdresaVl_PTTBroj��5H   &   $��34��6F   $��83��6R   $ Postanski broj��6]   $��Center=�6v   $
��Bold"�6�   $��12(�6	  ��6�   �� $ TxtBoxAdresaVl_PTTBroj�$ TwoWay=�$ PropertyChanged=�6  5I      5J      5K      �� 5L      $��5��6   $y�Hidden=�6&   �� 5M      $	��275��6   $��1��6)   .+�5N      �� $
��Auto=�6#   $
��Auto=�6H   $
��Auto��6k   $	��140��6x   $	��350��6�   .��5O      �� -   5        $ lblDodat��5O   $   $	��265��66   $
��Wrap=�6B   $	��Top=�6W   $ 10q�6o   $	��150��6}   $
��Bold"�6/  $��12(�6A  ��6�   �� $ 
Foreground�$ OneWay=�$ PropertyChanged=���6�   �� $	 LBL�$ OneWay=�$ PropertyChanged=�6A  5P      5Q      �� 5R      $��5��6   $y�Hidden=�6&   �� 5S      $ Vertical=�6   $��Center=�64   $��2��6O   $��Right=�6_   .+�5X      �� $��34��6   $	��110��6)   $��2q�6�   ��65   �� $ 	OkvirBoja�$ OneWay=�$ PropertyChanged=�._�5Y      �� -   5         ��Name$ btnAdd��5Y   !   $	��110��6�   
���   �$��34��6�   $
��Bold"�6�   $��2q�6�   ��61   �� $ DugmeContent�$ OneWay=�$ PropertyChanged=���6�   �� $ 	OkvirBoja�$ OneWay=�$ PropertyChanged=���63  �� *OdobriCommand+5Z      �� 5[      $��0��6    $y�Hidden=�6+   �� 5\      $��34��6   $	��110��6)   ���	#FF3AFF00$��2q�6M   ._�5]      �� -   5        $ 	btnUpdate��5]   !   $��	Ažuriraj��64   $	��110��6G   
���   �$��34��6f   $
��Bold"�6r   $��2q�6�   ���	#FF3AFF00��6�   �� *UpdateCommand+5^      �� 5_      $��0��6    $y�Hidden=�6+   �� 5`      $��34��6   $	��110��6)   ���	#FF3AFF00$��2q�6M   ._�5a      �� -   5        $ 	btnDelete��5a   !   $��Obriši��64   ���	#FF3AFF00$��2q�6]   
���   �$	��110��6�   $��34��6�   $
��Bold"�6�   ��6�   �� *DeleteCommand+5b      5c      �� 5d      $ Vertical=�6   .+�5e      �� $�� ��6    $��13��6(   5f      5g      �� 5h      $��20��6   6&   5i      �� 5j   
   $ Vertical=�6   $��1��6,   .+�5k   
   �� $��1��6   $ 
Horizontal=�6"   $��Center=�6;   .+�5l   
   �� $��34��6   $	��350��6   ���	#FF3AFF00$��2q�6A   $��1��6U   ._�5m      �� -   5        $ 	btnExport��5m      $8��2Export-uj posjedujeSet za vlasnika u .csv dokument��6,   ���	#FF3AFF00$��2q�6�   
���   �$	��350��6�   $��34��6�   $
��Bold"�6�   ��6�   �� *ExportCommand+5n      �� 5o      $y�Hidden=�6   $��10��6,   69   �� 5p      $��34��6   $	��270��6!   ���	#FF3AFF00$��2q�6E   $��1��6Y   ._�5q      �� -   5        $ btnImportAll��5q      $.��(Import-uj posjedujeSet iz .csv dokumenta��6/   ���	#FF3AFF00$��2q�6z   
���   �$	��270��6�   $��34��6�   $
��Bold"�6�   ��6�   �� *ImportAllCommand+5r      �� 5s      $y�Hidden=�6   $��10��6,   69   �� 5t      $��34��6   $	��350��6!   ���	#FF3AFF00$��2q�6E   $��1��6Y   ._�5u      �� -   5        $ btnExportAll��5u      $<��6Export-uj posjedujeSet za sve vlasnike u .csv dokument��6/   ���	#FF3AFF00$��2q�6�   
���   �$	��350��6�   $��34��6�   $
��Bold"�6�   ��6�   �� *ExportAllCommand+5v      5x      �� 5y      $��20��6   6&   5z      &   System.Windows.Controls.DataGrid  5{   
   -   5          Name$ dataGridSerRacunaraData��5{       $��2��6   
���   �$��2q�6T   ���	#FF3AFF00   AutoGenerateColumns .  $��Stretch=�6  $��Stretch=�6.     
IsReadOnly . $��Center=�6\  $��Center=�6�  ��6�   �� $ Vlasnici�$ PropertyChanged=� �� SelectedItem 6�   �� *SelectedVlasnik+   Columns 5}      0  *System.Windows.Controls.DataGridTextColumn  5~      ,  &System.Windows.Controls.DataGridColumn   Header$
 JMBG��6%      
FontWeight$
 Bold"�63      
Foreground
 �   �   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6t   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6X   �� *	JMBG_vl+6t     5      $	 Ime��6%   $
 Bold"�62   
 �   �$ * 6s    6X   �� *Ime_vl+6s     5�      $ Prezime��6%   $
 Bold"�66   
 �   �$ * 6z    6[   �� *
Prezime_vl+6z     5�      $ Adresa��6%   $
 Bold"�65   
 �   �$ * 6x    6Z   �� *	Adresa_vl+6x     5�      $ Datum rođenja��6%   $
 Bold"�6<   
 �   �$ * 6�    6a   �� *Dat_rodjenja_vl+ �� StringFormat$ {0:dd.MM.yyyy}��6�   5�      5�      5�      