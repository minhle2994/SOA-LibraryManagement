   M S B A M L   `   `   `  ����V  RMaterialDesignThemes.Wpf, Version=1.0.0.2444, Culture=neutral, PublicKeyToken=nulleHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf  5      P LSOA-LibraryManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LibraryManagementLibraryManagement 5      J FMahApps.Metro, Version=1.1.3.157, Culture=neutral, PublicKeyToken=nullfCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.MetroMahApps.Metro.Controls.Dialogs 5          LibraryManagement.EditBook   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      XwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf     5      1localclr-namespace:LibraryManagement     5      WdialogsCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro     5      8  2MahApps.Metro.Controls.Dialogs.DialogParticipation    Register  5
      ��  � 	Resources 5       �� MergedDictionaries �� Source �� 
TargetType   MaterialDesignTextBox �� BasedOn �� Property �� Value  MaterialDesignComboBox  MaterialDesignSlider�� 5   
    5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ComboBox.xaml?�6%   �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Slider.xaml?�6%   �� 5      $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBox.xaml?�6%   %9  '��       7   '�� {     7  '(� �     '�� �    7  �� 5      " ��6   8   .�5      ��  � ��$ Stretch=�68   �� 5       � ��$ 0 8 0 8q�6+   5      �� 5      " ��6   8   .�5      ��  � ��$ Stretch=�68   �� 5       � ��$ 0 8 0 8q�6+   5      �� 5      " (�6   .�5      ��  � ��$ 18��6*   �� 5       � ��$ 18��6+   �� 5        � ��$ 0 0 8 0q�6+   �� 5!       � ��$ Center=�66   5"      �� 5#      " ��6   8   .�5$      ��  � ��$ 0 8 0 8q�6+   5%      5&      .��5(      � -   5        $
��Grid��5(      $��32 16 16 16q�6   $	��Top=�6-    � ColumnDefinitions 5)   
   �� 5*      $	��500 �6   �� 5+      $
��Auto �6   .+�5.   
   � -   5        $��Fields��5.      $��0��6   	 � RowDefinitions	 5/      �� 50      $
��Auto �6    �� 51      $
��Auto �6    �� 52      $
��Auto �6    �� 53      $
��Auto �6    �� 54      $
��Auto �6    �� 55      $
��Auto �6    �� 56      $
��Auto �6    �� 57      $
��Auto �6    �� 58      $
��Auto �6    .+�5;      �� -   5        
 ��Name$
 
CoverImage��5;   #   $��0��6   .   (MaterialDesignThemes.Wpf.TextFieldAssist   Hint$ Cover Image��67    % !MaterialDesignFloatingHintTextBox#��[ 6^   $��0 8 0 8q�5<      �� 5>      -   5        $

 Name��5>   #   $��1��6   $
 Name��61   #��[ 6Q   $��0 8 0 8q�5?      �� 5A      -   5        $
 Description��5A      $��2��6+   $��2��68    �� TextWrapping$
 Wrap=�6I   $��0 8 0 8q�6]   $	��280��5B       �� MaxLines$ 6��5C       �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�5E      $ Description��5F      #��[ 5G      6O   �� 5I      -   5        $
 Author��5I      $��4��6&   $ Author��63   #��[ 6U   $��0 8 0 8q�5J      �� 5L      -   5         ��Name$ Status��5L      $��0 16 0 8q�6'   $��5��69   $	��200��6F   $ Status��6R   $
��Left=�6t   .@�5M      �� .��6   	Available6*   �� 5N      .��6   Not Available6.   5O      (  "System.Windows.Controls.DatePicker  5Q      -   5          Name$
 Date��5Q      $��6��6'   $	��200��64   $
��Left=�6@   $��0 16 0 8q�6[   $ Publish Date��5R      �� 5T      -	   5        $
 	PageCount��5T      $��7��6)   $ 
Page Count��66   #��[ 6\   $��0 8 0 8q�5U      5V      � 5X   
   -
   5        $��ImageAndButton��5X      $��1��6%   	 5Y      �� 5Z      $	��400 �6    �� 5[      $
��Auto �6    .+�5]      �� -   5         ��Name$ BrowseImage��5^        MaterialDesignRaisedButton#���  5]      $��8,12,8,8q�6J   $
��Left=�6\   $��90��5^   @   $��30��6K   $	��Top=�6W   .��5_      ��  �� Orientation$ 
Horizontal=�6   .+�5`      �� $��Center=�6    Browse6C   5a      5b      �� 5d      -   5        $��bookCoverImage��5d      $��0��6`   $	��200��5e      $	��300��6!   $��	80 32 0 0q�5f       �� StretchDirection$
 Both=�5g      $	��Top=�6,   $
��Fill=�6D   ��5d   +   ��  �� ElementName$ 
CoverImage�� �� Path$
 Text�5g   D   �� 5i      $��2��6   $ 
Horizontal=�6&   $��80 0 0 0q�6?   .+�5j      �� -   5        $ 	AddButton��5k      #���  5j      $��8,8,32,8q�6N   $	��100��5n      $��40��6%   $��Bottom=�61   ��5m      �� *ShowProgressDialogCommand+.��5o      �� $ 
Horizontal=�6!   .+�5p      �� $��Center=�6$   Ok6C   5q      5r      �� 5s      -   5        $ CancelButton��5t      #���  5s      $��32,8,8,8q�6O   $	��100��5t   D   $��40��6P   $��Bottom=�6\   .��5u      �� $ 
Horizontal=�6!   .+�5v      �� $��Center=�6$   Cancel6G   5w      5x      5y      5z      5{      5|      