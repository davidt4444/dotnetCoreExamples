   M S B A M L   `   `   `  ����  
BCE.Native    BCE.Native.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Blog Post Manager��5   	   $	��600��6#   $	��800��60   .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ lstPosts��5      $��0��6%   $��1��65   $��0,5,0,5q�6B    �� View 5      �� 5      .P�5      �� $��ID��6%    �� Width$ 50��6U    �� DisplayMemberBinding 61   �� *Id+6U   �� 5      $��Title��6%   $	 200��6[    64   �� *Title+6[   �� 5      $��Content��6%   $	 250��6_    66   �� *	Content+6_   5      5      �� 5   
   -   5        $��1��5      $��0��6!   $��New Post��6.   $��0,0,0,5q�6W   �� 5   
   -   5        $��1��5      $��1��6!   $��	Edit Post��6.   $��0,0,0,5q�6Y   �� 5   
   -   5        $��1��5      $��2��6!   $��Delete Post��6.   $��0,0,0,5q�6]   �� 5    
   -   5        $��0��5       $��4��6!   $��Refresh Posts��6.   $��5,5,0,0q�6a   5!      5"      