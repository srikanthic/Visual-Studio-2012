   M S B A M L   `   `   `  ����   WpfApplication3!    WpfApplication3.ViewLocalDb   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  ViewLocalDB��$	��600��$	��800�� � 	Resources  �� Source�� $  Souce/Styles/ShinyRed.xaml?�%    .���  � ColumnDefinitions �� �� $
��Auto ��� $��2* �.+�R� -    R�Name$ TreeView��$��5q�$��0��$��0��.@�Q� -    Q�Name$ TreeViewItem��$��Tables�� Q� 
IsExpanded . ���� *treeViewItems+���� .R��� ���� �� $��0��$��1��
�������$��5��$��Stretch=�$��Stretch=�� $��5q�$��2��$��2��.+��� -   $��ListNone�� �� AlternationCount$ 2�� �� View �� 	 �� ColumnHeaderTemplate	 �� .R��� $
��Bold"�$��5q����� .P��� �� -   $��ListAccount��$ 2��$y�Hidden=����� *localAccounts+ �� 	 �� .R��� $
��Bold"�$��5q����� .P��� $
��Name��
 �� Width$

 Auto�� �� DisplayMemberBinding ��  �� Path$
 Name��� $��Phone��$

 Auto�� �� $ Phone��� $��SF_Id��$

 Auto�� �� $ SF_Id��� $��Description��$

 Auto�� �� $ Description��� -   $��ListContact��$ 2��$y�Hidden=����� *localContacts+ �� 	 �� .R��� $
��Bold"�$��5q����� .P��� $
��Name��$

 Auto�� �� CellTemplate �� .R��� ��`�  �� StringFormat$ {0} {1} {2}��.1��� $ 
Salutation��� $ 	FirstName��� $ LastName��� $��Phone��$

 Auto�� �� $ Phone��� $��SF_Id��$

 Auto�� �� $ SF_Id��� $��Description��$

 Auto�� �� $ Description�