   M S B A M L   `   `   `  ���� F  BArchivarius, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Archivarius.PagesArchivarius.Pages  #    Archivarius.Pages.AddCasePage   c _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:Archivarius.Pages       N� Title$  AddCasePage��.��� .+���  �� Orientation$ Vertical=�$��Center=�$	��Top=�.+��� $ 
Horizontal=�$
��Left=�$	��Top=� � Cursor$  ��.+��� $ Vertical=�$��5q�.+��� -    ��Name$ JudgeComboBox��$	��150�� �� DisplayMemberPath$ WorkerFullName��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Судья��   HintOpacity$	 .26Q� �� 
IsEditable . $��
20,20,20,0q� �� SelectedItem �� *Worker+�� -   $ CategoryComboBox��$
 Name��$ Вид дела��$	 .26Q� . $��
20,20,20,0q� �� *
Category+�� .+��� -   $ ArticleComboBox��$	��150��$ Description��$0 *Статья (не обязательно)��$	 .26Q� . $��
20,20,20,0q�(  "System.Windows.Controls.DatePicker  $	��150��$��
20,20,20,0q�.  (MaterialDesignThemes.Wpf.TextFieldAssist	   HasClearButton	 . $ Дата открытия��
   SelectedDate
 �� *Date+�� -    ��Name$ DescriptionTextBox��$��
60,25,45,0q�$	��100��$	��Top=�$. (Краткое описание дело�� �� 	MaxLength$ 40�� !  MaterialDesignOutlinedTextBox#��[   �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=����� *Description+!   CharacterCounterVisibility ��  �� Path$ 	IsChecked� �� ElementName$: 4MaterialDesignOutlinedPasswordFieldTextCountComboBox��   BooleanToVisibilityConverter �� 	Converter# [ �� -    ��Name$ 
SaveButton��$��30��+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15�����#005691$	��109�� " MaterialDesignRaisedDarkButton#��[  � ToolTip$0 *Нажмите перехода далее��$��5q�{��� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.���� $��
Далее��