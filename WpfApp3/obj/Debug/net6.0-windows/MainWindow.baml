   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5   	       WpfApp3.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp3     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5       6!   �� 5!      6!   .+�5$   
   �� -   5         ��Name$ Enter��5$      $��7��64   $
��10 5q�6D   .��6R   
Вход6X   �� 5%   
   -   5        $
 Exit��5%      $��6��62   $
��10 5q�6B   .��6P   Регистрация6]   �� 5&   
   -   5        $ Exit1��5&      $y�Hidden=�64   $��6��6H   $
��10 5q�6X   .��6f   
Выход6m   �� 5'   
   -   5        $ RoCast��5'      ${�False��66   $��5��6H   $
��10 5q�6X   .��6f   В корзину6q   �� 5)   
   -   5         ��Name$ ProductView��5)   G   $��Hidden=�6   $��3��6\   $��0��6i   $��8��6y   $��9��6�   ��5*      �� 5+      .R�5,      � 6"   5-      ��5/      �� 50      .R�51      � $	��100��6   $	��300��6'    52      �� 53      $
��150* �6,   6<   �� 54      $
��auto �6,   6<   �� 55      $
��auto �6,   6<   �� 56      $
��auto �6,   6<   �� 57      $
��auto �6,   6<   �� 58      $
��auto �6,   6<   �� 59      $
��auto �6,   6<   �� 5:      $
��auto �6,   6<   .+�5<      �� $��0��6    ��6-   �� *	ImageData+6L   �� 5=      $��1��6$   ��61   �� *Name+6I   �� 5>      $��2��6$   ��61   �� *Description+6P   �� 5?      $��3��6$   ��61   �� *Manufacture+6P   �� 5@      $��4��6$   ��61   �� *Value+6J   �� 5A      $��5��6$   ��61   �� *Cost+6I   �� 5B      $��6��6$   ��61   �� *	Discont+6L   �� 5C      $��6��6$   $y�Hidden=�61   ��6E   �� *Id+6[   �� 5D      $ 	addToCast��6!   -   5        $��7��5D   L   $
��10 5q�6Y   .��6g   +6j   5E      5F      5H      5J      5K      