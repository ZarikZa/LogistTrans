   M S B A M L   `   `   `  ����G  CslavasRabota, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:slavasRabotaslavasRabota  5          slavasRabota.Marshruts   5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a;mat1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:slavasRabota     5        N� Title$  Маршруты��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ MarshrutsDG��5      ���#B6B6B6   AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$! Название груза��6I   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Orders.GruzName+6I     5      $ Вес груза��6K    6%   �� *Orders.GruzWeight+6K     5      $ Дата отправки��6M    6%   �� *Orders.DateOtpravki+6M     5      $ Дата доставки��6M    6%   �� *Orders.DateDostavki+6M     5      $' !Адрес отправления��6E    6%   �� *Otpravlenie+6E     5      $! Адрес доставки��6B    6%   �� *
Dostavka+6B     5      $( "Протяжённость в км��6G    6%   �� *Protyajonnost+6G     5      $ Номер машины��6M    6%   �� *Transport.CarNomber+6M     5      $ Статус��6S    6%   �� *RouteStatuses.RouteStatus+6S   5      � 5   
   $��1��6    � RowDefinitions 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      �� 5*      �� 5+      .+�5-      �� -   5        	 ��Name$	 OrderCB��5-      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 
Заказ��6(   $	��350��6D   $��50��6P   ���#B6B6B6$��Times New Roman)�6r   $��20(�6�   
�������6�   �� 5.       �� CornerRadius$ 10��6   ���#C4C4C4���#C4C4C4$��50��6R   $	��350��6^   $��1��6j   ._�5/      �� -   5         ��Name$ OtprovlenieTbx��5/      $'
 !Адрес отправления��62   $��Times New Roman)�6Z   $��20(�6w   
�������6�   50      �� 51      $ 10��6   ���#C4C4C4���#C4C4C4$��50��6R   $	��350��6^   $��2��6j   ._�52      �� -   5        $ DostavkaTbx��52      $!
 Адрес доставки��6/   $��Times New Roman)�6T   $��20(�6q   
�������6   53      �� 54      $ 10��6   ���#C4C4C4���#C4C4C4$��50��6R   $	��350��6^   $��3��6j   ._�55      �� -   5        $ ProtiajennostTbx��55      $1
 +Протяжённость маршрута��64   $��Times New Roman)�6a   $��20(�6~   
�������6�   56      �� 57      -   5        $	 TransportCB��57      $
 Транспорт��6,   $	��350��6L   $��50��6X   ���#B6B6B6$��Times New Roman)�6y   $��20(�6�   
�������$��4��6�   �� 58      -   5        $	 StatusCB��58      $
 Статус��6)   $	��350��6F   $��50��6R   ���#B6B6B6$��Times New Roman)�6s   $��20(�6�   
�������$��5��6�   �� 59      -   5         ��Name$ AddBtm��59      $��Добавить��6%   
�������$��Times New Roman)�6K   $��20(�6h   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6v   $��50��6�   $	��350��6�      MaterialDesignFlatButton#��[  6�   ���#0DBF40$��8��6�   6  �� 5:      -	   5        $ EditBtm��5:      $��Изменить��6&   
�������$��Times New Roman)�6L   $��20(�6i   $ 10��6w   $��50��6�   $	��350��6�   #��[  6�   ���#0DBF40$��9��6�   6  �� 5;      -
   5        $ bnullBtm��5;      $��Обнулить поля��6'   
�������$��Times New Roman)�6R   $��20(�6o   $ 10��6}   $��50��6�   $	��350��6�   #��[  6�   ���#0DBF40$��10��6�   6  �� 5<      -   5        $ 	OtchetBtm��5<      $)��#Сформировать отчёт��6(   
�������$��Times New Roman)�6X   $��20(�6u   $ 10��6�   $��50��6�   $	��350��6�   #��[  6�   ���#0DBF40$��11��6  6  5=      5>      5?      