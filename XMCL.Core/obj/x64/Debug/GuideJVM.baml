   M S B A M L   `   `   `  ����D  @XMCL.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:XMCL.Core	XMCL.Core  5   	       XMCL.Core.GuideJVM   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:XMCL.Core     5   	     � Title$  JVM参数创建向导��5   	   $	��416��6   $	��380��6(   .��5	      � ���	#FF1E1E1E.+�5
   
   �� $��选择参数��6   $
��Left=�6   $��	10,10,0,0q�6:   $	��Top=�6M   
�������$��16(�6�   $��Microsoft YaHei Light)�6�   ��6x   Z� 6�   �� 5   
   -   5         ��Name$	 T12��5      $��-XX:G1HeapRegionSize=16M��6    $
��Left=�6C   $��
16,323,0,0q�6^   $	��Top=�6r   
�������$��Microsoft YaHei Light)�6�   �� 5   
   -   5        $	 T11��5      $��-XX:MaxGCPauseMillis=50��6    $
��Left=�6B   $��
16,303,0,0q�6]   $	��Top=�6q   
�������$��Microsoft YaHei Light)�6�   �� 5   
   -   5        $	 T10��5      $��-XX:G1ReservePercent=20��6    $
��Left=�6B   $��
16,283,0,0q�6]   $	��Top=�6q   
�������$��Microsoft YaHei Light)�6�   �� 5   
   -   5        $ T9��5      $��-XX:G1NewSizePercent=20��6   $
��Left=�6A   $��
16,263,0,0q�6\   $	��Top=�6p   
�������$��Microsoft YaHei Light)�6�   �� 5   
   -   5        $ T8��5      $)��#-Dfml.ignorePatchDiscrepancies=true��6   $
��Left=�6M   $��
16,243,0,0q�6h   $	��Top=�6|   
�������$��Microsoft YaHei Light)�6�   �� 5   
   -   5        $ T7��5      $3��--Dfml.ignoreInvalidMinecraftCertificates=true��6   $
��Left=�6W   $��
16,223,0,0q�6r   $	��Top=�6�   
�������$��Microsoft YaHei Light)�6�   �� 5   
   -   5        $ T6��5      $&�� -XX:+UnlockExperimentalVMOptions��6   $
��Left=�6J   $��
16,203,0,0q�6e   $	��Top=�6y   
�������$��Microsoft YaHei Light)�6�   �� 5   
   -   5        $ T5��5      $_��Y-XX:HeapDumpPath=MojangTricksIntelDriversForPerformanc
e_javaw.exe_minecraft.exe.heapdump��6   $
��Left=�6�   $��
16,165,0,0q�6�   $	��Top=�6�   
�������$��Microsoft YaHei Light)�6�   $��38��6  $	��346��6  �� 5   
   -	   5        $ T4��5      $$��-XX:-OmitStackTraceInFastThrow��6   $
��Left=�6H   $��
16,126,0,0q�6c   $	��Top=�6w   
�������$��Microsoft YaHei Light)�6�   �� 5   
   -
   5        $ T3��5      $ ��-XX:-UseAdaptiveSizePolicy��6   $
��Left=�6D   $��	16,89,0,0q�6_   $	��Top=�6r   
�������$��Microsoft YaHei Light)�6�   �� 5   
   -   5        $ T2��5      $��-XX:+UseG1GC��6   $
��Left=�66   $��	16,69,0,0q�6Q   $	��Top=�6d   
�������$��Microsoft YaHei Light)�6�   �� 5   
   -   5        $ T1��5      $��-Xmn128m��6   $
��Left=�62   $��	16,49,0,0q�6M   $	��Top=�6`   
�������$��Microsoft YaHei Light)�6�   �� 5   
   $ ��新生代堆大小为128MB��6   $
��Left=�6'   $��24��6B   $��
100,45,0,0q�6N   $	��Top=�6b   
�������$��Calibri Light)�6�   ��6�   Z� 6�   �� 5   
   $��开启G1收集器��6   $
��Left=�6"   $��24��6=   $��
122,65,0,0q�6I   $	��Top=�6]   
�������$��Calibri Light)�6�   ��6�   Z� 6�   �� 5   
   $A��;自动选择年轻代区大小和相应的Survivor区比例��6   $
��Left=�64   $��24��6O   $��
32,104,0,0q�6[   $	��Top=�6o   
�������$��Calibri Light)�6�   ��6�   Z� 6�   �� 5   
   $-��'省略异常栈信息从而快速抛出��6   $
��Left=�6(   $��24��6C   $��
32,141,0,0q�6O   $	��Top=�6c   
�������$��Calibri Light)�6�   ��6�   Z� 6�   �� 5   
   -   5           ButtonStyle1#��[  5      $��完成��67   $
��Left=�6D   $��288,353,0,0q�6_   $	��Top=�6t   $��74��6�   $��22��6�   ���	#FF1E1E1E���	#FF707070
�������6�   5      5      