   M S B A M L   `   `   `  ����D  @HerbMedic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:HerbMedic.View.MessageBoxesHerbMedic.View.MessageBoxes  5   	   ;    5HerbMedic.View.MessageBoxes.MedicalRecordDoesntExists   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:HerbMedic.View.MessageBoxes     5   	     � WindowStyle$
  None=�5       � WindowStartupLocation$ CenterScreen=�6-    � Title$ MedicalRecordDoesntExists��5   	   $	��200��6+   $	��400��68   ��5	      �� 5
   
    �� ImageSource$/ )/images/messageBoxes/DangerBackground.png��6   .��5      � .+�5   
   �� $
��Left=�6   $��87��6+   $��	147,3,0,0q�67   $	��Top=�6J   $��87��6b   $%��/images/messageBoxes/danger.png��6m   �� 5   
   $���{Dear              , patient                           doesn't have a 
         medical record, so do you want to create it?��6   $
��Left=�6�   $��	14,77,0,0q�6�   $	��Top=�6�   $��15(�6�   $	��362��6�   �� 5   
   -   5        $	��YES��5      $
��Left=�6   $��
52,137,0,0q�6:   $	��Top=�6N   $	��120��6f   $��40��6r   $��17(�6~   ���#f6252a6�   �� 5   
   -   5        $��NO��5      $
��Left=�6   $��217,137,0,0q�69   $	��Top=�6N   $	��120��6f   $��40��6r   $��17(�6~   ���#f6252a6�   �� 5   
   -   5         ��Name$ Textbox1��5      $
��Left=�6$   $��26��6?   $��
169,81,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��105��6�   $��15(�6�   {�.  ��6�   Z� ��6�   Z� 6�   �� 5   
   -   5        $ Textbox2��5      $
��Left=�6$   $��26��6?   $��	49,81,0,0q�6K   $
 Wrap=�6^   $	��Top=�6r   $��66��6�   $��15(�6�   {�.  ��6�   Z� ��6�   Z� 6�   5      5      