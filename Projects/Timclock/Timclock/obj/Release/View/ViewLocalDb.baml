   M S B A M L   `   `   `  ����   Timclock    Timclock.View.ViewLocalDb   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  ViewLocalDB��$	��600��$	��800�� � 	Resources  �� Source�� $, &../Souce/Styles/ShinyCostemcolor1.xaml?�%    .���  � ColumnDefinitions �� �� $
��Auto ��� $��4* �.+�R� -    R�Name$ TreeView��$��5q�$��0��$��0��.@�Q� -    Q�Name$ TreeViewItem��$��Tables�� Q� 
IsExpanded . ���� *treeViewItems+���� .R��� ���� �� $��0��$��1��
�������$��5��$��Stretch=�$��Stretch=�� $��5q�$��2��$��2��.+��� -   $��ListNone�� �� AlternationCount$ 2�� �� View �� 	 �� ColumnHeaderTemplate	 �� .R��� $
��Bold"�$��5q����� .P��� �� -   $��
ListPerson��$ 2��$y�Hidden=����� *localPersons+ �� 	 �� .R��� $
��Bold"�$��5q����� .P��� $
��RFId��
 �� Width$

 Auto�� �� DisplayMemberBinding ��  �� Path$
 RFId��� $��	FirstName��$

 Auto�� �� $ 	FirstName��� $��IsSync��$

 Auto�� �� $ IsSync��� -   $��localDailyShift��$ 2��$y�Hidden=����� *localDailyShifts+ �� 	 �� .R��� $
��Bold"�$��5q����� .P��� $��Worker��$

 Auto�� �� $ Associate__c��� $��Punch In��$

 Auto�� �� $ Punch_In__c��� $��	Punch Out��$

 Auto�� �� $ Punch_Out__c��� $
��Date��$

 Auto�� �� $ Date__c��� $��IsSync��$

 Auto�� �� $ IsSync�