   M S B A M L   `   `   `  ����G  CslavasRabota, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:slavasRabotaslavasRabota  5          slavasRabota.Voditeli   5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a;mat1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:slavasRabota     5        N� Title$  Водители��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
VoditeliDG��5      ���#B6B6B6   AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя водителя��6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
DriverName+6D     5      $ Имя водителя��6G    6%   �� *DriverSurname+6G     5      $ Имя водителя��6J    6%   �� *DriverMiddleName+6J     5      $! Номер лиценции��6G    6%   �� *DriverLecence+6G     5      $ 
Логин��6?    6%   �� *Email+6?   5      � 5   
   $��1��6    � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      .+�5(      �� 	 �� CornerRadius$	 10��6   ���#C4C4C4���#C4C4C4$��50��6R   $	��350��6^   ._�5)      �� -   5        
 ��Name$
 DriverNameTbx��5)      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Имя водителя��61   $��Times New Roman)�6T   $��20(�6q   
�������6   5*      �� 5+      $	 10��6   ���#C4C4C4���#C4C4C4$��50��6R   $	��350��6^   $��1��6j   ._�5,      �� -   5        $
 DriverSurnameTbx��5,      $% Фамилия водителя��64   $��Times New Roman)�6[   $��20(�6x   
�������6�   5-      �� 5.      $	 10��6   ���#C4C4C4���#C4C4C4$��50��6R   $	��350��6^   $��2��6j   ._�5/      �� -   5        $
 DriverMiddleNameTbx��5/      $' !Отчество водителя��67   $��Times New Roman)�6_   $��20(�6|   
�������6�   50      �� 51      $	 10��6   ���#C4C4C4���#C4C4C4$��50��6R   $	��350��6^   $��3��6j   ._�52      �� -   5        $
 DriverLecenceTbx��52      $2 ,Номер лицензии водителя��64   $��Times New Roman)�6b   $��20(�6   
�������6�   53      �� 54      $	 10��6   ���#C4C4C4���#C4C4C4$��50��6R   $	��350��6^   $��4��6j   ._�55      �� -   5        $
 	LoginnTbx��55      $ 
Логин��6-   $��Times New Roman)�6I   $��20(�6f   
�������6t   56      �� 57      $	 10��6   ���#C4C4C4���#C4C4C4$��50��6R   $	��350��6^   $��5��6j   ._�58      �� -   5        $
 PassworddTbx��58      $ Пароль��60   $��Times New Roman)�6M   $��20(�6j   
�������6x   59      �� 5:      -   5         ��Name$ AddBtm��5:      $��Добавить��6%   
�������$��Times New Roman)�6K   $��20(�6h   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6v   $��50��6�   $	��350��6�      MaterialDesignFlatButton#��[  6�   ���#0DBF40$��7��6�   6  �� 5;      -	   5        $ EditBtm��5;      $��Изменить��6&   
�������$��Times New Roman)�6L   $��20(�6i   $ 10��6w   $��50��6�   $	��350��6�   #��[  6�   ���#0DBF40$��8��6�   6  �� 5<      -
   5        $ 	DeleteBtm��5<      $��Удалить��6(   
�������$��Times New Roman)�6M   $��20(�6j   $ 10��6x   $��50��6�   $	��350��6�   #��[  6�   ���#0DBF40$��9��6�   6  �� 5=      -   5        $ bnullBtm��5=      $��Обнулить поля��6'   
�������$��Times New Roman)�6R   $��20(�6o   $ 10��6}   $��50��6�   $	��350��6�   #��[  6�   ���#0DBF40$��10��6�   6  5>      5?      5@      