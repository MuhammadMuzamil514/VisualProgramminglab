   M S B A M L   `   `   `  ����  QuizApp    QuizApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Quiz App��5   	   $	��450��6   $	��800��6'   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��10q�6.   .+�5      �� -   5         ��Name$ TopicComboBox��5      $	��200��6.   $��0,0,10,0q�5      
����ح�
����  �5      �� 5      -   5        $ DifficultyComboBox��5      $	��200��63   
������
��� d �5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ QuestionsDataGrid��5      $��1��6.   $��10q�6;      AlternatingRowBackground
 �����   RowBackground
 �����   GridLinesVisibility$ Vertical=�5         VerticalGridLinesBrush
 �����	   HorizontalGridLinesBrush
	 �����5      �� 5   
   $ 
Horizontal=�6   $��2��6.   $��10q�6;   .+�5       �� -   5        
 ��Name$
 AddQuestionButton��5       $��Add Question��60   $��0,0,10,0q�5!   5   
�������
�������5#      �� 5$      -   5        $
 SaveChangesButton��5$      $��Save Changes��60   
����� �
�������5'      5(      � 5*   
   -   5         �Name$ LoadingProgressBar��5*      $��2��62   $��20��5+      $y�	Collapsed=�6"   $��Center=�5,      $��10q�61   
�������
�������5.      5/      50      