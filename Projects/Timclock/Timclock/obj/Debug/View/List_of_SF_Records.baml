   M S B A M L   `   `   `  ����  Timclock&     Timclock.View.List_of_SF_Records   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Salesforce Records��5   	   $	��600��6$   $	��800��61    � 	Resources 5       �� Source�� 5   
   $* $/Souce/Styles/ShinyCostemcolor1.xaml?�6   %    .��5      �  � RowDefinitions 5	   
   �� 5
      $��* �6   6)   �� 5      $��* �6   6)   .+�5   
   �� -   5        $��ListView��5       $��0��6   $��Stretch=�60   $
��Auto��5      $��Stretch=�6    $
��Auto��6E   ��6R   �� *	persons+ �� View 5      �� 5       �� AllowsColumnReorder .  �� ColumnHeaderToolTip$ Persons��66   .P�5      �� $��RF Id��6%    �� Width$
 Auto��64    �� DisplayMemberBinding 6A   �� 	 �� Path$	 RF_ID__c��� 5      $��
First Name��6%   $
 auto��69    6F   �� $	 HRMSUS__First_Name__c��� 5      $
��Flag��6%   $
 auto��63    6@   �� $	 IsSync�5      5      �� 5   
   -   5        $��	ListView1��5       $��1��6   $��Stretch=�61   $
��Auto��5      $��Stretch=�6    $
��Auto��6E   ��6R   �� *dailyShifts+ 5      �� 5       . $ Login Details��66   .P�5      �� $��Associate ID��6%   $
 Auto��6;    6H   �� $	 Associate__c��� 5      $��Punch In��6%   $
 auto��67    6D   �� $	 Punch_In__c��� 5       $��	Punch Out��6%   $
 auto��68    6E   �� $	 Punch_Out__c��� 5!      $
��Date��6%   $
 auto��63    6@   �� $	 Date__c�5"      5$      5%      5&      