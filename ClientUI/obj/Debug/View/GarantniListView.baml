   M S B A M L   `   `   `  ����C  ?ClientUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ClientUI.ViewClientUI.View  5      $    ClientUI.View.GarantniListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:ClientUI.View     5      $��Stretch=�5      $��Stretch=�6,   .��5	      � $��5 5 5 5q�6     � RowDefinitions  5
   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   �� -   5         ��Name$ 
lblNetData��5      $��0��6$   $��Center=�61   ���	#FF3AFF00$	��400��6e   $��Center=�6q   $��Center=�6�   $��24(�6�   $
��Bold"�6�   $��Italic$�6�   $��Garantni listovi ��6�   �� 5   
    �� Orientation$ Vertical=�6   $��Stretch=�6-   $��1��6K   .+�5      �� $��14��6   � 5       � ColumnDefinitions 5      �� 5      $��* �6'   63   �� 5      $
��Auto �6'   66   �� 5      $��* �6'   63   .+�5      �� $��5��6   $y�Hidden=�6&   �� 5      $ Vertical=�6   $��0��64   .+�5       �� $��2��6    $y�Hidden=�6*   �� 5!      $ 
Horizontal=�6!   .+�5"      �� -   5         ��Name$ textBlockDat_rodj_s��5"   $   $��Datum isteka:��6A   ���	#FF3AFF00 �� Padding$ 8q�6m   $��Center=�6y   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�    �� TextAlignment$ Center=�6�   (  "System.Windows.Controls.DatePicker  5#      -   5          Name$ dpVaziDO��5#   %   $��34��67   $��Center=�6D   $
��Bold"�6�   $��12(�6�   $	��160��6�      SelectedDate 6g   �� 	 �� Path$	 DpVaziDo�
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5$      5%      �� 5'      $��5��6   $y�Hidden=�6&   �� 5(      $	��275��6   $��1��6)   $��Center=�69   .+�5)      �� $
��Auto=�6#   $
��Auto=�6H   $
��Auto��6k   $	��140��6x   $	��275��6�   .��5*      �� -   5        $ lblDodat��5*   $   $	��265��66   $
��Wrap=�6B   $	��Top=�6V   $ 10q�6n   $	��150��6|   $
��Bold"�6.  $��12(�6@  ��6�   �� $	 
Foreground�$
 OneWay=�$ PropertyChanged=���6�   �� $		 LBL�$
 OneWay=�$ PropertyChanged=�6@  5+      5,      �� 5-      $��5��6   $y�Hidden=�6&   �� 5.      $ Vertical=�6   $��Center=�64   $��2��6O   $��Right=�6_   .+�5/      �� $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�50      �� -   5         ��Name$ btnAdd��50   !   $��Dodaj��61   $	��100��6A   
���   �$��34��6`   $
��Bold"�6l   $��2q�6~   ���	#FF3AFF00��6�   �� *
AddCommand+51      �� 52      $��0��6    $y�Hidden=�6+   �� 53      $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�54      �� -   5        $ 	btnUpdate��54   !   $��	Ažuriraj��64   $	��100��6G   
���   �$��34��6f   $
��Bold"�6r   $��2q�6�   ���	#FF3AFF00��6�   �� *UpdateCommand+55      �� 56      $��0��6    $y�Hidden=�6+   �� 57      $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�58      �� -   5        $ 	btnDelete��58   !   $��Obriši��64   ���	#FF3AFF00$��2q�6]   
���   �$	��100��6�   $��34��6�   $
��Bold"�6�   ��6�   �� *DeleteCommand+59      5:      �� 5;      $ Vertical=�6   .+�5<      �� $�� ��6    $��13��6(   5=      5>      �� 5?      $��20��6   6&   5@      &   System.Windows.Controls.DataGrid  5A   
   -   5          Name$ dataGridNetData��5A      $��2��6,   
���   �$��2q�6L   ���	#FF3AFF00   AutoGenerateColumns .  $��Stretch=�6  $��Stretch=�6+     
IsReadOnly . $��Center=�6Y  $��Center=�6}  ��6�   �� $	 GarantniListovi�$ PropertyChanged=� �� SelectedItem 6�   �� *SelectedGList+   Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      
FontWeight$
 Bold"�61      
Foreground
 �   �   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6v   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6V   �� *Id_gar_list+6v     5E      $ Važi do��6%   $
 Bold"�66   
 �   �$ * 6�    6[   �� *Period_vazenja+ �� StringFormat$ {0:dd.MM.yyyy}��6�   5H      5I      5J      