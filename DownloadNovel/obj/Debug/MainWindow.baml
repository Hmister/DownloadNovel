   M S B A M L   `   `   `  ����H  DDownloadNovel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DownloadNovelDownloadNovel  5   	   G CHandyControl, Version=2.5.0.1, Culture=neutral, PublicKeyToken=nullS9clr-namespace:HandyControl.Controls;assembly=HandyControlHandyControl.Controls 5   	       DownloadNovel.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:DownloadNovel     5   	   0hc'https://handyorg.github.io/handycontrol  5   	   Hcontrols9clr-namespace:HandyControl.Controls;assembly=HandyControl  5   	   -   5          � Title$  DownloadNovel��5
   	   $	��500��6   $	��850��6,    � 
ResizeMode$ CanMinimize=�68   .��5      � .+�5   
   �� $��17,10,16,341q�6   .+�5      %  HandyControl.Controls.SearchBar  -   5          Name$ SName��5   !   '  !HandyControl.Controls.InfoElement   Placeholder$- '请输入书名或者作者进行搜索��60   #  HandyControl.Controls.TextBox   ShowClearButton .    SearchBarPlus#��[  6y   $��
0,20,409,0q�6�   6�   5      A� 5   
    A� Rows$ 3��6    A� Columns$ 4��6   $��480,5,0,388q�6+   $
��Left=�6@   $	��296��6[   .+�5      &   HandyControl.Controls.ImageBlock     Source$, &/DownloadNovel;component/Img/Dance.png��6      Interval$ 	0:0:0.125h�6L   	   Columns$	 8��6a   
   Rows$
 10��6m      StartColumn$ 0��6w      StartRow$ 5��6�      	EndColumn$ 7��6�      EndRow$ 5��6�      	IsPlaying . $��	0,0,5,-55q�6�     5      $, &/DownloadNovel;component/Img/Dance.png��6   $ 	0:0:0.125h�6L   $	 8��6a   $
 10��6m   $ 0��6w   $ 7��6�   $ 7��6�   $ 7��6�    . $��	0,0,5,-55q�6�     5      $, &/DownloadNovel;component/Img/Dance.png��6   $ 	0:0:0.125h�6L   $	 8��6a   $
 10��6m   $ 0��6w   $ 1��6�   $ 7��6�   $ 1��6�    . $��	0,0,5,-55q�6�     5      $, &/DownloadNovel;component/Img/Dance.png��6   $ 	0:0:0.125h�6L   $	 8��6a   $
 10��6m   $ 0��6w   $ 0��6�   $ 7��6�   $ 0��6�    . $��	0,0,5,-55q�6�   5      �� 5   
     TabControlInLine#��[ 6   $��0,83,0,0q�6?   .@�5      �� $��搜索结果��6   .��5      &   System.Windows.Controls.DataGrid  -   5        $��NovelListData��5   c      HeadersVisibility$	 All=�6      RowHeaderWidth$ 60Q�63      AutoGenerateColumns .  *  $HandyControl.Controls.DataGridAttach   ShowRowNumber . ��6x   �� *
DataList+   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$ 60	 61      CanUserResize .     CellTemplate 5       �� 5!   "   .R�5"   &   �� $��40��6E   $��40��6P   $��Uniform=�6\   ��6,   �� *Cover+6\   5#   #   5%      0
  *System.Windows.Controls.DataGridTextColumn
  5&         
IsReadOnly . $	 120	 6?    .     Header$ 	小说名��6z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6a   �� *Name+6z   
  5'      $ 作者��6H    6-   �� *Author+6H   
  5(      $	 170	 6-    .  $ 最新章节��6p    6P   �� *LastChapter+6p   
  5)      $ 80	 6.    .  $ 字数��6j    6O   �� *Number+6j   
  5*      $	 100	 6.    .  $ 更新时间��6o    6P   �� *
UpdateTime+6o   
  5+      $ 状态��6H    6-   �� *Status+6H     5,      $ 80	 61    .  $ 操作��6S    5-      �� 5.   "   .R�50   &   �� -   5        $��详情��50   -   $��5q�6:     ButtonPrimary#��[ 6E   6l   51   #   53      55      56      57      �� 5<   
   $��Hidden=�6   $��Right=�6<   $	��355��6X   $��
0,10,0,316q�6d   .��5=      �� $	��Top=�6   $��
0,10,10,10q�61   !  HandyControl.Controls.Growl   Token$ 
SuccessMsg��6E   6j   5>      5?      5@      