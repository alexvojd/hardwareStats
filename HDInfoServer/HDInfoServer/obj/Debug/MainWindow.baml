   M S B A M L   `   `   `  ����G  CNikitaServer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:NikitaServerNikitaServer  5   	       HDInfoServer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:NikitaServer     5   	     � Title$  NikitaProduction��5   	   $	��450��6"   $	��700��6/   .��5	      � $��0,0,2,0q�6    � RowDefinitions 5
   
   �� 5      $
��102* �6   �� 5      $
��317* �6    � ColumnDefinitions 5   
   �� 5      $	��77* �6   �� 5      $
��265* �6   �� 5      $
��348* �6   .+�5   
   �� -   5        $��ManufactureListView��5      $��10,30,10,10q�6.   $��2��6C   $��3��6T   5      �� 5   
   -   5        $��ComboDataBox��5      $
��Left=�6K   $��24��6f   $��	171,4,0,0q�6r   $	��Top=�6�   $	��167��6�    J� RenderTransformOrigin$ -0.027,0.055&�6�   $��2��6�   .@�5      �� -   5        $��Win32_Processor��5      Процессор6:   �� 5      -   5        $��Win32_VideoController��5      Видеокарта6A   �� 5      -   5        $��Win32_PhysicalMemory��5      %#Оперативная память6H   �� 5      -   5        $��Win32_DiskDrive��5      Жесткий диск6=   �� 5      -   5        $��Win32_BaseBoard��5      #!Материнская плата6B   �� 5      -   5        $'��!Win32_NetworkAdapterConfiguration��5      Сетевой адаптер6R   �� 5      -	   5        $��
Win32_BIOS��5      BIOS60   5       �� 5!   
   -
   5        $'��!История изменений��5!      $
��Left=�6-   $��73,2,0,0q�6H   $	��Top=�6Z   $	��134��6r   $��24��6~   $��1��6�   �� 5"   
   -   5        $��CompNameLabel��5"      $y�Hidden=�6%   $
��Comp��69   $��2��6H   $
��Left=�6X   $��61,1,0,0q�6s   $	��Top=�6�   $ 2.763,-0.462&�6�   $��52��6�   �� 5#   
   -   5         ��Name$ CompRoomLabel��5#      $y�Hidden=�6'   $
��Room��6;   $��1��6J   $
��Left=�6Z   $��	252,2,0,0q�6u   $	��Top=�6�   $ 2.763,-0.462&�6�   $��52��6�   $��2��6�   �� 5$   
   -   5        $��
Назад��5$      $
��Left=�6!   $��10,2,0,0q�6<   $	��Top=�6N   $��79��6f   $��24��6q   $��2��6�   5%      5&      