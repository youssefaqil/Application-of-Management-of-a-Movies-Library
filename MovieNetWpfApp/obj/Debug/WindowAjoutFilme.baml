   M S B A M L   `   `   `  ����I  EMovieNetWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MovieNetWpfApp.ViewModelMovieNetWpfApp.ViewModel  5      %    MovieNetWpfApp.WindowAjoutFilme   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:MovieNetWpfApp.ViewModel     5        � Title$  Ajouter un Filme��5	   	   $	��522��6"   $��501.2��6/   $��0q�5
   	   (  "MahApps.Metro.Controls.MetroWindow   	GlowBrush
 �   � � 
ResizeMode$ CanResizeWithGrip=�5   	      WindowTransitionsEnabled .   � WindowStartupLocation$ CenterScreen=�5   	    
  UserVM � DataContext# [  5   	   .��5      � .+�5   
   �� $��Titre :��6   $��59,43,362.4,353q�6#    J� RenderTransformOrigin$ -0.64,0.617&�6<   �� 5   
   $��26��6E   $��180,43,136.4,0q�6Q    �� TextWrapping$
 Wrap=�6i   $	��Top=�6}   $	��178��6�   ��6   ��  �� Path$ Title_UserMovie�	 �� Mode$	 TwoWay=�6�   �� 5   
   $��Durée :��6   $��56,106,362.4,288q�6#   �� 5   
   $��24��6H   $��180,106,136.4,0q�6T   $
 Wrap=�6m   $	��Top=�6�   $	��178��6�   ��6   �� $ Duration_UserMovie�$	 TwoWay=�6�   �� 5   
   $��Genre :��6   $��56,174,353.4,275q�6#   �� 5   
   -  'System.Windows.Input.KeyboardNavigation
   TabIndex$
 3��6   $��181,178,136.4,288q�63   $��20��6N    �� SelectedIndex$ 0��6Z   $
��Left=�6n   $��Center=�5      ��62   �� *Items+ �� SelectedValue 6P   �� *Items+�� 5   
   $��
Résumé :��6   $��47,222,362.4,171q�6$   �� 5   
   $
 Wrap=�6G   $��181,222,33.4,153q�6\    �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$ Disabled=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   ��6   �� $ Summary_UserMovie�$	 TwoWay=�6�   �� 5!   
   $��24��6=   $��218,366,33.4,0q�6I   $
 Wrap=�6a   $	��Top=�6u   ��6   �� *SelectedPath+$	 TwoWay=�6u   �� 5"   
   $#��Importer Affiche du filme ...��6.   $
��Left=�6W   $��
10,366,0,0q�6r   $	��Top=�6�   $	��168��6�   ���	#FF9AAFBC��6   �� *
Pathfile+��5$      �� 5%       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5&      �  � Color$ Black��6#    � Offset$ 0Q�61   � 5'      $ 	#FF9D5454��6#   $ 1Q�65   5(      5*      �� 5-   
   $��Ajouter��64   $
��Left=�6G   $��181,443,0,0q�6b   $	��Top=�6w   ���	#FF3DAAC5$	��130��6�   ���	#FF4EB3F0��6   �� *AjouterFilme+6�   50      51      