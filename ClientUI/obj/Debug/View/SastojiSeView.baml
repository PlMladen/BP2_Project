   M S B A M L   `   `   `  ����C  ?ClientUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ClientUI.ViewClientUI.View  5      !    ClientUI.View.SastojiSeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:ClientUI.View     5      $��Stretch=�5      $��Stretch=�6,   .��5	      � $��5 5 5 5q�6     � RowDefinitions  5
   
   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   ��  �� Orientation$ Vertical=�6   $��Stretch=�6-   $��0��6K   .+�5      �� -   5         ��Name$ 
lblNetData��5      $��Center=�6(   ���	#FF3AFF00$	��400��6\   $��Center=�6h   $��Center=�6�   $��24(�6�   $
��Bold"�6�   $��Italic$�6�   $"��Dodaj komponenti komponentu ��6�   �� 5      $��14��6   � 5       � ColumnDefinitions 5      �� 5      $��* �6'   63   �� 5      $
��Auto �6'   66   �� 5      $��* �6'   63   .+�5      �� $��5��6   $y�Hidden=�6&   �� 5      $ Vertical=�6   $��0��64   .+�5      �� $y�Hidden=�6    $��15��64   6B   �� 5      $ 
Horizontal=�6!   .+�5      �� -   5         ��Name$ textBlockVl��5   $   $��Komponenta:��69   ���	#FF3AFF00 �� Padding$ 8q�6c   $��Center=�6o   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�    �� TextAlignment$
 Left=�6�   �� 5      -   5         ��Name$ cmbBoxVlasnik��5   #   $��44��6:   $	��160��6F   $��Center=�6R   $
��Bold"�6t   $��2q�6�   ���	#FF3AFF00$��Center=�6�   $��Center=�6�   ��6�   �� *KomponentaKontejner+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� SelectedItem
 6H  �� *CmbBoxID_KontKomponente+5      �� 5      $��2��6    $y�Hidden=�6*   �� 5       $ 
Horizontal=�6!   .+�5!      �� -   5        $ textBlockRac��5!   $   $��Komponenta(dio):��6:   ���	#FF3AFF00$ 8q�6i   $��Center=�6u   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�   $
 Left=�6�   �� 5"      -   5        $ cmbBoxRacunar��5"   #   $��44��6:   $	��160��6F   $��Center=�6R   $
��Bold"�6t   $��2q�6�   ���	#FF3AFF00$��Center=�6�   $��Center=�6�   ��6�   �� *KomponentaSastDio+$ TwoWay=�$	 PropertyChanged=�
 6F  �� *CmbBoxID_SastDioKomponenta+5#      5$      �� 5'      $��5��6   $y�Hidden=�6&   �� 5(      $	��275��6   $��Stretch=�6)   $��1��6G   .+�5)      �� $
��Auto=�6#   $
��Auto=�6H   $��Center=�6k   $
��Auto��6�   $	��140��6�   $	��350��6�   .��5*      �� -   5        $ lblDodat��5*   $   $	��265��66   $
��Wrap=�6B   $	��Top=�6W   $ 10q�6o   $	��150��6}   $
��Bold"�6/  $��12(�6A  ��6�   ��  �� Path$ 
Foreground�$ OneWay=�$	 PropertyChanged=���6�   �� $	 LBL�$ OneWay=�$	 PropertyChanged=�6A  5+      5,      �� 5-      $��5��6   $y�Hidden=�6&   �� 5.      $ Vertical=�6   $��Center=�64   $��Right=�6O   $��2��6k   .+�5/      �� $��44��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�50      �� -   5         ��Name$ btnAdd��50   !   $��Dodaj��61   $	��100��6A   
���   �$��44��6`   $
��Bold"�6l   $��2q�6~   ���	#FF3AFF00��6�   �� *
AddCommand+51      �� 52      $��0��6    $y�Hidden=�6+   �� 53      $��44��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�54      �� -   5        $ 	btnUpdate��54   !   $��	Ažuriraj��64   $	��100��6G   
���   �$��44��6f   $
��Bold"�6r   $��2q�6�   ���	#FF3AFF00��6�   �� *UpdateCommand+55      �� 56      $��0��6    $y�Hidden=�6+   �� 57      $��44��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�58      �� -	   5        $ 	btnDelete��58   !   $��Obriši��64   ���	#FF3AFF00$��2q�6]   
���   �$	��100��6�   $��44��6�   $
��Bold"�6�   ��6�   �� *DeleteCommand+59      5:      �� 5;      $ Vertical=�6   .+�5<      �� $�� ��6    $��13��6(   5=      5>      �� 5?      $��20��6   6&   5@      &   System.Windows.Controls.DataGrid  5A   
   -
   5          Name$ dataGridSerRacunaraData��5A      $��1��64   
���   �$��2q�6T   ���	#FF3AFF00   AutoGenerateColumns .  $��Stretch=�6  $��Stretch=�64     
IsReadOnly . $��Center=�6b  $��Center=�6�  ��6�   �� $ SastojiSeSet�$	 PropertyChanged=�
 6�   �� *SelectedSastojiSe+   Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$ ID komponente��6%      
FontWeight$
 Bold"�6<      
Foreground
 �   �   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6a   �� *KomponentaId_komp+6�     5E      $ Naziv komponente��6%   $
 Bold"�6?   
 �   �$ * 6�    6e   �� *Komponenta.Naz_komp+6�     5F      $ Ugrađena u racunar��6%   $
 Bold"�6A   
 �   �$ * 6�    6f   �� *Komponenta.RacunarID_racunara+6�     5G      $ ID sastavne komponente��6%   $
 Bold"�6E   
 �   �$ * 6�    6j   �� *KomponentaId_komp1+6�     5H      $ Naziv sast. komponente��6%   $
 Bold"�6E   
 �   �$ * 6�    6j   �� *Komponenta1.Naz_komp+6�     5I      $ Ugrađena u racunar��6%   $
 Bold"�6A   
 �   �$ * 6�    6f   �� * Komponenta1.RacunarID_racunara+6�   5K      5L      5M      