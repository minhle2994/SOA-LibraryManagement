   M S B A M L   `   `   `  ���� W  SMaterialDesignThemes.Wpf, Version=1.0.0.17895, Culture=neutral, PublicKeyToken=nulleHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf  J FDemoMaterialWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DemoMaterialWPFDemoMaterialWPF    DemoMaterialWPF.EditBook   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     XwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf     /localclr-namespace:DemoMaterialWPF       � 	Resources   �� MergedDictionaries �� Source �� 
TargetType   MaterialDesignTextBox �� BasedOn �� Property �� Value  MaterialDesignComboBox  MaterialDesignSlider��  �� $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ComboBox.xaml?��� $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Slider.xaml?��� $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBox.xaml?�%_  '��       7   '�� H     7  '(� �     '�� �     7  �� " ��8   .���  � ��$ Stretch=���  � ��$ 0 8 0 8q��� " ��8   .���  � ��$ Stretch=���  � ��$ 0 8 0 8q��� " (�.���  � ��$ 18����  � ��$ 18����  � ��$ 0 0 8 0q���  � ��$ Center=��� " ��8   .���  � ��$ 0 8 0 8q�.��� -   $
��Grid��$��32 16 16 16q�$	��Top=� � ColumnDefinitions �� $	��500 ��� $
��Auto �.+�� -   $��Fields��$��0�� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   	 ��Name$	 
CoverImage��$��0��.   (MaterialDesignThemes.Wpf.TextFieldAssist
   Hint$
 Cover Image�� % !MaterialDesignFloatingHintTextBox#��[ $��0 8 0 8q��� -   $
	 Name��$��1��$

 Name��#��[ $��0 8 0 8q��� -   $	 Description��$��2��$��2�� �� TextWrapping$
 Wrap=�$��0 8 0 8q�$	��280�� �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�$
 Description��#��[ �� -   $	 Author��$��4��$
 Author��#��[ $��0 8 0 8q��� -    ��Name$ Status��$��0 16 0 8q�$��5��$	��200��$
 Status��$
��Left=�.@��� .��	Available�� .��Not Available(  "System.Windows.Controls.DatePicker  -     Name$
 Date��$��6��$	��200��$
��Left=�$��0 16 0 8q�$
 Publish Date���� -	   $	 	PageCount��$��7��$
 
Page Count��#��[ $��0 8 0 8q�� -
   $��ImageAndButton��$��1�� �� $	��400 ��� $
��Auto �.+��� -    ��Name$ BrowseImage��  MaterialDesignRaisedButton#���  $��8,12,8,8q�$
��Left=�$��90��$��30��$	��Top=�.����  �� Orientation$ 
Horizontal=�.+��� $��Center=�Browse�� -   $��bookCoverImage��$��0��$	��200��$	��300��$��	80 32 0 0q� �� StretchDirection$
 Both=�$	��Top=�$
��Fill=�����  �� ElementName$ 
CoverImage�� �� Path$
 Text��� $��2��$ 
Horizontal=�$��80 0 0 0q�.+��� -   $ 	AddButton��#���  $��8,8,32,8q�$	��100��$��40��$��Bottom=�.���� $ 
Horizontal=�.+��� $��Center=�Ok�� -   $ CancelButton��#���  $��32,8,8,8q�$	��100��$��40��$��Bottom=�.���� $ 
Horizontal=�.+��� $��Center=�Cancel