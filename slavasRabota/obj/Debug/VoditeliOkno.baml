   M S B A M L   `   `   `  ����G  CslavasRabota, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:slavasRabotaslavasRabota  5   	       slavasRabota.VoditeliOkno   5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a;mat1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:slavasRabota     5   	     � Title$  VoditeliOkno��5	   	   ���#3D3D3D � WindowState$ 	Maximized=�5   	   $	��850��5   	   $
��1500��6   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��5* �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $
��0.3* �6   .+�5   
   �� $��Водитель��6   $��2��6$   
�������$��Center=�6K   $��Center=�6h   $��Times New Roman)�6�   $��48(�6�   �� 5   
   -   5         ��Name$ ExitBtm��5      $��
Выход��6"   $��60��62   $��30(�6>   
�������$��Times New Roman)�6_   $��1��6|   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ MarshrutsDG��5      $��20(�6(   $��1��66   ���#B6B6B6   AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$!	 Название груза��6I   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *Orders.GruzName+6I     5      $	 Вес груза��6K   
 6%   �� *Orders.GruzWeight+6K     5      $	 Дата отправки��6M   
 6%   �� *Orders.DateOtpravki+6M     5      $	 Дата доставки��6M   
 6%   �� *Orders.DateDostavki+6M     5      $'	 !Адрес отправления��6E   
 6%   �� *Otpravlenie+6E     5       $!	 Адрес доставки��6B   
 6%   �� *
Dostavka+6B     5!      $(	 "Протяжённость в км��6G   
 6%   �� *Protyajonnost+6G     5"      $	 Номер машины��6M   
 6%   �� *Transport.CarNomber+6M     5#      $	 Статус��6S   
 6%   �� *RouteStatuses.RouteStatus+6S     5$      $	 Оплата��6J   
 6%   �� *Orders.SumOplati+6J   5&      � 5'   
   $��1��6   $��1��6    5(      �� 5)      �� 5*      $��4* �6    �� 5+      .+�5-      �� -   5         ��Name$ StatusCB��5-      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Статус��6)   $	��350��6F   $��50��6R   ���#B6B6B6$��Times New Roman)�6s   $��20(�6�   
�������6�   �� 5.      -   5        $ EditBtm��5.      $��Изменить��6&   
�������$��Times New Roman)�6L   $��20(�6i   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6w   $��50��6�   $	��350��6�      MaterialDesignFlatButton#��[  6�   ���#0DBF40$��2��6�   6  5/      50      51      