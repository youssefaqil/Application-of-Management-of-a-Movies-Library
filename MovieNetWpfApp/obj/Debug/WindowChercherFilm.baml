   M S B A M L   `   `   `  ����I  EMovieNetWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MovieNetWpfAppMovieNetWpfApp  5   	   '    !MovieNetWpfApp.WindowChercherFilm   5      H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MovieNetWpfApp     5   	     � Title$  WindowChercherFilm��5	   	   $��411.2��6$   $��711.2��63    
  UserVM � DataContext# [  5
   	   .��5      � ��5   
   �� 5       �� ImageSource$a [C:\Users\yaqil\source\repos\MovieNetLibSolution\MovieNetWpfApp\Resources\vector-3d-film.jpg��6    j� Stretch$ UniformToFill=�6�    � ColumnDefinitions 5   
   �� 5      $
��312* �6   �� 5      $	��85* �6   .+�5   
   �� 
���   �$��22(�6'   $��315,22,21.8,313.6q�66   $
��Wrap=�6Q   $��	Castellar)�6�   $��2��6�   $
��Bold"�6�   ��6e   �� *Title_UserMovie+ �� Mode$ TwoWay=�6�   �� 5   
   -   5        $��image��5   �    �� BitmapScalingMode$ HighQuality=�6>   $��33,37,320.6,53.6q�6l   $
��Fill=�6�   ��6   �� *SelectedPath+$ TwoWay=�6�   �� 5   
   $��Genre : ��6   $��275,88,218.6,267.6q�6#   $��Times New Roman)�6?   $��14(�6\   �� 5   
   $��14(�6   ���	#FF0000F3$��324,93,96.8,253.6q�6:   $
��Wrap=�6U   $��Times New Roman)�6�   $
��Bold"�6�   $��2��6�   ��6i   �� *SelectedItem+6�   �� 5   
   ���	#FF080808$��14(�6,   $��324,139,9.8,73.6q�6_   $
��Wrap=�6y   $��2��6�   $��Lucida Bright)�6�   ��6;   �� *Summary_UserMovie+6�   �� 5   
   $��12(�6   $�� ��6"   ���#e8e2d7$��2��6?   $��414,333,72.8,9.6q�6S   $��	Underline{�6m   �� 5   
    � DataContext# �   6>   $��12(�6f    �� TextDecorations$ 	Underline{�6u   	 �� Command	 6   �� *AffAjouterCommentaire+.�6�   )'Cliquez ici pour Ajouter Un Commentaire5      5      �� 5   
   $��Note : ��6   $
��Left=�6"   $��
10,354,0,0q�6=   $	��Top=�6Q   $��90��6i   �� 5   
   $��12(�6   $
��Left=�6"   $��65,361,0,-0.4q�6=   $
��Wrap=�6T   $	��Top=�6�   
 J� RenderTransformOrigin$
 -0.278,-0.187&�6�   $��99��6�   $��21��6�   
���   �
�������$
��Bold"�6  ��6h   �� *Moyenne_Score+6  5#      5$      