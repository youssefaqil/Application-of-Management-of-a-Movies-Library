   M S B A M L   `   `   `  ����I  EMovieNetWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MovieNetWpfApp.ViewModelMovieNetWpfApp.ViewModel  5   	   (    "MovieNetWpfApp.WindowGestionMovies   5      H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:MovieNetWpfApp.ViewModel     5   	     � Title$   Ma Bibliothèque des Dilms��5
   	   $	��450��6+   $	��800��68    � Icon$1 +Resources\istockphoto-683579132-170x170.jpg��5   	    � DataContext 5      %  MovieNetWpfApp.ViewModel.UserVM  5   
   ��5      �� 5   
    �� ImageSource$# Resources\moviebackground.jpg��6   6C   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��273* �6   �� 5      $
��124* �6   ��5   
   �� 5      .+�5   
   �� $
��Left=�6   $��
288,10,0,0q�6/   $
��Wrap=�6C   $��Gérer Mes Films��6W   $	��Top=�6n   $��35��6�   $	��333��6�   $��22(�6�   $��Times New Roman)�6�   $
��Bold"�6�   $��2��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��userMovieclass��5         AutoGenerateColumns .  $��37,106,182.6,0q�6E   ��6]   �� *UserMovieclass+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ Titre��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *TitleGetSet+  5!      $ Genre��6%    64   �� *GenreGetSet+  5"      $ Durée��6%    64   �� *DurationGetSet+  5#      $ ID��6%    61   �� *
IdGetSet+	 �� Mode$	 TwoWay=�
   RowDetailsTemplate
 5)      �� 5*      .R�5,      �� $��0q�6   ���	#FF22AAE5 �� Padding$ 10q�6H   ._�5-      ��  �� Orientation$ Vertical=�6%   .+�5/      �� $��20��6(   �� 50      $ 
Horizontal=�6)   .+�52   "   �� $	��130��6)    � Cursor$
 Hand��66    
  UserVM# �   6p   $��Modifier ce Film��6�   ��6E   �� *AffModifierFilmeWindow+��53   &   �� 54   *    �� EndPoint$ 0.5,1&�6>    �� 
StartPoint$ 0.5,0&�6O   .��55   .   �  � Color$ Black��6;    � Offset$ 0Q�6I   � 56   .   $ 	#FF5E7D4D��6;   $ 1Q�6M   57   +   59   #   5;      �� 5=      $��20��6(   �� 5>      $ 
Horizontal=�6)   .+�5@   "   �� $	��130��6)   $
 Hand��65   # �   6g   $��Supprimer ce Film��6�   ��6D   �� *SupprimerFilme+��5A   &   �� 5B   *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5C   .   � $ Black��6;   $ 0Q�6I   � 5D   .   $ 	#FFF15959��6;   $ 1Q�6M   5E   +   5G   #   5I      �� 5J      $��50��6(   �� 5K      $ 
Horizontal=�6)   .+�5L   "   �� $��20(�6,   $��Times New Roman)�6:   
�������$��Center=�6�   ��6k   �� *TitleGetSet+6�   5M      �� 5N      $��20��6(   �� 5O      $ 
Horizontal=�6)   .+�5P   "   �� $��image��6�   $
��Left=�6U   $��190,0,0,0.2q�6p   $
��Fill=�6�   $��Bottom=�6�   $	��200��6�   ��6)   �� *ImageGetSet+$	 TwoWay=�6�   5Q      �� 5R      $��20��6(   �� 5S      $ 
Horizontal=�6)   .+�5T   "   �� $��15(�6,   
�������$��Center=�6l   $
��Left=�6�   $��Times New Roman)�6�    �� TextAlignment$
 Left=�6�   $
��Wrap=�6�   $	��400��6�   $
��Auto��6�   ��6M   �� *SummaryGetSet+6�   5U      5X      5Y      5Z      5\      �� 5]   
   $��Ajouter Un film��64   $
��Left=�6N   $��	22,50,0,0q�6i   $	��Top=�6|   $	��130��6�   ���	#FF4EB3F0��6   �� *AffAjoutWindow+6�   �� 5_   
   $
��Left=�6   $��23��6-   $��
446,50,0,0q�69    �� TextWrapping$
 Wrap=�6M   $	��Top=�6�   $	��285��6�   $��2��6�   ��6a   �� *Title_UserMovie+$	 OneWayToSource=�6�   �� 5`   
   $��Rechercher Un film��65   $
��Left=�6R   $��
297,50,0,0q�6m   $	��Top=�6�   $	��130��6�   ���	#FF4EB3F0��6   �� *RechercherFilm+6�   5f      5i      