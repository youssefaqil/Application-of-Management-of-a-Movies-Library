   M S B A M L   `   `   `  ����  MovieNetWpfApp%    MovieNetWpfApp.WinModifierMovie   5      H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Modifier Un Filme��5
   	   $��0q�5   	   (  "MahApps.Metro.Controls.MetroWindow   	GlowBrush
 �   � � 
ResizeMode$ CanResizeWithGrip=�5   	      WindowTransitionsEnabled .   � WindowStartupLocation$ CenterScreen=�5   	    
  UserVM � DataContext# [  5   	   $��746.4��6/   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��256* �6   �� 5      $
��162* �6   �� 5      $
��343* �6   .+�5   
   �� $��Titre :��6   $��59,43,153,550.2q�6#    J� RenderTransformOrigin$ -0.64,0.617&�6<   �� 5   
   $��26��6E   $��58,0,269.6,647.8q�6Q    �� TextWrapping$
 Wrap=�6k   $��Bottom=�6   $	��178��6�   $��2��6�   $��1��6�   ��6   �� 	 �� Path$	 Title_UserMovie�
 �� Mode$
 TwoWay=�6�   �� 5   
   $��Durée :��6   $��56,106,101,487.2q�6#   �� 5   
   $��24��6H   $��58,106,269.6,0q�6T   $
 Wrap=�6l   $	��Top=�6�   $	��178��6�   $��2��6�   $��1��6�   ��6   �� $	 Duration_UserMovie�$
 TwoWay=�6�   �� 5   
   $��Genre :��6   $��56,174,91,420.2q�6#   �� 5    
   -  'System.Windows.Input.KeyboardNavigation   TabIndex$ 3��6   $��10,174,245.6,516.8q�63   $��20��6O    �� SelectedIndex$ 0��6[   $
��Left=�6o   $��Center=�5!      $��2��6v   $��1��6�   ��62   �� *Items+ �� SelectedItem 6P   �� *SelectedItem+6�   �� 5"   
   $��
Résumé :��6   $��56,222,91,353.2q�6$   �� 5#   
   $
 Wrap=�6G   $	��400��6[   $��182,222,87.6,376.8q�6g    �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$ Disabled=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   $��3��6�   $��Times New Roman)�6�   $��14(�6  ��6   �� $	 Summary_UserMovie�$
 TwoWay=�6  �� 5%   
   $��24��6=   $��202,621,48.6,0q�6I   $
 Wrap=�6a   $	��Top=�6u   $��3��6�   ��6   �� *SelectedPath+$
 TwoWay=�6�   �� 5'   
   -   5        $��image��5'   o   $
��Left=�6>   $��11,0,0,130.8q�6Y   $
��Fill=�6|   $��Bottom=�6�   $	��208��6�   $	��220��6�   $��2��6�   $��1��6�   ��6   �� *SelectedPath+$
 TwoWay=�6�   �� 5)   
   $#��Importer Affiche du filme ...��6.   $
��Left=�6W   $��
10,621,0,0q�6r   $	��Top=�6�   $	��168��6�   ���	#FF9AAFBC��6   �� *
Pathfile+��5*      �� 5+       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5,      �  � Color$ Black��6#    � Offset$ 0Q�61   � 5-      $ 	#FF9D5454��6#   $ 1Q�65   5.      50      �� 53   
   $��Modifier��65   $
��Left=�6I   $��
58,669,0,0q�6d   $	��Top=�6x   ���	#FF3DAAC5$	��130��6�   ���	#FF4EB3F0$��2��6�   $��1��6�   ��6   �� *ModifierFilme+6�   56      57      