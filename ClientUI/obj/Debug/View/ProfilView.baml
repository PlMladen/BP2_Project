   M S B A M L   `   `   `  ����C  ?ClientUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ClientUI.ViewClientUI.View  5   	   -clr-namespace:ClientUI.ViewClientUI.View  5	   	   7 clr-namespace:ClientUI.ViewModelClientUI.ViewModel  5
   	       ClientUI.View.ProfilView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ClientUI.View     5   	   -viewsclr-namespace:ClientUI.View     5	   	   6	viewmodel clr-namespace:ClientUI.ViewModel     5
   	     � 
ResizeMode$  CanResizeWithGrip=�5       � AllowsTransparency .   � WindowStartupLocation$ CenterScreen=�5   	   $	��650��5   	   $	��770��6    � Title$ 
ProfilView��5   	   $	��650��6   $	��770��6,   
���   � � DataContext 5      (   "ClientUI.ViewModel.ProfilViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��3* �6   6,   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��2* �6   6*   �� 5      $��* �6   6)   �� 5      $	��12* �6   6+   �� 5      $��* �6   6)   .+�5   
   �� $��0��6   $��1��6   ���	#FF3AFF00$
��Bold"�6D   $��Center=�6V   $��24(�6s   $��Vaš profil��6�   6�   �� 5   
   $��3q�6   ���	#FF3AFF00 �� CornerRadius$ 10��6=   $��2��6O   $��1��6\   ._�5       ��  �� Orientation$ Vertical=�6   $��Center=�60   $��Center=�6K   $��0 6 6 0q�6h   .+�5!      �� $ 
Horizontal=�6   .+�5"      �� $��Center=�6   $��Center=�6@   ���	#FF3AFF00$
��Bold"�6r   $
��Left=�6�   $��14(�6�   $
��Ime:��6�   6�   �� 5#      $��77��6    $y�Hidden=�6+   6A   �� 5$      -   5        	 ��Name$	 ImeTb��5$      $��Center=�6-   {�.  $��Center=�6Z   $��20��6w   
����������	#FF3AFF00$��1q�6�   $	��290��6�   ��6�   �� 
 �� Path$	
 Ime� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6   5%      �� 5&      $ 
Horizontal=�6   .+�5'      �� $y�Hidden=�6    $	��116��64   6B   �� 5(      -   5        $	 
ErrorLabel��5(      $��Center=�62   $
��Left=�6M   
������ 
���  �� �� 
IsReadOnly . $��0q�6�   $��20��6�   $	��290��6�   ��6�   �� $
 	ImeGreska�$ TwoWay=�$ PropertyChanged=�6%  5)      �� 5*      $ 
Horizontal=�6   .+�5+      �� $��Center=�6   $��Center=�6@   ���	#FF3AFF00$
��Bold"�6r   $
��Left=�6�   $��14(�6�   $��Prezime:��6�   6�   �� 5,      $��49��6    $y�Hidden=�6+   6A   �� 5-      -   5        $	 	PrezimeTb��5-      $��Center=�61   {�.  $��Center=�6^   $��20��6{   
����������	#FF3AFF00$��1q�6�   $	��290��6�   ��6�   �� $
 Prezime�$ TwoWay=�$ PropertyChanged=�6(  5.      �� 5/      $ 
Horizontal=�6   .+�50      �� $y�Hidden=�6    $	��116��64   6B   �� 51      -   5        $	 ErrorLabel1��51      $��Center=�63   $
��Left=�6N   
������ 
���  �� . $��0q�6�   $��20��6�   $	��290��6�   ��6�   �� $
 PrezimeGreska�$ TwoWay=�$ PropertyChanged=�6*  52      �� 53      $ 
Horizontal=�6   .+�54      �� $��Center=�6   $��Center=�6@   ���	#FF3AFF00$
��Bold"�6r   $
��Left=�6�   $��14(�6�   $��JMBG:��6�   6�   �� 55      $��64��6    $y�Hidden=�6+   6A   �� 56      -   5        $	 JMBGTb��56       . {�.  $��Center=�6R   $��Center=�6m   $��20��6�   
����������	#FF3AFF00$��1q�6�   $	��290��6�   ��6�   �� $

 JMBG�$ TwoWay=�$ PropertyChanged=�64  57      �� 58      $ 
Horizontal=�6   .+�59      �� $y�Hidden=�6    $	��116��64   6B   �� 5:      -   5        $	 ErrorLabel8��5:      $��Center=�63   $
��Left=�6N   
������ 
���  �� . $��0q�6�   $��20��6�   $	��290��6�   ��6�   �� $
 
JMBGGreska�$ TwoWay=�$ PropertyChanged=�6'  5;      �� 5<      $ 
Horizontal=�6   .+�5=      �� $��Center=�6   $��Center=�6@   ���	#FF3AFF00$
��Bold"�6r   $
��Left=�6�   $��14(�6�   $��Korisničko ime:��6�   6�   �� 5>      $��5��6    $y�Hidden=�6*   6@   �� 5?      -   5        $	 EmailTb��5?      $��Center=�6/   {�.  $��Center=�6\   $��20��6y   
����������	#FF3AFF00$��1q�6�   $	��290��6�   ��6�   �� $

 KIme�$ TwoWay=�$ PropertyChanged=�6#  5@      �� 5A      $ 
Horizontal=�6   .+�5B      �� $y�Hidden=�6    $	��116��64   6B   �� 5C      -   5        $	 ErrorLabel2��5C      $��Center=�63   $
��Left=�6N   
������ 
���  �� . $��0q�6�   $��20��6�   $	��290��6�   ��6�   �� $
 
KImeGreska�$ TwoWay=�$ PropertyChanged=�6'  5D      �� 5E      $ 
Horizontal=�6   .+�5F      �� $��Center=�6   ���	#FF3AFF00$
��Bold"�6O   $
��Left=�6a   $��Center=�6|   $��14(�6�   $��Lozinka:��6�   6�   �� 5G      $��52��6    $y�Hidden=�6+   6A   �� 5H      -	   5        $	 	LozinkaTb��5H      $��Center=�61   {�.  $��20��6^   $
��Left=�6j   
����������	#FF3AFF00$��1q�6�   $	��290��6�   ��6�   �� $
 Lozinka1�$ TwoWay=�$ PropertyChanged=�6'  5I      �� 5J      $ 
Horizontal=�6   .+�5K      �� $y�Hidden=�6    $	��116��64   6B   �� 5L      -
   5        $	 ErrorLabel4��5L      $��Center=�63   $
��Left=�6N   
������ 
���  �� . $��0q�6�   $��20��6�   $	��290��6�   ��6�   �� $
 LozinkaGreska�$ TwoWay=�$ PropertyChanged=�6*  5M      �� 5N      $ 
Horizontal=�6   .+�5O      �� $��Center=�6   ���	#FF3AFF00$
��Bold"�6O   $
��Left=�6a   $��Center=�6|   $��14(�6�   $��Datum rođenja:��6�   6�   �� 5P      $��3��6    $y�Hidden=�6*   6@   (  "System.Windows.Controls.DatePicker  5Q      -   5          Name$ DatRodjenjaDp��5Q   !   $��Center=�68   {�.  $
��Left=�6e   
����������	#FF3AFF00$��1q�6�   $	��150��6�      Text 6�   �� $
 DatumRodjenja�$ TwoWay=�$ PropertyChanged=�6'  5R      �� 5S      $ 
Horizontal=�6   .+�5T      �� $y�Hidden=�6    $	��116��64   6B   �� 5U      -   5        $	 
ErrorLabe5��5U      $��Center=�62   $
��Left=�6M   
������ 
���  �� . $��0q�6�   $��20��6�   $	��290��6�   ��6�   �� $
 DatumRodjenjaGreska�$ TwoWay=�$ PropertyChanged=�6/  5V      �� 5W      $ 
Horizontal=�6   .+�5X      �� $��Center=�6   ���	#FF3AFF00$
��Bold"�6O   $
��Left=�6a   $��Center=�6|   $��14(�6�   $��Uloga:��6�   6�   �� 5Y      $��63��6    $y�Hidden=�6+   6A   �� 5Z      -   5         ��Name$ UlogaCmbBox��5Z      $��Center=�64   $��20��6O   $
��Left=�6[    �� 
IsReadOnly .  �� 
IsEditable .  {�.  
����������	#FF3AFF00$��1q�6�   $	��150��6�    �� SelectedItem 6�   �� $
 Uloga�$ TwoWay=�$ PropertyChanged=���6R  �� $
 UlogeKorisnika�$ TwoWay=�$ PropertyChanged=�5\      5]      �� 5^      $ 
Horizontal=�6   .+�5_      �� $y�Hidden=�6    $	��116��64   6B   �� 5`      -   5        $	 
ErrorLabe6��5`      $��Center=�62   $
��Left=�6M   
������ 
���  �� . $��0q�6�   $��20��6�   $	��290��6�   ��6�   �� $
 UlogaGreska�$ TwoWay=�$ PropertyChanged=�6'  5a      �� 5b      $ 
Horizontal=�6   y�66   �� $
 AdresaVidljiva�$ TwoWay=�$ PropertyChanged=�.+�5c      �� $��Center=�6   ���	#FF3AFF00$
��Bold"�6O   $
��Left=�6a   $��Center=�6|   $��14(�6�   $��Adresa:��6�   6�   �� 5d      $��57��6    $y�Hidden=�6+   6A   �� 5e      $ 
Horizontal=�6!   .+�5f      �� -   5        $	 AdresaTbUlica��5f   "   {�.  $��Center=�6�   $��20��6�   $
��Left=�6�   
����������	#FF3AFF00$��1q�6  $	��100��6$  ��6K   �� $
 AdresaUlica�$ TwoWay=�$ PropertyChanged=�62  �� 5g      $��2��6$   $y�Hidden=�6.   6D   �� 5h      -   5        $	 AdresaTbBroj��5h   "   {�.  $��Center=�6�   $��20��6�   $
��Left=�6�   
����������	#FF3AFF00$��1q�6  $��36��6"  ��6J   �� $
 
AdresaBroj�$ TwoWay=�$ PropertyChanged=�6/  �� 5i      $��2��6$   $y�Hidden=�6.   6D   �� 5j      -   5        $	 AdresaTbGrad��5j   "   {�.  $��Center=�6�   $��20��6�   $
��Left=�6�   
����������	#FF3AFF00$��1q�6  $	��100��6"  ��6J   �� $
 
AdresaGrad�$ TwoWay=�$ PropertyChanged=�60  �� 5k      $��2��6$   $y�Hidden=�6.   6D   �� 5l      -   5        $	 AdresaTbPBroj��5l   "   {�.  $��Center=�6�   $��20��6�   $
��Left=�6�   
����������	#FF3AFF00$��1q�6  $��44��6$  ��6K   �� $
 AdresaPBroj�$ TwoWay=�$ PropertyChanged=�61  5m      5n      �� 5o      $ 
Horizontal=�6   y�67   �� $
 AdresaVidljiva�$ TwoWay=�$ PropertyChanged=�.+�5p      �� $y�Hidden=�6    $	��116��64   6B   �� 5q      -   5        $	 ErrorLabel7��5q      $��Center=�63   $
��Left=�6N   
������ 
���  �� . $��0q�6�   $��20��6�   $	��290��6�   ��6�   �� $
 AdresaGreska�$ TwoWay=�$ PropertyChanged=�6)  5r      �� 5s      $y�Hidden=�6   $��10��60   6>   �� 5t      $ 
Horizontal=�6   $��Center=�67   .+�5w      �� -   5         ��Name$ OdustaniBtn��5w      $
��Left=�62   $	��120��6M   $��25��6Y   $��Zatvori prozor��6e   $
��Bold"�6~   ���	#FF3AFF00$��2q�6�   ��6�   �� *OdustaniCommand+6�   5x      5z      5{      5|      5}      