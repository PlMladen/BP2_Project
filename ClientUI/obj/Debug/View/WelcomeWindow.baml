   M S B A M L   `   `   `  ����C  ?ClientUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ClientUI.ViewClientUI.View  5   	   -clr-namespace:ClientUI.ViewClientUI.View  5   	   7 clr-namespace:ClientUI.ViewModelClientUI.ViewModel  5   	   !    ClientUI.View.WelcomeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ClientUI.View     5   	   -viewsclr-namespace:ClientUI.View     5   	   6	viewmodel clr-namespace:ClientUI.ViewModel     5   	   U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5	   	     � 
ResizeMode$  CanResizeWithGrip=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency .   � Title$ 
HomeWindow��5   	   $	��650��6   $	��970��6,   
���   � � Icon$3 -../Media/e8a87771fafda0cbb812f38e3f6c9afe.gif��6N    � DataContext 5      )   #ClientUI.ViewModel.WelcomeViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $	��10* �6   6-   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $	��10* �6   6+   �� 5      $��* �6   6)   .+�5   
   �� $��1��6   $��1��6    �� CornerRadius$ 20��6.   $��8q�6@   ���	#FF3AFF00._�5      �  5       �� 5!      $��2* �6'   64   �� 5"      $��3* �6'   64    5$      �� 5%      $��* �6$   61   �� 5&      $��3* �6$   62   �� 5'      $��2* �6$   62   �� 5(      $	��10* �6$   63   �� 5)      $��* �6$   61   .+�5+      �� $��1��6   $��5��6(   }�. "  WpfAnimatedGif.ImageBehavior	   AnimatedSource$3	 -../Media/e8a87771fafda0cbb812f38e3f6c9afe.gif��6M   $
��Fill=�6�   6�   �� 5,      
 �� Orientation$
 Vertical=�6   $��1��64   $��0��6A   .+�5-      �� ���	#FF3AFF00$
��Bold"�63   $��Center=�6E   $��24(�6b   $��Bottom=�6p   $��Bottom=�6�   $��Dobrodošli��6�   6�   �� 5.      ���	#FF3AFF00$
��Bold"�63   $��Center=�6E   $��18(�6b   $	��Top=�6p   $	��Top=�6�   $��u aplikaciju��6�   6�   5/      �� 50      ���	#FF3AFF00$��2��6/   $��0��6<   $��0 5 0 0q�6L   $
��Bold"�6]   $��Center=�6o   $��14(�6�   $	��Top=�6�   $	��Top=�6�   $,��&Molimo Vas da se ulogujete za nastavak��6�   6  �� 51      $
 Vertical=�6   $��3��64   $��0��6A   .+�52      �� $
 Vertical=�6!   $��5q�68   $��Center=�6C   .+�53      �� $
��Left=�6   $��Center=�6?   ���	#FF3AFF00$
��Bold"�6q   $
��Left=�6�   $��14(�6�   $��Korisničko ime:��6�   6�   �� 54      $y�Hidden=�6    $��0��64   6A   �� 55      -   5         ��Name$ EmailTb��55      $��Center=�60   $��Center=�6K   $
��Left=�6m   
����������	#FF3AFF00$��1q�6�   $��25��6�   $	��290��6�   ��6�   ��  �� Path$ Email� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�63  �� 56      $y�Hidden=�6    $��2��64   6A   �� 57      -   5        $ 
ErrorLabel��57      $��Center=�62   $��1��6M   $
��Left=�6Z   
������ 
���  �� �� 
IsReadOnly . $��0q�6�   $��20��6�   $	��290��6�   ��6�   �� $ ImeErrorLabel�$ TwoWay=�$ PropertyChanged=�66  58      �� 59      $
 Vertical=�6!   $��5q�68   $��Center=�6C   .+�5:      �� $��Center=�6   ���	#FF3AFF00$
��Bold"�6O   $
��Left=�6a   $��Center=�6|   $��14(�6�   $��Lozinka:��6�   6�   G� 5;      -   5         G�Name$ 	LozinkaTb��5;   "   $��Center=�65   $
��Left=�6P   $��Center=�6k   
����������	#FF3AFF00$��25��6�   $��1q�6�   $	��290��6�   6�   �� 5<      $y�Hidden=�6    $��2��64   6A   �� 5=      -   5        $ ErrorLabel1��5=      $��Center=�64   $
��Left=�6O   
������ 
���  �� . $��0q�6�   $��20��6�   $	��290��6�   ��6�   �� $ LozinkaErrorLabel�$ TwoWay=�$ PropertyChanged=�6.  5>      �� 5?      $��5��6    $y�Hidden=�6+   6A   �� 5@      $
 
Horizontal=�6!   $��Center=�6:   .+�5A      �� -   5         ��Name$ LoginBtn��5A   !   $	��220��63   $��25��6?   $��	Uloguj se��6K   $
��Bold"�6_   ���	#FF3AFF00$��2q�6�   ��6�   �� *LoginCommand+��6�   ��  �� ElementName$ 	LozinkaTb��6�   5D      �� 5E      $��15��6    $y�Hidden=�6,   6B   �� 5F      $
 
Horizontal=�6!   $��Center=�6:   .+�5G      �� ���	#FF3AFF00$
��Bold"�67   $��Center=�6I   $��Center=�6f   $��14(�6�   $��Nemate nalog? ��6�   6�   �� 5H      ���	#FF3AFF00$
��Bold"�67   $��Center=�6I   $��Center=�6f   $��14(�6�   $��Registrujte se��6�   6�   �� 5J      -   5        $ RegistracijaBtn��5J   !   $��14(�6:   $��20��6I      HyperlinkLikeButton#��[  6U   $��Center=�6�   $��0q�6�   ���	#FF3AFF00��6�   �� *RegistracijaCommand+.��5K      �� $��Center=�6(   $��ovdje��6C   $��Center=�6P   $
��Bold"�6m   $��Italic$�6   5L      5M      5N      5O      5P      5Q      5R      5S      