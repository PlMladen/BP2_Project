   M S B A M L   `   `   `  ����C  ?ClientUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ClientUI.ViewClientUI.View  5      (    "ClientUI.View.ServiserRacunaraView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:ClientUI.View     5      $��Stretch=�5      $��Stretch=�6,   .��5	      � $��5 5 5 5q�6     � RowDefinitions  5
   
   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   ��  �� Orientation$ Vertical=�6   $��Stretch=�6-   .+�5      �� -   5         ��Name$ 
lblNetData��5      $��Center=�6(   ���	#FF3AFF00$	��400��6\   $��Center=�6h   $��Center=�6�   $��24(�6�   $
��Bold"�6�   $��Italic$�6�   $��Serviseri racunara ��6�   �� 5      $��14��6   � 5       � ColumnDefinitions 5      �� 5      $��* �6'   63   �� 5      $
��Auto �6'   66   �� 5      $��* �6'   63   .+�5      �� $��5��6   $y�Hidden=�6&   �� 5      $ Vertical=�6   $��0��64   $��Stretch=�6D   .+�5       �� $��2��6    $y�Hidden=�6*   �� 5!      $ 
Horizontal=�6!   .+�5"      �� -   5         ��Name$ textBlockIme_s��5"   $   $��Ime servisera:��6<   ���	#FF3AFF00 �� Padding$ 8q�6i   $��Center=�6u   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�    �� TextAlignment$ Center=�6�   �� 5#      -   5         ��Name$ txTBoxIme_s��5#   "   $��34��67   $��Center=�6C   $	��160��6e   $
��Bold"�6�   $��12(�6�   ��6q   ��  �� Path$ TxTBoxIme_s�	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�6�   5$      �� 5%      $��2��6    $y�Hidden=�6*   �� 5&      $ 
Horizontal=�6!   .+�5'      �� -   5        $ textBlockPrezime_s��5'   $   $��Prezime servisera:��6@   ���	#FF3AFF00$ 8q�6q   $��Center=�6}   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�   $ Center=�6�   �� 5(      -   5        $ txtBoxPrezime_s��5(   "   $��34��6;   $��Center=�6G   $
��Bold"�6�   $��12(�6�   $	��160��6�   ��6i   �� $ TxtBoxPrezime_s�$	 TwoWay=�$
 PropertyChanged=�6�   5)      �� 5*      $��2��6    $y�Hidden=�6*   �� 5+      $ 
Horizontal=�6!   .+�5,      �� -   5        $ textBlockDat_rodj_s��5,   $   $��Datum rodjenja:��6A   ���	#FF3AFF00$ 8q�6o   $��Center=�6{   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�   $ Center=�6�   (  "System.Windows.Controls.DatePicker  5-      -   5          Name$ dpDat_rodj_s��5-   %   $��34��6;   $��Center=�6H   $
��Bold"�6�   $��12(�6�   $	��160��6�      SelectedDate 6k   �� $ DpDat_rodj_s�$	 TwoWay=�$
 PropertyChanged=�6�   5.      5/      �� 52      $��5��6   $y�Hidden=�6&   �� 53      $
��Auto��6   $��1��6*   .+�54      �� $
��Auto=�6#   $
��Auto=�6H   $
��Auto��6k   $	��140��6x   $	��350��6�   .��55      �� -   5        $ lblDodat��55   $   $	��265��66   $
��Wrap=�6B   $	��Top=�6W   $ 10q�6o   $	��150��6}   $
��Bold"�6/  $��12(�6A  ��6�   �� $ 
Foreground�$	 OneWay=�$
 PropertyChanged=���6�   �� $	 LBL�$	 OneWay=�$
 PropertyChanged=�6A  56      57      �� 58      $��5��6   $y�Hidden=�6&   �� 59      $ Vertical=�6   $��Center=�64   $��2��6O   $��Right=�6_   .+�5>      �� $��34��6   $	��110��6)   $��2q�6�   ��65   �� $ 	OkvirBoja�$	 OneWay=�$
 PropertyChanged=�._�5?      �� -	   5         ��Name$ btnAdd��5?   !   $	��110��6�   
���   �$��34��6�   $
��Bold"�6�   $��2q�6�   ��61   �� $ DugmeContent�$	 OneWay=�$
 PropertyChanged=���6�   �� $ 	OkvirBoja�$	 OneWay=�$
 PropertyChanged=���63  �� *OdobriCommand+5@      �� 5A      $��0��6    $y�Hidden=�6+   �� 5B      $��34��6   $	��110��6)   ���	#FF3AFF00$��2q�6M   ._�5C      �� -
   5        $ 	btnUpdate��5C   !   $��	Ažuriraj��64   $	��110��6G   
���   �$��34��6f   $
��Bold"�6r   $��2q�6�   ���	#FF3AFF00��6�   �� *UpdateCommand+5D      �� 5E      $��0��6    $y�Hidden=�6+   �� 5F      $��34��6   $	��110��6)   ���	#FF3AFF00$��2q�6M   ._�5G      �� -   5        $ 	btnDelete��5G   !   $��Obriši��64   ���	#FF3AFF00$��2q�6]   
���   �$	��110��6�   $��34��6�   $
��Bold"�6�   ��6�   �� *DeleteCommand+5H      5I      �� 5J      $ Vertical=�6   .+�5K      �� $�� ��6    $��13��6(   5L      5M      �� 5N      $��20��6   6&   5O      &   System.Windows.Controls.DataGrid  5P   
   -   5          Name$ dataGridSerRacunaraData��5P      $��1��64   
���   �$��2q�6T   ���	#FF3AFF00   AutoGenerateColumns .  $��Stretch=�6  $��Stretch=�60     
IsReadOnly . $��Center=�6^  $��Center=�6�  ��6�   �� $ 	Serviseri�$
 PropertyChanged=� �� SelectedItem 6�   �� *SelectedServiser+   Columns 5R      0  *System.Windows.Controls.DataGridTextColumn  5S      ,  &System.Windows.Controls.DataGridColumn   Header$
 JMBG��6%      
FontWeight$
 Bold"�63      
Foreground
 �   �   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6s   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6X   �� *JMBG_s+6s     5T      $	 Ime��6%   $
 Bold"�62   
 �   �$ * 6r    6X   �� *Ime_s+6r     5U      $ Prezime��6%   $
 Bold"�66   
 �   �$ * 6y    6[   �� *	Prezime_s+6y     5V      $ Datum rođenja��6%   $
 Bold"�6<   
 �   �$ * 6�    6a   �� *Dat_rodjenja_s+ �� StringFormat$ {0:dd.MM.yyyy}��6�   5Y      5Z      5[      