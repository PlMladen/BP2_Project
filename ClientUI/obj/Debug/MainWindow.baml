   M S B A M L   `   `   `  ����C  ?ClientUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ClientUI.ViewClientUI.View  5   	   7 clr-namespace:ClientUI.ViewModelClientUI.ViewModel  5   	       ClientUI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -viewsclr-namespace:ClientUI.View     5   	   6	viewmodel clr-namespace:ClientUI.ViewModel     5   	   -   5          � AllowsTransparency  .   � Title$ BP2_Project_ClientUI��5   	   $	��400��6&   $
��1150��66    � 
ResizeMode$ CanResizeWithGrip=�6F    � WindowStartupLocation$ CenterScreen=�6e    � WindowStyle$ ThreeDBorderWindow=�6�   
���   � � DataContext 5      ,   &ClientUI.ViewModel.MainWindowViewModel  5   
    � 	Resources 5       �� DataType(   "ClientUI.ViewModel.ServisViewModel   ClientUI.View.ServisView2   ,ClientUI.ViewModel.ServiserRacunaraViewModel(   "ClientUI.View.ServiserRacunaraView)   #ClientUI.ViewModel.RacunarViewModel   ClientUI.View.RacunarView1   +ClientUI.ViewModel.VlasnikRacunaraViewModel'	   !ClientUI.View.VlasnikRacunaraView,
   &ClientUI.ViewModel.KomponentaViewModel"   ClientUI.View.KomponentaView.   (ClientUI.ViewModel.GarantniListViewModel$   ClientUI.View.GarantniListView+   %ClientUI.ViewModel.PosjedujeViewModel!   ClientUI.View.PosjedujeView+   %ClientUI.ViewModel.SastojiSeViewModel!   ClientUI.View.SastojiSeView&    ClientUI.ViewModel.RadiViewModel   ClientUI.View.RadiView(   "ClientUI.ViewModel.DonosiViewModel   ClientUI.View.DonosiView+   %ClientUI.ViewModel.ServisiraViewModel!   ClientUI.View.ServisiraView*   $ClientUI.ViewModel.FuncProcViewModel    ClientUI.View.FuncProcView��%�  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *,
 +)(�� �     5      *, +)(�� ,    5"      *, +)(�� ^    5%      *, +)(�� �    5(      *, +)(�� �    5+      *, +)(�� �    5.      *, +)(�� &    51      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5      	  5      �� 5   
   " 
 6   .R�5        5      �� 5   
   "  6   .R�5         5!      �� 5"   
   "  6   .R�5#        5$      �� 5%   
   "  6   .R�5&        5'      �� 5(   
   "  6   .R�5)        5*      �� 5+   
   "  6   .R�5,        5-      �� 5.   
   "  6   .R�5/        50      �� 51   
   "  6   .R�52        53      54      .��56      �  � RowDefinitions 58   
   �� 59      $
��Auto �6   �� 5:      $
��Auto �6   �� 5;      $
��Auto �6   �� 5<      $
��Auto �6   .+�5>   
   �� -   5        $��DobrodosliLbl��5>      $��0��6%   $��10q�62   ���	#FF3AFF00$��18(�6U   $
��Bold"�6c   $��Italic$�6u   $��Center=�6�   $
��Left=�6�   6�   �� 5?   
   	 �� Orientation$	 
Horizontal=�6   $��Right=�6.   .+�5@      �� -   5        
 ��Name$
 	ProfilBtn��5@      $��0��6(   $	��138��66   $��22��6B      HyperlinkLikeButton#��[  6N   $��Center=�6{   $��0q�6�   ���	#FF3AFF00.��5A      �� $��Center=�6   $��Profil��67   $��Center=�6E   $
��Bold"�6b   $��Italic$�6t   5B      5C      �� 5D      -   5        $
 	OdjavaBtn��5D      $��0��6(   $	��138��66   $��22��6B   #��[  6N   $��Center=�6{   $��0q�6�   ���	#FF3AFF00.��5E      �� $��Center=�6   $��Odjava��67   $��Center=�6E   $
��Bold"�6b   $��Italic$�6t   5F      5G      5I      ]� 5J   
   $��1��6   $��Center=�6!   .+�5K      o� $	��Top=�6   
������ ���	#FF3AFF00$��2q�6Y   $��Stretch=�6m   .@�5L      m� $��Servisi��6   $��1q�6,   ���	#FF3AFF00���	#FF3AFF00 m� CommandParameter$ Servis view��6�    m� Command 6o   �� *
NavCommand+6�   m� 5O      $��Racunari��6   ���	#FF3AFF00���	#FF3AFF00$��1q�6{   $ Racunari view��6�    6-   �� *
NavCommand+y�6�   ��  �� Path$ AutorizacijaSA� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�m� 5P      $��Vlasnici racunara��6   ���	#FF3AFF00���	#FF3AFF00$��1q�6�   $ VLRacunara view��6�    66   �� *
NavCommand+y�6�   �� $ Autorizacija�$ TwoWay=�$ PropertyChanged=�m� 5Q      $��Serviseri racunara��6   ���	#FF3AFF00���	#FF3AFF00$��1q�6�   $ SerRacunara view��6�    67   �� *
NavCommand+y�6�   �� $ Autorizacija�$ TwoWay=�$ PropertyChanged=�m� 5R      $��
Komponente��6   ���	#FF3AFF00���	#FF3AFF00$��1q�6}   $ Komponente view��6�    6/   �� *
NavCommand+y�6�   �� $ AutorizacijaSA�$ TwoWay=�$ PropertyChanged=�m� 5S      $��Garantni listovi��6   ���	#FF3AFF00���	#FF3AFF00$��1q�6�   $ Gar list view��6�    65   �� *
NavCommand+y�6�   �� $ AutorizacijaSA�$ TwoWay=�$ PropertyChanged=�m� 5T      ���	#FF3AFF00���	#FF3AFF00$��1q�6�   $ Posjeduje view��6�   ��6   �� $ MeniStavkaPosjeduje�$ TwoWay=�$ PropertyChanged=� 6y   �� *
NavCommand+6�   m� 5U      $��Ugradnja komponenti��6   ���	#FF3AFF00���	#FF3AFF00$��1q�6�   $ SastojiSe view��6�    68   �� *
NavCommand+y�6�   �� $ AutorizacijaSA�$ TwoWay=�$ PropertyChanged=�m� 5V      $��Zapošljavanje servisera��6   ���	#FF3AFF00���	#FF3AFF00$��1q�6�   $ 	Radi view��6�    6<   �� *
NavCommand+y�6�   �� $ Autorizacija�$ TwoWay=�$ PropertyChanged=�m� 5W      ���	#FF3AFF00���	#FF3AFF00$��1q�6�   $ Donosi view��6�   ��6   �� $ MeniStavkaDonosi�$ TwoWay=�$ PropertyChanged=� 6v   �� *
NavCommand+6�   m� 5X      $��Servisiranja��6   ���	#FF3AFF00���	#FF3AFF00$��1q�6   $ Servisira view��6�    61   �� *
NavCommand+6�   m� 5Y      $��FuncProc��6   ���	#FF3AFF00���	#FF3AFF00$��1q�6{   $ FuncProc view��6�   $y�	Collapsed=�6�    6-   �� *
NavCommand+6�   5Z      5[      � 5]   
   $��2��6   .+�5^      �� $��3��6B   ��6   �� *CurrentViewModel+6B   5_      5a      5b      