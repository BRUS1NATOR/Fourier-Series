   M S B A M L   `   `   `  ����H  DFourierSeries, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:FourierSeriesFourierSeries  5   	       FourierSeries.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:FourierSeries     5   	   R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5   	     � Title$  Fourier��5	   	   $	��580��6   $	��800��6&    � DataContext 5      !   FourierSeries.MainViewModel  5   
   6    .��5      � .+�5   
   �� $��n=��6   $��40��6   $	��Top=�6(   $��Right=�6@   $��0,120,213,0q�6\   $��18(�6q   6�   �� 5   
   -   5        $��textBoxN��5      $��Right=�6"   $��0,125,173,0q�6?    �� TextWrapping$
 Wrap=�6T   $��6��6h   $	��Top=�6q   $��40��6�   $��18(�6�   �� 5   
   $��a=��6   $��40��6   $	��Top=�6(   $��Right=�6@   $��0,159,213,0q�6\   $��18(�6q   �� 5   
   -   5        $��textBoxA��5      $��Right=�6"   $��0,163,173,0q�6?   $
 Wrap=�6T   $��-5��6h   $	��Top=�6r   $��40��6�   $��18(�6�   �� 5   
   $��b=��6   $��40��6   $	��Top=�6(   $��Right=�6@   $��0,159,116,0q�6\   $��18(�6q   �� 5   
   -   5        $��textBoxB��5      $��Right=�6"   $��
0,163,76,0q�6?   $
 Wrap=�6S   $��5��6g   $	��Top=�6p   $��40��6�   $��18(�6�   �� 5   
   -   5        $��Ряд Фурье��5      $��Right=�6%   $��	0,40,20,0q�6A   $	��Top=�6T   $	��233��6l   $��30��6�   $��14(�6�   �� 5   
   -   5        $��textBox3��5      $��Right=�6"   $��30��6>   $��	0,80,20,0q�6J   $
 Wrap=�6]   $	��x+1��6q   $	��Top=�6|   $	��233��6�   $��18(�6�   �� 5   
   -   5        $��labelResult��5      $��Right=�6#   $	��150��6?   $��
0,350,20,0q�6L   $	��Top=�6`   $	��238��6x   � 5   
   $	��512��6   $	��512��6   $��
0,0,270,40q�6(   .+�5        OxyPlot.Wpf.PlotView     Model 6   �� *	MyModel+67   5       5"      5#      