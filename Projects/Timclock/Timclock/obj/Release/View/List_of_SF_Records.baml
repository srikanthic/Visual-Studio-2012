   M S B A M L   `   `   `  ����   Timclock&     Timclock.View.List_of_SF_Records   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Salesforce Records��$	��600��$	��800�� � 	Resources  �� Source�� $* $/Souce/Styles/ShinyCostemcolor1.xaml?�%    .���  � RowDefinitions �� $��* ��� $��* �.+��� -   $��ListView��$��0��$��Stretch=�$
��Auto��$��Stretch=�$
��Auto������ *	persons+ �� View ��  �� AllowsColumnReorder .  �� ColumnHeaderToolTip$ Persons��.P��� $��RF Id�� �� Width$
 Auto�� �� DisplayMemberBinding �� 	 �� Path$	 RF_ID__c��� $��
First Name��$
 auto�� �� $	 HRMSUS__First_Name__c��� $
��Flag��$
 auto�� �� $	 IsSync��� -   $��	ListView1��$��1��$��Stretch=�$
��Auto��$��Stretch=�$
��Auto������ *dailyShifts+ ��  . $ Login Details��.P��� $��Associate ID��$
 Auto�� �� $	 Associate__c��� $��Punch In��$
 auto�� �� $	 Punch_In__c��� $��	Punch Out��$
 auto�� �� $	 Punch_Out__c��� $
��Date��$
 auto�� �� $	 Date__c�