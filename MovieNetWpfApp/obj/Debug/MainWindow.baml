   M S B A M L   `   `   `  ����I  EMovieNetWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MovieNetWpfApp.ViewModelMovieNetWpfApp.ViewModel  5          WpfApplication.MainWindow   5      0local&clr-namespace:MovieNetWpfApp.ViewModel  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      =	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5        � Title$  Connexion Utilisateur��5      $	��600��65   $	��800��6B      AccentColorBrush(  "MahApps.Metro.Controls.MetroWindow   	GlowBrush# �   5       � WindowStartupLocation$ CenterScreen=�5	       � Icon$) #Resources/icons8-update-user-48.png��5
       
 UserVM � DataContext# [ 5         RightWindowCommands 5      +  %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� $��settings��6   �� 5      .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��4 0 0 0q�6    $��Center=�61   $��deploy cupcakes��6L   5      5      5      .��5      � .+�5   
   �� $��Login :��6   $
��Left=�6"   $��
58,206,0,0q�6=   $	��Top=�6Q   $��60��6i   �� 5   
   -   5        $��login��5   1   $
��Left=�6>   $��23��6Y   $��141,207,0,0q�6e    �� TextWrapping$
 Wrap=�6z   $	��Top=�6�   $	��178��6�   ��6   �� *LoginBoxValue+6�   �� 5   
   $��Mot de passe :��6   $
��Left=�6)   $��
19,241,0,0q�6D   $	��Top=�6X   $��86��6p   G� 5   
   -   5        $��passwordBox��5      $
��Left=�6)   $��23��6D   $��141,238,0,0q�6P   $	��Top=�6f   $	��178��6~   �� 5   
   $��s'identifier��6d   $
��Left=�6|   $��190,298,0,0q�6�   $	��Top=�6�   $	��129��6�   ��6   �� *	LogOnUser+��6/   ��  �� ElementName$ passwordBox��6�   �� 5    
   $��Nom :��6   $
��Left=�6    $��473,175,0,0q�6;   $	��Top=�6P   $��60��6h   �� 5!   
   $
��Left=�6)   $��23��6D   $��551,175,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��178��6�   ��6   �� *NomVM+6�   �� 5"   
   $��Prenom :��6   $
��Left=�6#   $	��Top=�6>   $��460,216,0,0q�6V   $��60��6k   �� 5#   
   $
��Left=�6,   $��23��6G   $��551,214,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��178��6�   ��6   �� *
PrenomVM+6�   �� 5$   
   $��Login :��6   $
��Left=�6"   $��476,258,0,0q�6=   $	��Top=�6R   	 J� RenderTransformOrigin$	 0.438,-0.234&�6j   $��60��6�   �� 5%   
   $
��Left=�6+   $��23��6F   $��551,256,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��178��6�   ��6   �� *	LoginVM+6�   �� 5&   
   $��Mode de passe :��6   $
��Left=�6+   $��427,304,0,0q�6F   $	��Top=�6[   $��98��6s   G� 5'   
   -   5        $��LogPassword��5'      $
��Left=�6)   $��23��6D   $��553,300,0,0q�6P   $	��Top=�6e   $	��176��6}   �� 5(   
   $��
s'inscrire��6f   $
��Left=�6{   $��600,354,0,0q�6�   $	��Top=�6�   $	��129��6�   ��6   �� *AjouterUser+��61   �� $ LogPassword��6�   �� 5+   
   $
��Left=�6   $��
215,48,0,0q�6/   $
��Wrap=�6C   $%��La Gestion des Films : MovieApp��6W   $	��Top=�6~   $��35��6�   $	��366��6�   $��22(�6�   $��Times New Roman)�6�   $
��Bold"�6�   �� 5,   
   $
��Left=�6   $��141,162,0,0q�6/   $
��Wrap=�6D   $��Se Connecter��6X   $	��Top=�6l   $��Times New Roman)�6�   $
��Bold"�6�   $��18(�6�   �� 5-   
   $
��Left=�6   $��553,128,0,0q�6/   $
��Wrap=�6D   $��Créer Un Compte��6X   $	��Top=�6o   $��Times New Roman)�6�   $��18(�6�   $
��Bold"�6�   �� 5.   
   $
��Left=�6   $	��472��62   $��
388,88,0,0q�6?   $	��Top=�6S   $��17��6k   #��� ��6v   ���	#FF2D5CFC6�   52      57      