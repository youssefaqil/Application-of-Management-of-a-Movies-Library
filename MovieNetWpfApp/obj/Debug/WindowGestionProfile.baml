   M S B A M L   `   `   `  ����I  EMovieNetWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MovieNetWpfApp.ViewModelMovieNetWpfApp.ViewModel  5   	   )    #MovieNetWpfApp.WindowGestionProfile   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:MovieNetWpfApp.ViewModel     5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   =	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5	   	     � Title$  Mon Profile��5
   	   $��476.4��6   $	��526��6,      AccentColorBrush(  "MahApps.Metro.Controls.MetroWindow   	GlowBrush# �   5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$3 -Resources/icons8-couple-cinema-tickets-50.png��5   	    � DataContext 5      %  MovieNetWpfApp.ViewModel.UserVM  5   
      RightWindowCommands 5      +  %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� $��settings��6   �� 5      .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��4 0 0 0q�6    $��Center=�61   $��deploy cupcakes��6L   5      5      5      .��5      � .+�5   
   �� $��Nom :��6   $��82,100,389,320.2q�6!    J� RenderTransformOrigin$ -0.64,0.617&�6;   �� 5   
   $��136,105,173,315.2q�60   $
��Wrap=�6K   $��14(�6`   $��Times New Roman)�6n   $
��Bold"�6�   ��6   �� *	NomProfil+6�   �� 5    
   $��Prenom :��6   $
��Left=�6#   $��
68,145,0,0q�6>   $	��Top=�6R   $��87��6j   �� 5!   
   $
��Left=�62   $��136,150,0,0q�6M   $
��Wrap=�6b   $	��Top=�6w   $��29��6�   $	��211��6�   $��14(�6�   $��Times New Roman)�6�   $
��Bold"�6�   ��6   �� *PrenomProfil+6�   �� 5"   
   $��Login :��6   $
��Left=�6"   $��
75,196,0,0q�6=   $	��Top=�6Q   $��87��6i   �� 5#   
   $
��Left=�61   $��136,201,0,0q�6L   $
��Wrap=�6a   $	��Top=�6u   $��35��6�   $	��211��6�   $��14(�6�   $��Times New Roman)�6�   $
��Bold"�6�   ��6   �� *LoginProfil+6�   �� 5&   
   $��185,10,203,0q�6   $
��Wrap=�6*   $��Mon Profile��6>   $	��Top=�6Q   $��35��6i   $��22(�6u   $��Times New Roman)�6�   $
��Bold"�6�   �� 5'   
   $��Modifier��6=   $��185,334,216,72.2q�6P    �� TextAlignment$ Center=�6j   ��6   �� 	 �� Path$	 ModifierDirection�6j   5)      5*      