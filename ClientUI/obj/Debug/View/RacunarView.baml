   M S B A M L   `   `   `  ����C  ?ClientUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ClientUI.ViewClientUI.View  5          ClientUI.View.RacunarView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:ClientUI.View     5      $��Stretch=�5      $��Stretch=�6,   .��5	      � $��5 5 5 5q�6     � RowDefinitions  5
   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   �� -   5         ��Name$ 
lblNetData��5      $��0��6$   $��Center=�61   ���	#FF3AFF00$	��400��6e   $��Center=�6q   $��Center=�6�   $��24(�6�   $
��Bold"�6�   $��Italic$�6�   $��
Računari ��6�   �� 5   
    �� Orientation$ Vertical=�6   $��Stretch=�6-   $��1��6K   y�6X   ��  �� Path$ Autorizacija� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.+�5      �� $��14��6   � 5       � ColumnDefinitions 5      �� 5      $��* �6'   63   �� 5      $
��Auto �6'   66   �� 5      $��* �6'   63   .+�5      �� $��5��6   $y�Hidden=�6&   �� 5      $ Vertical=�6   $��0��64   .+�5      �� $ 
Horizontal=�6!   .+�5      �� -   5         ��Name$ textBlockProizvodjac��5   $   $��Proizvođač:��6B   ���	#FF3AFF00 �� Padding$ 8q�6l   $��Center=�6x   $
��Bold"�6�   $��12(�6�   $	��140��6�   $��Center=�6�   $��34��6�   	 �� TextAlignment$	 Center=�6�   �� 5      -   5        
 ��Name$
 txTBoxProizvodjac��5   "   $��34��6=   $��Center=�6I   $	��160��6k   $
��Bold"�6�   $��12(�6�   ��6w   �� $ TxTBoxProizvodjac�$ TwoWay=�$ PropertyChanged=�6�   5      �� 5      $��2��6    $y�Hidden=�6*   �� 5       $ 
Horizontal=�6!   .+�5!      �� -   5        $ textBlockCPU��5!   $   $��Brzina procesora[GHz]:��6:   ���	#FF3AFF00$ 8q�6o   $��Center=�6{   $
��Bold"�6�   $��12(�6�   $	��140��6�   $��Center=�6�   $��34��6�   $	 Center=�6�   �� 5"      -   5        $
 txtBoxBrzinaCPU��5"   "   $��34��6;   $��Center=�6G   $	��160��6i   $
��Bold"�6�   $��12(�6�   ��6u   �� $ TxtBoxBrzinaCPU�$ TwoWay=�$ PropertyChanged=�6�   5#      �� 5$      $��2��6    $y�Hidden=�6*   �� 5%      $ 
Horizontal=�6!   .+�5&      �� -   5        $ textBlockRAM��5&   $   $��Kapacitet RAM[GB]:��6:   ���	#FF3AFF00$ 8q�6k   $��Center=�6w   $
��Bold"�6�   $��12(�6�   $	��140��6�   $��Center=�6�   $��34��6�   $	 Center=�6�   �� 5'      -   5        $
 	txtBoxRAM��5'   "   $��34��65   $��Center=�6A   $
��Bold"�6�   $��12(�6�   $	��160��6�   ��6c   �� $ 	TxtBoxRAM�$ TwoWay=�$ PropertyChanged=�6�   5(      �� 5)      $��2��6    $y�Hidden=�6*   �� 5*      $ 
Horizontal=�6!   .+�5+      �� -   5        $ textBlockMemorija��5+   $   $��Kapacitet diska[GB]:��6?   ���	#FF3AFF00$ 8q�6r   $��Center=�6~   $
��Bold"�6�   $��12(�6�   $	��140��6�   $��Center=�6�   $��34��6�   $	 Center=�6�   �� 5,      -	   5        $
 txtBoxMemorija��5,   "   $��34��6:   $��Center=�6F   $
��Bold"�6�   $��12(�6�   $	��160��6�   ��6h   �� $ TxtBoxMemorija�$ TwoWay=�$ PropertyChanged=�6�   5-      �� 5.      $��2��6    $y�Hidden=�6*   �� 5/      $ 
Horizontal=�6!   .+�50      �� -
   5        $ textBlockVrsta��50   $   $��Vrsta računara:��6<   ���	#FF3AFF00$ 8q�6j   $��Center=�6v   $
��Bold"�6�   $��12(�6�   $	��140��6�   $��Center=�6�   $��34��6�   $	 Center=�6�   �� 51      -   5         ��Name$ cmbBoxVrsta_racunara��51   #   $��34��6A   $	��160��6M   $��Center=�6Y   $
��Bold"�6{   $��2q�6�   ���	#FF3AFF00$��Center=�6�   $��Center=�6�   ��6�   �� *RacunarTypes+$ TwoWay=�$ PropertyChanged=� �� SelectedItem 6H  �� *CmbBoxVrsta_racunara+52      53      �� 56      $��5��6   $y�Hidden=�6&   �� 57      $	��355��6   $��1��6,   $��Stretch=�6<   .+�58      �� $
��Auto=�6#   $
��Auto=�6H   $
��Auto��6k   $	��140��6x   $	��350��6�   .��59      �� -   5        $ lblDodat��59   $   $	��285��66   $
��Wrap=�6B   $	��Top=�6W   $ 10q�6o   $	��150��6}   $
��Bold"�6/  $��12(�6A  ��6�   �� $ 
Foreground�$ OneWay=�$ PropertyChanged=���6�   �� $	 LBL�$ OneWay=�$ PropertyChanged=�6A  5:      5;      �� 5<      $��5��6   $y�Hidden=�6&   �� 5=      $ Vertical=�6   $��Center=�64   $��Right=�6O   $��2��6k   .+�5>      �� $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�5?      �� -   5         ��Name$ btnAdd��5?   !   $��Dodaj��61   $	��100��6A   
���   �$��34��6`   $
��Bold"�6l   $��2q�6~   ���	#FF3AFF00��6�   �� *
AddCommand+5@      �� 5A      $��0��6    $y�Hidden=�6+   �� 5B      $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�5C      �� -   5        $ 	btnUpdate��5C   !   $��	Ažuriraj��64   $	��100��6G   
���   �$��34��6f   $
��Bold"�6r   $��2q�6�   ���	#FF3AFF00��6�   �� *UpdateCommand+5D      �� 5E      $��0��6    $y�Hidden=�6+   �� 5F      $��34��6   $	��100��6)   ���	#FF3AFF00$��2q�6M   ._�5G      �� -   5        $ 	btnDelete��5G   !   $��Obriši��64   ���	#FF3AFF00$��2q�6]   
���   �$	��100��6�   $��34��6�   $
��Bold"�6�   ��6�   �� *DeleteCommand+5H      5I      �� 5J      $ Vertical=�6   .+�5K      �� $�� ��6    $��13��6(   5L      5M      �� 5N      $��20��6   6&   5O      &   System.Windows.Controls.DataGrid  5P   
   -   5          Name$ dataGridSerRacunaraData��5P      
���   �$��2q�6�   ���	#FF3AFF00   AutoGenerateColumns .  $��Stretch=�6d  $��Stretch=�6�     
IsReadOnly . $��Center=�6�  $��Center=�6�  ��64   �� $ AutorizacijaRaspored�$ TwoWay=�$ PropertyChanged=���6�   �� $ Racunari�$ PropertyChanged=� 6;  �� *SelectedRacunar+   Columns 5R      0  *System.Windows.Controls.DataGridTextColumn  5S      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      
FontWeight$
 Bold"�61      
Foreground
 �   �   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6v   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6V   �� *ID_racunara+6v     5T      $ Proizvođač��6%   $
 Bold"�69   
 �   �$ * 6    6_   �� *Proizvodjac+6     5U      $ Brzina CPU [GHz]��6%   $
 Bold"�6?   
 �   �$ * 6�    6d   �� *Brzina_procesora+6�     5V      $ RAM [GB]��6%   $
 Bold"�67   
 �   �$ * 6~    6\   �� *Kapacitet_RAM+6~     5W      $ 	Disk [GB]��6%   $
 Bold"�68   
 �   �$ * 6�    6]   �� *Kapacitet_memorije+6�     5X      $ Vrsta računara��6%   $
 Bold"�6=   
 �   �$ * 6�    6b   �� *Vrsta_racunara+6�   5Z      5[      5\      