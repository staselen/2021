   M S B A M L   `   `   `  ����G  CMiningAddict, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MiningAddictMiningAddict  5   	       MiningAddict.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MiningAddict     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ 
MainWindow��5	      $	��599��6   $	��946��6%    � 	Resources 5
         Dark Fading Red �� 
TargetType �� Property �� Value �� EndPoint �� 
StartPoint � Color	 � Offset��%  &	        �� 5   
   " ��6(   .�5      ��  � ��$ 3q�60   �� 5       � �� 5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ Black��6#   $	 0Q�61   � 5      $ 	#FF700909��6#   $	 1Q�65   5      5      5      5      .��5      �� 
 �� Orientation$
 
Horizontal=�6   $	��560��6*   $	��940��67   .+�5   
   � -   5         �Name$ 	GridStats��5      $	��560��6"   $	��285��6/   ��5      �� 5       �� ImageSource$$ Assets/blackwoodbackground.png��6    �� Opacity$
 0.50Q�6J   .+�5      �� #��[  6   5"      � 5#   
   -   5        $ GridUpgrades��5#      $	��560��6%   $	��360��62   ��5$      �� 5%      $ Assets/mine1.jpg��6    j� Stretch$ UniformToFill=�6<   $
 0.90Q�6T   .+�5'      �� #��[  6   $��0,3,0,3q�6>   5)      � 5*   
   -   5        $ GridMine��5*      $	��560��6!   $	��285��6.   ��5+      �� 5,      $ Assets/blacksmith.png��6   $
 0.50Q�6A   .+�5.      �� #��[  6   5/      52      53      