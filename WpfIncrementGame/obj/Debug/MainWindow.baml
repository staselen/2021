   M S B A M L   `   `   `  ����K  GWpfIncrementGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WpfIncrementGameWpfIncrementGame  5   	   !    WpfIncrementGame.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WpfIncrementGame     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � ��5
   
   �� 5       �� ImageSource$ Assets/255082.jpg��6    j� Stretch$ UniformToFill=�69    �� Opacity$
 0.25Q�6Q    � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $
��auto �6   �� 5"      $
��auto �6   �� 5#      $
��auto �6   �� 5$      $
��auto �6   �� 5%      $��* �6   �� 5&      $��20 �6   .+�5(   
   �� $ ��The dojo of perma progress��6   $��3��65   $��1��6J   $��1��6Z   $��20(�6g   $
��Bold"�6u   �� 5)   
   $��Basic training ��6   $��1��6*   $��1��6?   $��2��6O   $
��Bold"�6\   �� 5*   
   -   5         ��Name$ PunchButton��5*      $��Punch��6&   $��1��66   $��3��6F   $��	4.5,5,0,5q�6S   6f   �� 5+   
   $��Fist strength:��6   $��2��6)   $��3��69   $��	4.5,5,0,5q�6F   �� 5,   
   -   5         ��Name$ FistStrengthText��5,      $��0��6*   $��3��66   $��3��6F   $��0,5,0,0q�6S   $��31��6d   $��50��6p   �� 5-   
   -   5        $ SideKickButton��5-      $��	Side kick��6)   $��1��6=   $��4��6M   $��	4.5,5,0,5q�6Z   6m   �� 5.   
   $��Leg strength:��6   $��2��6(   $��4��68   $��	4.5,5,0,5q�6E   �� 5/   
   -   5        $ LegStrengthText��5/      $��0��6)   $��3��65   $��4��6E   $��0,5,0,0q�6R   $��31��6c   $��50��6o   �� 50   
   -   5        $ PushUpButton��50      $��Push-up��6'   $��1��69   $��5��6I   $��	4.5,5,0,5q�6V   6i   �� 51   
   $��Core strength:��6   $��2��6)   $��5��69   $��	4.5,5,0,5q�6F   �� 52   
   -   5        $ CoreStrengthText��52      $��0��6+   $��3��67   $��5��6G   $��0,5,0,0q�6T   $��31��6e   $��50��6q   53      54      