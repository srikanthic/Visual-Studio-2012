   M S B A M L   `   `   `  ����   Timclock#    Timclock.View.PunchInPunchOut   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$  PunchInPunchOut�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=�
������ $	��400��
������� J� OpacityMask
 �   �$��16(�$
��Bold"� � 	Resources    FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background	 �� Color  Button.Static.Border  Button.Disabled.Foreground  Closebuttenstyle
 �� 
TargetType �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName  Punch BStyle �� Padding3  -System.Windows.Media.Effects.DropShadowEffect��%	  &	        &	 N     &	 c     &	 x     &	 �     7   7  7  7  &	 �    7   7  7  �� .���  � �� �� .R��� $��2q� . #��� ��$��1��$	 1 2R��� $	 	#FFDDDDDD���� $	 	#FF707070���� $	 	#FF838383���� "
 ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z�� . ._��� $ contentPresenter��|�.  #��z��#��z����. # z #��z�� P�  �@��IsDefaulted . . ��� $ border��# � �� � ��P�  �@J�IsMouseOver . . ��� $ border�� �@J�Opacity$	 0.8Q�P�  � �� . P�  � {� .  . ��� $ contentPresenter��8   � ���� "
 ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��# � ����  � ��
 �������  � ��$ 2q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border�� . ���	#FF0C0C0E���	#FF14194B$��1q�$��5q�$ 5q�._��� $ contentPresenter��|�.  #��z����. # z #��z��$��40,10q� P�  �@��IsDefaulted . . ��� $ border��# � �� � ����  Z�  � ����  Z�  � ����  � ��
 �������  � ��$ 0q��� $ border�� �@J�Effect   P�  �@J�IsMouseOver . . ���  Z�  � ����  � ��
 �   ���  � ��$ 0q��� $ border�� � �� �	#FF4B4B4B�� $ border�� � ��$ 2q��� $ border�� �@J�Effect   ��  � ��
 ������� $ border�� � ��
 ������� $ contentPresenter�� � ��$ 40,10q��� $ contentPresenter�� � ��$
 Auto���� $ contentPresenter�� � ��$
 Auto��P�  � �� . . ���  Z�  � ����  Z�  � ����  � �� �	#FFDCCCCC��  � ��$ 0q���  �@J�Effect   �� $ border�� �@J�Effect   P�  � {� .  . ��� $ contentPresenter��8   � ����  Z�  � ����  Z�  � ���� $ border�� Z�  � ���� $ border�� Z�  � ����  � �� �	#FF005281��  � ��$ 0q��� $ border�� �@J�Effect   ��  �@J�Effect    J� Effect      ShadowDepth$ 10Q�   
BlurRadius$ 10Q�.��� ���	#00000000 � ColumnDefinitions �� $	��49* ��� $
��645* ��� $	��66* � � RowDefinitions �� $	��18* ��� $
��491* ��� $	��18* �.+��� $��3��$��3��
���   �����  �� EndPoint$ 0.5,1&� � MappingMode$ RelativeToBoundingBox=� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#87014B4B�� � Offset$ 1Q�� $ 	#FF1CCFCF���� -   $�� ��$��2��$��0��#���  ����  �� ImageSource$ 
wifi_2.png��� $��1��$��1�� �� $
��297* ��� $
��193* �.+�� $��0�� �� $��* ��� $��2* �.+��� $��0��.+��� $
��Wrap=�$��Right=�$��Name :��$��
10,10,10,0q��� $
��Wrap=�$��
Badge ID :��$��Right=�$��
10,10,10,0q��� $��1��.+��� -    ��Name$
 Name��$
��Wrap=�$�� ��$��
10,10,10,0q��� -   $ Badge��$
��Wrap=�$�� ��$��
10,10,10,0q�� $��Bottom=�$��1�� �� $��* ��� $��* �.+��� $��0��$��0,0,0,5q� ��%2   '��       �� "
 ��.���  � ��$ 0,5,0,5q�.+��� -   $��Punch In��#���  �� -   $��Brake In��#���  �� -   $��Lunch In��#���  �� $��1��$��0,0,0,5q� ��%2   '��       �� "
 ��.���  � ��$ 0,5,0,5q�.+��� -   $��	Punch Out��#���  �� -	   $��	Brake Out��#���  �� -
   $��	Lunch Out��#���  