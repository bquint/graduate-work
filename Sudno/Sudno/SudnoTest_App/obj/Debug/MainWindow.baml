   M S B A M L   `   `   `  ����H  DSudnoTest_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SudnoTest_AppSudnoTest_App  5   	       SudnoTest_App.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SudnoTest_App     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$"  ГИМС МЧС РОССИИ��5
      $	��700��6   $	��850��6+   
������� � Icon$ 
371659.jpg��6J   .��5      � ���	#FFC8D6F6.+�5   
   � ���	#FF0C2F7F$��Stretch=�6'   $	��100��6E   $	��Top=�6S   $	��835��6l   .+�5      �� -   5         ��Name$	 lol��5      $��
newimg.png��6!   $
��Left=�65   $��85��6P   $	��Top=�6\   $��85��6t   $��10,8,0,0q�6   �� 5      $��Авторизация��6   $��Center=�6+   $��30(�6H   $
��Bold"�6V   $��	0 25 0 20q�6h   
�������6�   5      �� 5   
   $	��400��6   $��10,130,10,50q�6    
�������$��Center=�6I    �� Padding$ 30q�6d   $	��550��6q    �� CornerRadius$ 20��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6#      Color$ 	LightGray��63      ShadowDepth$ 0Q�6E   6W   ._�5      �� .+�5      �� $:��4Добро пожаловать на экзамен!��6   $��30(�6@   $
��Bold"�6N   $��0 0 0 20q�6`   �� 5      $p��jПожалуйста, авторизуйтесь по выданным вам логину и паролю��6   $��15(�6]   
�������$��0 0 0 20q�6}   �� 5      -   5        	 ��Name$	 textBoxLogin��5      $��15(�60   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Введите логин��6>    %  !MaterialDesignFloatingHintTextBox#��[  6m   $��	0 0 0 -30q�6�   �� 5      -   5        $	 passBox2��5      $��15(�6,   $
  ��6:   #��[  6\   $y�Hidden=�6�   $��0 30 0 0q�6�   G� 5      -   5         G�Name$ passBox��5      $��15(�60   $!
 Введите пароль��6?     MaterialDesignPasswordBox#��[ 6o   $��	0 -30 0 0q�6�   � 5      .+�5      �� -   5         ��Name$ parol��5      ���	#FF0C2F7F$#��Показать пароль��6C   
���   �$��Right=�6r   $��15(�6�   $��0,30,0,40.4q�6�   $	��126��6�   $
��Auto��6�   ��5       �� 5!       �� 
TargetType" ��6.   .R�5"   "   �� #��z��6.   ��5#   &   �� 5$   *    �� 
TargetType" ��60    �� Triggers 5%   .   P� 5&   2    P� Property �@J�IsMouseOver P� Value . . �5'   6   ��  �� Property � �� �� Value$ 	Underline{�6b   5(   3   5*   +   5,   #   5-      5/      �� 51      -   5        ���	#FF0C2F7F$��
Войти��51   5   $
��Left=�6E   $��0,31,0,27.4q�6a   $	��338��6�   53      �� 54      $X��RНе удается войти? Обратитесь к преподавателю��6   $��15(�6P   
�������$��0 0 0 20q�6p   56      57      59      5:      