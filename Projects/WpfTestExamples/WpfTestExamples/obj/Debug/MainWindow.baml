   M S B A M L   `   `   `  ����  WpfTestExamples     WpfTestExamples.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5      � $��0,32,0,0q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5
      $��* �6   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � 	Resources 5   
    �� 
TargetType �� Property �� Value��%�   '	�       '�� o     �� 5      " 	�6   .�5      ��  � ��$	 0,2q�6+   �� 5       � ��$
 Left=�68   5      �� 5      " ��6   .�5      ��  � ��$ 5q�6+   �� 5       � ��$ Center=�66   5      5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5!      �� -   5         ��Name$ lstBox��5!      �� 5#      $
��20,0q�6   .+�5$      	� -   5         	�Name$ 	rbHeader1��5$      	 d� 	IsChecked$
	 TrueY�61   $	��RB1��6B   	� 5%      -   5        $ 	rbHeader2��5%      $	��RB2��61   	� 5&      -   5        $ 	rbHeader3��5&      $	��RB3��61   	� 5'      -   5        $ 	rbHeader4��5'      $	��RB4��61   �� 5(      $ 
Horizontal=�6   .+�5)      �� -   5        
 ��Name$
 btnStart��5)      $��Start��6/   $��0,10,0,0q�6?   �� 5*      -   5        $
 	btnExport��5*      $��Export��60   5+      5,      &   System.Windows.Controls.DataGrid  5.      -   5          Name$	 DGV��5.      $	��637��6$   $
��Bold"�60      AlternatingRowBackground
 ����� �� AlternationCount$ 2��5/   4      RowBackground �	#FFC6C6C6   CanUserSortColumns .     CanUserResizeColumns .     CanUserReorderColumns .     MinColumnWidth$ 0Q�51         
IsReadOnly .    Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$  ��6)   5  /System.Windows.Controls.DataGridHyperlinkColumn  54      $	 URL��6.      Width5  /System.Windows.Controls.DataGridLengthConverter$	 295 6;     55      $ Header 1��6)   $ 80 6;     56      $ Header 2��6)   $ 80 6;     57      $ Header 3��6)   $ 80 6;   59      5;      �� 5D   
   ��5E      �� 5F       � MappingMode$ RelativeToBoundingBox=�6&    �� 
StartPoint$ 0.5,0&�6J    �� EndPoint$ 0.5,1&�6]   .��5G      �  � Color$ 	#FF313130��6#   � 5H       � Offset$
 0.31Q�6#   $ 	#FFD8D8CF��61   � 5I      $ 	#FF757672��6#   � 5J      $ 0.203Q�6#   $ 	#FFD8D8CF��62   � 5K      $ 0.547Q�6#   $ 	#FFBABAAF��62   � 5L      $ White��6#   5M      5O      � 5S   
   $��3��6   $��28��6   $��5q�6(    � ColumnDefinitions 5T      �� 5U      $
��Auto �6#   �� 5V      $
��Auto �6#   �� 5W      $
��Auto �6#   �� 5X      $
��Auto �6#   �� 5Y      $
��Auto �6#   �� 5Z      $
��Auto �6#   �� 5[      $��* �6#   .+�5_      �� $ 
Horizontal=�6   .+�5`      �� -	   5         ��Name$ label1��5`      $��Find:��5a      �� 5b      -
   5         ��Name$ txtSearchTerm��5b      $	��8,0q�5c      $	��130��6   �� 5d      -   5        $
 btnFind��5d      $��60��5e      $��	Find Next��5f      �� 5g      -   5        $
 btnFindPrevious��5g      $	��100��5h      $
��10,0q�6   $��Find Previous��5i      5j      �� 5l      -   5         ��Name$ chkMatchCase��5l      $��1��5m      $��
Match Case��5n      �� 5p      -   5        $ chkWholeWord��5p      $��2��5q      $��
Whole Word��5r      �� 5t      -   5        $ chkSearchBackwards��5t      $��3��5u      $��Search Backwards��5v      �� 5x      -   5        $ chkWrapSearch��5x      $��4��5y      $
��Wrap��5z      �� 5|      -   5        $ chkHiLitAll��5|      $��5��5}      $��HiLite All Occurrences��5~      �� 5�      $��6��6   $ 
Horizontal=�6)   .+�5�      �� -   5        $ lblPrevious��5�      $��Previous��61     � Cursor$
  Hand��6A   �� 5�      -   5        $ cbGood��5�      $
��Good��6+   $��Bottom=�6:   �� 5�      -   5        $ 	cbNotsure��5�      $��Not sure��6.   $��Bottom=�6A   �� 5�      -   5        $ cbBad��5�      $	��Bad��6*   $��Bottom=�68   �� 5�      -   5        $ lblNext��5�      $
��Next��6-   $
  Hand��69   5�      5�      �� 5�   
   $��4��6   $ 
Horizontal=�6"   .+�5�      �� -   5        $ lblStatusText��5�      $��5q�5�      ��5�      �� *CurrentBrowser.StatusText+! �� FallbackValue$! Status Text��5�      �� 5�      -   5        $ lblSecurityStatus��5�      5�      5�      5�      