   M S B A M L   `   `   `  ����E  APhotoAlbom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PhotoAlbom.ViewPhotoAlbom.View  5      G(clr-namespace:PhotoAlbom.View.ConvertersPhotoAlbom.View.Converters  5      ;"clr-namespace:PhotoAlbom.ViewModelPhotoAlbom.ViewModel  5      %    PhotoAlbom.View.SingleImageView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:PhotoAlbom.View     5      ;conver(clr-namespace:PhotoAlbom.View.Converters     5      1vm"clr-namespace:PhotoAlbom.ViewModel     5      
������   � DataContext  5      +   %PhotoAlbom.ViewModel.ViewModelLocator  5   
    � 	Resources 5      8   2PhotoAlbom.View.Converters.BackVisibilityConverter   backVisibleConversation�� 5   
   %   &	          5      6-   5      ��5      �� 5   
    �� 
TargetType" >�6   .�5      ��  �� Property � y� �� Value 6+   �� *PhotoSet.IsVisible+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� 	Converter# [  5      .��5      �   6   �� *PhotoSet.CurrentImage+ � ColumnDefinitions 5   
   �� 5      �� 5      $��0.25* �6   .+�5"   
   �� $��15,30,15,30q�6(   ��6   �� *Path+6(   A� 5#   
   $��1��6   $��Stretch=�5$      $��Stretch=�5%      $��15,30,15,30q�5&      	 A� Columns$	 0��5'      
 A� Rows$
 3��5(      .+�5*      �� 
������ $��Center=�5+      $��Center=�5,      ��5-      �� *parent.PhotoUp+��68   �� ��5.      �� 5/      $"��/Resources/Image/ArrowUp.png��6   51      �� 52      $
��BLUR��6   
��� ���
���  ��$��Center=�55      $��Center=�56      �� 57      
������ $��Center=�58      $��Center=�59      $��Stretch=�5:      $��Stretch=�5;      ��5<      �� *parent.PhotoDown+��6:   �� ��5=      �� 5>      $$��/Resources/Image/arrowDown.png��6   5A      5B      5C      5F      