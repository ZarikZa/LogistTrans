   M S B A M L   `   `   `  ����G  CslavasRabota, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:slavasRabotaslavasRabota  5   	       slavasRabota.LogistOkno   5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a;mat1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:slavasRabota     5   	     � Title$  Логист��5	   	   ���#3D3D3D � WindowState$ 	Maximized=�5   	   $	��850��5   	   $
��1500��6   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��5* �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $
��0.1* �6   .+�5   
   �� $��Логист��6   $��2��6"   
�������$��Center=�6I   $��Center=�6f   $��Times New Roman)�6�   $��48(�6�   �� 5   
   -   5         ��Name$ ExitBtm��5      $��
Выход��6"   $��60��62   $��30(�6>   
�������$��Times New Roman)�6_   $��1��6|   6�    � 5   
   -   5          �Name$ FrameLog��5        � NavigationUIVisibility$ Hidden=�6"   $��1��6B   $��2��6O   � 5   
   $��2��6   $��2��6    5      �� 5      �� 5      �� 5      .+�5       �� -   5        $ TransportPereh��5       $��Транспорт��6-   
�������$��Times New Roman)�6T   $��20(�6q   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 30��6   $��60��6�      MaterialDesignFlatButton#��[  6�   ���#0DBF406�   �� 5!      -   5        $ RoutesPereh��5!      $��1��6*   $��Маршруты��6:   
�������$��Times New Roman)�6`   $��20(�6}   $ 30��6�   $��60��6�   #��[  6�   ���#0DBF406  �� 5"      -   5        $ OtchetPereh��5"      $��2��6*   $%��Маршрутные листы��6:   
�������$��Times New Roman)�6h   $��20(�6�   $ 30��6�   $��60��6�   #��[  6�   ���#0DBF406	  5#      5$      5%      