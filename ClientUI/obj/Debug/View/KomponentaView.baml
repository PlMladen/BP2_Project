   M S B A M L   `   `   `  ����C  ?ClientUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ClientUI.ViewClientUI.View  5      "    ClientUI.View.KomponentaView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:ClientUI.View     5      $��Stretch=�5      $��Stretch=�6,   .��5	      � $��5 5 5 5q�6     � RowDefinitions  5
   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   �� -   5         ��Name$ 
lblNetData��5      $��0��6$   $��Center=�61   ���	#FF3AFF00$	��400��6e   $��Center=�6q   $��Center=�6�   $��24(�6�   $
��Bold"�6�   $��Italic$�6�   $��Komponente ��6�   �� 5   
    �� Orientation$ Vertical=�6   $��1��6,   $��Stretch=�69   .+�5      �� $��14��6   � 5       � ColumnDefinitions 5      �� 5      $��* �6'   63   �� 5      $
��Auto �6'   66   �� 5      $��* �6'   63   .+�5      �� $��5��6   $y�Hidden=�6&   �� 5      $ Vertical=�6   $��0��64   .+�5      �� $��10��6    $y�Hidden=�6,   6B   �� 5"      $��2��6    $y�Hidden=�6*   �� 5#      $ 
Horizontal=�6!   .+�5$      �� -   5         ��Name$ textBlockCPU��5$   $   $��Naziv komponente:��6:   ���	#FF3AFF00 �� Padding$ 8q�6j   $��Center=�6v   $
��Bold"�6�   $��12(�6�   $	��140��6�   $��Center=�6�   $��34��6�    �� TextAlignment$ Center=�6�   �� 5%      -   5         ��Name$ txtBoxBrzinaCPU��5%   "   $��34��6;   $��Center=�6G   $	��160��6i   $
��Bold"�6�   $��12(�6�   ��6u   ��  �� Path$ TxTBoxNazKomp�	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�6�   5&      �� 5'      $��2��6    $y�Hidden=�6*   �� 5(      $ 
Horizontal=�6!   .+�5)      �� -   5        $ textBlockRAM��5)   $   $��Cijena [RSD]:��6:   ���	#FF3AFF00$ 8q�6f   $��Center=�6r   $
��Bold"�6�   $��12(�6�   $	��140��6�   $��Center=�6�   $��34��6�   $ Center=�6�   �� 5*      -   5        $ 	txtBoxRAM��5*   "   $��34��65   $��Center=�6A   $
��Bold"�6�   $��12(�6�   $	��160��6�   ��6c   �� $ TxtCijenaKomp�$	 TwoWay=�$
 PropertyChanged=�6�   5+      �� 5,      $��2��6    $y�Hidden=�6*   �� 5-      $ 
Horizontal=�6!   .+�5.      �� -   5        $ textBlockVrsta��5.   $   $��ID računara:��6<   ���	#FF3AFF00$ 8q�6g   $��Center=�6s   $
��Bold"�6�   $��12(�6�   $	��140��6�   $��Center=�6�   $��34��6�   $ Center=�6�   �� 5/      -   5         ��Name$ cmbBoxVrsta_racunara��5/   #   $��34��6A   $	��160��6M   $��Center=�6Y   $
��Bold"�6{   $��2q�6�   ���	#FF3AFF00$��Center=�6�   $��Center=�6�   ��6�   �� *
RacunarIDs+$	 TwoWay=�$
 PropertyChanged=� �� SelectedItem 6F  �� *CmbBoxID_racunara+50      51      �� 54      $��5��6   $y�Hidden=�6&   �� 55      $	��255��6   $��1��6)   $��Center=�69   .+�56      �� $
��Auto=�6#   $
��Auto=�6H   $
��Auto��6k   $��Center=�6x   $	��140��6�   $	��350��6�   .��57      �� -   5        $ lblDodat��57   $   $
��Wrap=�66   $	��255��6K   $	��Top=�6W   $ 10q�6o   $	��150��6}   $
��Bold"�6/  $��12(�6A  ��6�   �� $ 
Foreground�$	 OneWay=�$
 PropertyChanged=���6�   �� $	 LBL�$	 OneWay=�$
 PropertyChanged=�6A  58      59      �� 5:      $��5��6   $y�Hidden=�6&   �� 5;      $ Vertical=�6   $��Center=�64   $��Right=�6O   $��2��6k   .+�5<      �� $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�5=      �� -	   5         ��Name$ btnAdd��5=   !   $��Dodaj��61   $	��100��6A   
���   �$��34��6`   $
��Bold"�6l   $��2q�6~   ���	#FF3AFF00��6�   �� *
AddCommand+5>      �� 5?      $��0��6    $y�Hidden=�6+   �� 5@      $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�5A      �� -
   5        $ 	btnUpdate��5A   !   $��	Ažuriraj��64   $	��100��6G   
���   �$��34��6f   $
��Bold"�6r   $��2q�6�   ���	#FF3AFF00��6�   �� *UpdateCommand+5B      �� 5C      $��0��6    $y�Hidden=�6+   �� 5D      $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�5E      �� -   5        $ 	btnDelete��5E   !   $��Obriši��64   ���	#FF3AFF00$��2q�6]   
���   �$	��100��6�   $��34��6�   $
��Bold"�6�   ��6�   �� *DeleteCommand+5F      5G      �� 5H      $ Vertical=�6   .+�5I      �� $�� ��6    $��13��6(   5J      5K      �� 5L      $��20��6   6&   5M      &   System.Windows.Controls.DataGrid  5N   
   -   5          Name$ dataGridSerRacunaraData��5N      
���   �$��2q�6G   ���	#FF3AFF00   AutoGenerateColumns .  $��Stretch=�6  $��Stretch=�6&  $��2��6B     
IsReadOnly . $��Center=�6a  $��Center=�6�  ��6�   �� $ 
Komponente�$
 PropertyChanged=� 6�   �� *SelectedKomponenta+   Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Header$ ID Komponente��6%      
FontWeight$
 Bold"�6<      
Foreground
 �   �   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6}   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6a   �� *	Id_komp+6}     5R      $ Naziv��6%   $
 Bold"�64   
 �   �$ * 6w    6Z   �� *
Naz_komp+6w     5S      $ CIjena[RSD]��6%   $
 Bold"�6:   
 �   �$ * 6    6_   �� *Cijena_komp+6     5T      $ Ugrađena u računar [ID]��6%   $
 Bold"�6F   
 �   �$ * 6�    6k   �� *RacunarID_racunara+6�   5V      5W      5X      