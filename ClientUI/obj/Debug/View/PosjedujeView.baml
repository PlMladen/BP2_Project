   M S B A M L   `   `   `  ����C  ?ClientUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ClientUI.ViewClientUI.View  5      !    ClientUI.View.PosjedujeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:ClientUI.View     5      $��Stretch=�5      $��Stretch=�6,   .��5	      � $��5 5 5 5q�6     � RowDefinitions  5
   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   �� -   5         ��Name$ 
lblNetData��5      $��0��6$   $��Center=�61   ���	#FF3AFF00$	��400��6e   $��Center=�6q   $��Center=�6�   $��24(�6�   $
��Bold"�6�   $��Italic$�6�   ��6�   ��  �� Path$ LabelaPosjeduje� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
    �� Orientation$ Vertical=�6   $��1��6,   $��Stretch=�69   .+�5      �� $��14��6   � 5       � ColumnDefinitions 5      �� 5      $��* �6'   63   �� 5      $
��Auto �6'   66   �� 5      $��* �6'   63   .+�5      �� $��5��6   $y�Hidden=�6&   �� 5      $ Vertical=�6   .+�5      �� $y�Hidden=�6    $��15��64   6B   �� 5      $ 
Horizontal=�6!   .+�5      �� -   5         ��Name$ textBlockVl��5   $   $��Vlasnik:��69   ���	#FF3AFF00 �� Padding$ 8q�6`   $��Center=�6l   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�   	 �� TextAlignment$	 Center=�6�   �� 5       -   5        
 ��Name$
 cmbBoxVlasnik��5    #   $��44��6:   $	��160��6F   $��Center=�6R   $
��Bold"�6t   $��2q�6�   ���	#FF3AFF00$��Center=�6�   $��Center=�6�   ��6�   �� *
Vlasnici+$ TwoWay=�$ PropertyChanged=� �� SelectedItem 6=  �� *CmbBoxJMBG_Vl+5!      �� 5"      $��2��6    $y�Hidden=�6*   �� 5#      $ 
Horizontal=�6!   .+�5$      �� -   5        $ textBlockRac��5$   $   $��
Računari:��6:   ���	#FF3AFF00$ 8q�6b   $��Center=�6n   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�   $	 Center=�6�   �� 5%      -   5        $
 cmbBoxRacunar��5%   #   $��44��6:   $	��160��6F   $��Center=�6R   $
��Bold"�6t   $��2q�6�   ���	#FF3AFF00$��Center=�6�   $��Center=�6�   ��6�   �� *
Racunari+$ TwoWay=�$ PropertyChanged=� 6=  �� *CmbBoxID_racunara+5&      5'      �� 5*      $��5��6   $y�Hidden=�6&   �� 5+      $	��275��6   $��Center=�6)   $��Stretch=�6D   $��1��6b   .+�5,      �� $
��Auto=�6#   $
��Auto=�6H   $
��Auto��6k   $��Center=�6x   $	��140��6�   $	��350��6�   .��5-      �� -   5        $ lblDodat��5-   $   $
��Wrap=�66   $	��265��6K   $	��Top=�6W   $ 10q�6o   $	��150��6}   $
��Bold"�6/  $��12(�6A  ��6�   �� $ 
Foreground�$ OneWay=�$ PropertyChanged=���6�   �� $	 LBL�$ OneWay=�$ PropertyChanged=�6A  5.      5/      �� 50      $��5��6   $y�Hidden=�6&   �� 51      $ Vertical=�6   $��Center=�64   $��Right=�6O   $��2��6k   .+�52      �� $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�53      �� -   5         ��Name$ btnAdd��53   !   $��Dodaj��61   $	��100��6A   
���   �$��34��6`   $
��Bold"�6l   $��2q�6~   ���	#FF3AFF00��6�   �� *
AddCommand+54      �� 55      $��0��6    $y�Hidden=�6+   �� 56      $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�57      �� -   5        $ 	btnUpdate��57   !   $��	Ažuriraj��64   $	��100��6G   
���   �$��34��6f   $
��Bold"�6r   $��2q�6�   ���	#FF3AFF00��6�   �� *UpdateCommand+58      �� 59      $��0��6    $y�Hidden=�6+   �� 5:      $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�5;      �� -	   5        $ 	btnDelete��5;   !   $��Obriši��64   ���	#FF3AFF00$��2q�6]   
���   �$	��100��6�   $��34��6�   $
��Bold"�6�   ��6�   �� *DeleteCommand+5<      5=      �� 5>      $ Vertical=�6   .+�5?      �� $�� ��6    $��13��6(   5@      5A      �� 5B      $��20��6   6&   5C      &   System.Windows.Controls.DataGrid  5D   
   -
   5          Name$ dataGridSerRacunaraData��5D      
���   �$��2��6G   $��2q�6T   ���	#FF3AFF00   AutoGenerateColumns .  $��Stretch=�6  $��Stretch=�64     
IsReadOnly . $��Center=�6b  $��Center=�6�  ��6�   �� $ PosjedujeSet�$ PropertyChanged=� 6�   �� *SelectedPosjeduje+   Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Header$ JMBG vlasnika��6%      
FontWeight$
 Bold"�6<      
Foreground
 �   �   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6}   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6a   �� *	JMBG_vl+6}     5H      $	 Ime��6%   $
 Bold"�62   
 �   �$ * 6s    6X   �� *Ime_vl+6s     5I      $ Prezime��6%   $
 Bold"�66   
 �   �$ * 6z    6[   �� *
Prezime_vl+6z     5J      $ ID računara��6%   $
 Bold"�6:   
 �   �$ * 6    6_   �� *Id_racunara+6     5K      $ Proizvođač��6%   $
 Bold"�69   
 �   �$ * 6�    6^   �� *Proizvodjac_racunara+6�     5L      $ Vrsta računara��6%   $
 Bold"�6=   
 �   �$ * 6�    6b   �� *Vrsta_racunara+6�   5N      5O      5P      