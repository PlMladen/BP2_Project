   M S B A M L   `   `   `  ����C  ?ClientUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ClientUI.ViewClientUI.View  5          ClientUI.View.DonosiView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:ClientUI.View     5      $��Stretch=�5      $��Stretch=�6,   .��5	      � $��5 5 5 5q�6     � RowDefinitions  5
   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   �� -   5         ��Name$ 
lblNetData��5      $��0��6$   $��Center=�61   ���	#FF3AFF00$	��400��6e   $��Center=�6q   $��Center=�6�   $��24(�6�   $
��Bold"�6�   $��Italic$�6�   $"��Istorija posjeta servisu/ima��6�   �� 5   
   $��1��6    �� Orientation$ Vertical=�6"   $��Stretch=�69   y�6W   ��  �� Path$ Autorizacija� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.+�5      �� $��14��6   � 5      $��Bottom=�6   $��Stretch=�6.    � ColumnDefinitions 5      �� 5      $��* �6'   63   �� 5      $
��Auto �6'   66   �� 5      $��* �6'   63   .+�5      �� $��10��6   $y�Hidden=�6'   �� 5      $��0��6   $ Vertical=�6-   .+�5      �� $y�Hidden=�6    $��15��64   6B   �� 5      $ 
Horizontal=�6!   .+�5      �� -   5         ��Name$ textBlockVl��5   $   $��
Računari:��69   ���	#FF3AFF00 �� Padding$ 8q�6a   $��Center=�6m   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�   	 �� TextAlignment$	 Center=�6�   �� 5      -   5        
 ��Name$
 cmbBoxVlasnik��5   #   $��44��6:   $	��160��6F   $��Center=�6R   $
��Bold"�6t   $��2q�6�   ���	#FF3AFF00$��Center=�6�   $��Center=�6�   ��6�   �� *	Posjeduje+$ TwoWay=�$ PropertyChanged=� �� SelectedItem 6>  �� *CmbBoxPosjeduje+5      �� 5       $��2��6    $y�Hidden=�6*   �� 5!      $ 
Horizontal=�6!   .+�5"      �� -   5        $ textBlockRac��5"   $   $��Servisi računara:��6:   ���	#FF3AFF00$ 8q�6j   $��Center=�6v   $
��Bold"�6�   $��12(�6�   $	��120��6�   $��Center=�6�   $��34��6�   $	 Center=�6�   �� 5#      -   5        $
 cmbBoxRacunar��5#   #   $��44��6:   $	��160��6F   $��Center=�6R   $
��Bold"�6t   $��2q�6�   ���	#FF3AFF00$��Center=�6�   $��Center=�6�   ��6�   �� *	Servisi+$ TwoWay=�$ PropertyChanged=� 6<  �� *CmbBoxID_Servisa+5$      5%      �� 5(      $��5��6   $y�Hidden=�6&   �� 5)      $��Stretch=�6   $��1��6;   .+�5*      �� $
��Auto=�6#   $
��Auto=�6H   $
��Auto��6k   $	��140��6x   $	��350��6�   .��5+      �� -   5        $ lblDodat��5+   $   $	��Top=�66   $ 10q�6N   $
��Auto��6[   $��5 0 0 0q�6h   $
��Wrap=�6y   $	��150��6�   $	��340��6�   $
��Bold"�6Q  $��12(�6c  ��6�   �� $ 
Foreground�$ OneWay=�$ PropertyChanged=���6  �� $	 LBL�$ OneWay=�$ PropertyChanged=�6c  5,      5-      �� 5.      $��5��6   $y�Hidden=�6&   �� 5/      $ Vertical=�6   $��Center=�64   $��Right=�6O   $��2��6k   $��0 0 10 0q�6{   .+�50      �� $��44��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�51      �� -   5         ��Name$ btnAdd��51   !   $��Dodaj��61   $	��100��6A   
���   �$��44��6`   $
��Bold"�6l   $��2q�6~   ���	#FF3AFF00��6�   �� *
AddCommand+52      �� 53      $��0��6    $y�Hidden=�6+   �� 54      $��44��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�55      �� -   5        $ 	btnUpdate��55   !   $��	Ažuriraj��64   $	��100��6G   
���   �$��44��6f   $
��Bold"�6r   $��2q�6�   ���	#FF3AFF00��6�   �� *UpdateCommand+56      �� 57      $��0��6    $y�Hidden=�6+   �� 58      $��44��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�59      �� -	   5        $ 	btnDelete��59   !   $��Obriši��64   ���	#FF3AFF00$��2q�6]   
���   �$	��100��6�   $��44��6�   $
��Bold"�6�   ��6�   �� *DeleteCommand+5:      5;      5=      �� 5>      $��20��6   6&   5?      &   System.Windows.Controls.DataGrid  5B   
   -
   5          Name$ dataGridSerRacunaraData��5B      $��Bottom=�6�   $   HorizontalScrollBarVisibility$
 Auto=�6�   "   VerticalScrollBarVisibility$
 Auto=�6�   $��Stretch=�6�   
���   �$��2q�6&  ���	#FF3AFF00   AutoGenerateColumns .     
IsReadOnly . $��Center=�6�  $��Center=�6  ��64   �� $ AutorizacijaRaspored�$ TwoWay=�$ PropertyChanged=���6n  �� $ 	DonosiSet�$ PropertyChanged=� 6�  �� *SelectedDonosi+   Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$ JMBG vlasnika��6%      
FontWeight$
 Bold"�6<      
Foreground
 �   �   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6a   �� *" PosjedujeVlasnik_racunaraJMBG_vl+6�     5E      $	 Ime��6%   $
 Bold"�62   
 �   �$ * 6~    6X   �� *Pposjeduje.Ime_vl+6~     5F      $ Prezime��6%   $
 Bold"�66   
 �   �$ * 6�    6[   �� *Pposjeduje.Prezime_vl+6�     5G      $ ID računara��6%   $
 Bold"�6:   
 �   �$ * 6�    6_   �� *PosjedujeRacunarID_racunara+6�     5H      $ Tip računara��6%   $
 Bold"�6;   
 �   �$ * 6�    6`   �� *Pposjeduje.Vrsta_racunara+6�     5I      $ 
ID servisa��6%   $
 Bold"�69   
 �   �$ * 6�    6^   �� *Racunarski_servisID_servisa+6�     5J      $ Naziv servisa��6%   $
 Bold"�6<   
 �   �$ * 6�    6a   �� *Racunarski_servis.Naziv_serv+6�   5L      5M      5N      