   M S B A M L   `   `   `  ����F  BArchivarius, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Archivarius.PagesArchivarius.Pages  5      #    Archivarius.Pages.AddCasePage   5      c _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Archivarius.Pages     5        N� Title$  AddCasePage��5
      .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   $��Center=�6,   $	��Top=�6I   .+�5      �� $ 
Horizontal=�6   $
��Left=�66   $	��Top=�6Q    � Cursor$  ��6i   .+�5      �� $ Vertical=�6!   $��5q�68   .+�5      �� -   5         ��Name$ JudgeComboBox��5      $	��150��5       �� DisplayMemberPath$ WorkerFullName��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Судья��5         HintOpacity$	 .26Q�5       �� 
IsEditable . $��
20,20,20,0q�5       �� SelectedItem 5      �� *Worker+5      �� 5      -   5        $ CategoryComboBox��5      $
 Name��5      $ Вид дела��5      $	 .26Q�5       . $��
20,20,20,0q�5!       5      �� *
Category+5"      5#      �� 5$      .+�5%      �� -   5        $ ArticleComboBox��5&      $	��150��5'      $ Description��5(      $0 *Статья (не обязательно)��5)      $	 .26Q�5*       . $��
20,20,20,0q�5,      5-      (  "System.Windows.Controls.DatePicker  5.      -   5        	  Name$	 DateBox��5/      $	��150��50      $��
20,20,20,0q�51      .  (MaterialDesignThemes.Wpf.TextFieldAssist
   HasClearButton
 . $ Дата открытия��54         SelectedDate 52      �� *Date+54      55      56      �� 57      -   5         ��Name$ DescriptionTextBox��58      $��
60,25,45,0q�5:      $	��100��5;      $	��Top=�5<      $. (Краткое описание дело��5=       �� 	MaxLength$ 40��5?       !  MaterialDesignOutlinedTextBox#��[  5@       �� TextWrapping$
 Wrap=�5A      " �� VerticalScrollBarVisibility$
 Auto=�5B      ��59      �� *Description+!   CharacterCounterVisibility 5>      ��  �� Path$ 	IsChecked� �� ElementName$: 4MaterialDesignOutlinedPasswordFieldTextCountComboBox��   BooleanToVisibilityConverter �� 	Converter# [ 5B      �� 5C      -   5         ��Name$ 
SaveButton��5D      $��30��5E      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��5F      ���#005691$	��109��5H       " MaterialDesignRaisedDarkButton#��[ 5J       � ToolTip$0 *Нажмите перехода далее��5K      $��5q�5L   /   {�5I      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��5M      �� $��
Далее��6   5N      5O      5P      5Q      