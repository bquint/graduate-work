   M S B A M L   `   `   `  ����H  DSudnoTest_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SudnoTest_AppSudnoTest_App  5   	       SudnoTest_App.EditUsers   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SudnoTest_App     5   	     � Title$;  5Редактирование пользователя��5   	   $	��600��6-   $	��800��6:    � Icon$ 
371659.jpg��6F   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��100 �6   6+   �� 5      6   .+�5   
   � $��0��6   ���	#FF0C2F7F$��Stretch=�65   $	��100��6S   $��
0,0,-0.4,0q�6`   $	��Top=�6t   $	��600��6�   .+�5      �� -   5         ��Name$
 name��5      $��Имя��6'   $��Right=�62   $��15(�6N   $
��Bold"�6\   
�������$��0,5,29,0q�6�   �� 5      $��
newimg.png��6   $
��Left=�6)   $	��100��6D   $	��Top=�6Q   $��90��6i   $��	10,5,0,-5q�6t   o� 5      $	��Top=�6   $��Right=�6+   $��50��6G   $��0 30 0 0q�6S   ���	#FF0C2F7F.@�5      m� ��5      �� 5      $��Menu_button.png��6    $��50��69   $��50��6D   $��0 0 10 0q�6P   .@�5      m� -   5        $��
Назад��5      $��14(�6.   ���	#FF0C2F7F
�������$��0 0 0 0q�6g   6x   5      5      5      � 5   
   $��1��6   ���	#FFC8D6F6$��0,0,-0.4,-19.6q�64   .+�5      ��  �� CornerRadius$ 20��6   $��30,30,30,45q�6'   
�������$��Stretch=�6O    �� Padding$ 30q�6k    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 60Q�6'      Color$ 	LightGray��67   	   ShadowDepth$	 1Q�6I   ._�5       �� .+�5!      � 
 � ColumnDefinitions
 5"      �� 5#      $
��174* �6/   �� 5$      $	��45* �6/   �� 5%      $
��254* �6/   .+�5'      �� $��0��6$   $0��* Раздел редактирования��61   $��Center=�6P   $��25(�6m   $
��Bold"�6{   $��83,-21,44.6,40.4q�6�   $��3��6�   $	��346��6�   6�   �� 5(      $��0��6$   $Y��S Здесь вы можете редактировать пользователей��61   $��Center=�6f   $��15(�6�   
�������$��83,30,-121.4,40.4q�6�   $	��512��6�   $��3��6�   6�   5)      � 5*      .+�5+      �� -   5        $��	mainPanel��5+   %   5,      � 5-       5.      �� 5/      �� 50      $��2* �6,   
 52      �� 53      $��3* �6/   �� 54      $
��160* �6/   .+�56      �� -   5        $��identic��56   /   $��id��6$   $y�Hidden=�6?   $��4,-39,460.6,14.4q�6S   $��2��6m   �� 57      $��ФИО��6$   $
��Left=�6/   $
��Bold"�6J   $��20(�6]   $��33.2,-5,0,-4.6q�6k   $��1��6�   $��2��6�   �� 58      $��
Логин��6$   $��33.2,40.6,0,-50.6q�62   $
��Left=�6M   $
��Bold"�6i   $��20(�6|    J� RenderTransformOrigin$ 1.762,1.161&�6�   $��1��6�   $��1��6�   6�   �� 59      $��Пароль��6$   $
��Left=�62   $
��Bold"�6N   $��20(�6a   $��33.2,102.6,0,-112.6q�6o   $��1��6�   $��1��6�   6�   �� 5:      -   5         ��Name$	 FIO��5:   "   $�� ��6/   $��Center=�67   $	��250��6T   $	��320��6c   ���	#FFC8D6F6$��140.2,0,-12.4,-1q�6�   $��1��6�   $	��337��6�   $��2��6�   6�   �� 5;      -   5        $ login��5;   "   $�� ��61   $��Center=�69   $	��250��6V   $	��320��6e   ���	#FFC8D6F6$��140.2,48.2,-10.4,-50q�6�   $��1��6�   $	��335��6�   $��1��6�   6�   �� 5<      -   5        $
 pass��5<   "   $�� ��60   $��Center=�68   $	��250��6U   $	��320��6d   ���	#FFC8D6F6$��140.2,102.6,-10.4,-105.6q�6�   $��1��6�   $	��335��6�   $��1��6�   6�   5=      � 5>      $��20q�6   .+�5?      �� -   5        ���	#FF0C2F7F$��Center=�5?   9   $��Изменить��6V   $��139,103,-20.4,-103q�6|   $	��315��6�   6�   5@      5A      5B      5D      5E      5F      