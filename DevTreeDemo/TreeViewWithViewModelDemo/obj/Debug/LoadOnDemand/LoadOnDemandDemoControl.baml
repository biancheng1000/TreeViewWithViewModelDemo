   M S B A M L   `   `   `  ����T  PTreeViewWithViewModelDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:TreeViewWithViewModelDemo.LoadOnDemand&TreeViewWithViewModelDemo.LoadOnDemand  5      D    >TreeViewWithViewModelDemo.LoadOnDemand.LoadOnDemandDemoControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Flocal4clr-namespace:TreeViewWithViewModelDemo.LoadOnDemand     5        � 	Resources  5      B   <TreeViewWithViewModelDemo.LoadOnDemand.ClassTypeValueConvert   ClassConvertC   =TreeViewWithViewModelDemo.LoadOnDemand.PowerLeverValueConvert  levelConvert  BlueLightGradientBrush �� 
StartPoint �� EndPoint � Offset � Color&   System.Windows.Controls.DataGrid �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow��%4  &	        &	      &	 &     '  �     7  '  �      5   
   6&     5	   
   6'   �� 5   
   $	 0,0&�6=   $	 0,1&�6N   .��5      � $ 0Q�6   $ 	#FFEAF3FF��6&   � 5      $ 0.654Q�6   $ 	#FFC0DEFF��6*   � 5      $ 1Q�6   $ 	#FFC0D9FB��6&   5      �� 5   
   "  6   .�5      ��  � ��$ 5q�6'   �� 5       � ��8   6+   �� 5       � �� �	#FFA6CCF26,   �� 5       �@ RowBackground
 �����6.   �� 5        �@ AlternatingRowBackground �#FDFFD069   �� 5        �@ HorizontalGridLinesBrush
 ���� 69   �� 5       �@ VerticalGridLinesBrush �#FFD3D067   �� 5       �@ RowHeaderWidth$ 0Q�6/   5      �� 5   
   "  6   .�5       ��  �@J�	AllowDrop . 6*   5!      5"      .��5#      � $	��742��6    � ColumnDefinitions 5$   
   �� 5%      $	��99* �6   �� 5&      $
��272* �6   .+�5(   
   R� -   5        $
��tree��5(   R   $	��200��63   $	��200��6B   $��0��6^   ��6   �� *	Devices+��5)      �� 5*      " Q�6   .�5+      ��  �@Q�
IsExpanded 63   �� *
IsExpanded+	 �� Mode$	 TwoWay=��� 5,       �@Q�
IsSelected 63   �� *
IsSelected+$	 TwoWay=��� 5-       � ��$ Normal"�63   
 �� Triggers
 5.      P� 5/       P� Property �@Q�
IsSelected P� Value . . �50      ��  � ��$
 Bold"�6;   �� 51       �@�ContextMenu 6<   �� *	PopupMenu+52      54        56       �� DataType@   :TreeViewWithViewModelDemo.LoadOnDemand.DeviceItemViewModel �� ItemsSource �� Orientation��%  (��       58      *, +)�� 57      "  58       59      �� *
Children+.R�5;      �� $ 
Horizontal=�6!   .+�5<      �� $��16��6    $��16��6+   $	��3,0q�67   ��6D   �� *ImageSource+�� 5=      ��6$   �� *	DevName+5>      5?      5@      5A        5B   
   -   5        $
��Grid��5B         AutoGenerateColumns .  $��Stretch=�6\   $��Stretch=�6�   $��1��6�   ��6    �� *	Content+   Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$ 设备名称��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *	DevName+  5E      $ 电压等级��6%    63   �� *
PowerLevel+ �� 	Converter# [   5F      $ 设备类型��6%    63   �� *
DevClassID+# [    5G      $ 线路长度��6%      
Visibility$ 	Collapsed=�6N    63   �� *Lenght+6N     5H      $ 起止杆塔号��6%   $ 	Collapsed=�6W    64   �� *PoleTowerMount+6W     5I      $ 运行单位��6%    63   �� *RunDepartment+  5J      $ 	地区局��6%    62   �� *LocalDepart+  5K      $ 县局或线路工区��6%    66   �� *LineWorkDepart+5M      5N      5O      