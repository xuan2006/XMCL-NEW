   M S B A M L   `   `   `  ����?  ;XMCL, Version=2.4.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:XMCLNXMCLN  5   	       XMCLN.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:XMCLN     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � WindowStyle$
  None=�5	   	    � 
ResizeMode$ CanMinimize=�5
   	    � AllowsTransparency .  � Title$ 
MainWindow��5   	   $	��450��6   $	��800��6)   ��5      �� 5   
    �� ImageSource$6 0pack://siteoforigin:,,,/Resources/BackGround.png��6   .��5      � .+�5   
   ��    MaterialDesignGroupBox#���   6   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�5      $��2q�6E   .��5       � -   5          �Name$ Frame��5      $�� ��6#     � NavigationUIVisibility$ Hidden=�6.   $��Stretch=�6N   $��0,0,0,0q�6j   ��5      �� 5      $
��XMCL��6   
�������$��20,0,2,0q�6;    � ToolTip 5      �� 5      $��Hello��6!   5   +   5      (  "MaterialDesignThemes.Wpf.ColorZone  5   
   	   Mode$	 
PrimaryMid=�6#   $��261,0,267,0q�65   $��33��6J   .��5      �� 
 �� Orientation$
 
Horizontal=�6   $��2,4,0,0q�65   .+�5      	� -   5           MaterialDesignTabRadioButton#��[ 5   !   $��4,0,4,3q�6Y    d� 	IsChecked$
 TrueY�6l   $��主页��5      $
��Auto��6   $��13(�6"   
�������6D   	� 5      -   5        #��[ 5       $��4,0,4,3q�6X   $ FalseY�6l   $��游戏管理��5       $
��Auto��6   
�������$��13(�68   6F   	� 5!      -   5        #��[ 5!   !   $��4,0,4,3q�6[   $ FalseY�6n   $��设置��5"      $
��Auto��6   
�������$��13(�66   6D   5#      5$      �� 5%   
   -   5         ! MaterialDesignFlatMidBgButton#���  5%      $0 *MaterialDesignFloatingActionMiniDarkButton��6I   $��0,4,4,0q�6~   $��Right=�6�   $	��Top=�6�   $��48��6�   $��25��6�   
�������.��5&      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowClose=�5'      $��18��5(      $��18��5)      5+      �� 5,   
   -   5        #���  5,      $0 *MaterialDesignFloatingActionMiniDarkButton��6I   $��0,4,57,0q�6~   $��Right=�6�   $	��Top=�6�   $��48��6�   $��25��6�   
�������.��5-        $ WindowMinimize=�5.      $��18��5/      $��18��50      52      #  MaterialDesignThemes.Wpf.Chip  53   
   -   5        $��538,2,0,419q�53      
�������
�������$
��Auto��6Y   .��54      �� $
 
Horizontal=�6   .+�55      �� -	   5         ��Name$ Label_Name1��55      ���	#FF2196F3.��6D   Steve6K   � 56      -
   5         �Name$
 Load��56       % !MaterialDesignCircularProgressBar#��[ 57       � Value$ 0Q�58       � IsIndeterminate . 59      5:      5;      #  MaterialDesignThemes.Wpf.Card  5<   
   -   5          Name$ 
Card_Login��5<      $��538,36,62,314q�62   $	��100��6I   $	��200��6V   .��5=      � .+�5>      �� -   5         ��Name$
 head��5>      $
��Left=�6&    �� BitmapScalingMode$ NearestNeighbor=�6A    �� ClearTypeHint$ Enabled=�6s   $��42��6�   $��	10,10,0,0q�6�   $	��Top=�6�   $��42��6�   $1��+pack://siteoforigin:,,,/Resources/steve.png��6�   �� 5?      -   5        $ Label_Name2��5?      $��Steve��6-   $
��Left=�6=   $��	57,10,0,0q�6X   $	��Top=�6k   $	��133��6�   �� 5@      -   5        $ Label_Logined��5@      $��离线登录��6/   $
��Left=�6>   $��	57,29,0,0q�6Y   $	��Top=�6l   $	��133��6�   �� 5A      $��欢迎回来��6   $
��Left=�6'   $��	10,57,0,0q�6B   $	��Top=�6U   �� 5B      $��管理��6   $
��Left=�6&   $��
112,64,0,0q�6A   $	��Top=�6U   $��78��6m   $��26��6x   5C      5D      5E      5F      