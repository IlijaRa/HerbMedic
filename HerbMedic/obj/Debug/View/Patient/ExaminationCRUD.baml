   M S B A M L   `   `   `  ����D  @HerbMedic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:HerbMedic.View.PatientHerbMedic.View.Patient  5   	   ,    &HerbMedic.View.Patient.ExaminationCRUD   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:HerbMedic.View.Patient     5   	     � WindowStartupLocation$  CenterScreen=�5       � WindowStyle$
 None=�6?    � Title$ ExaminationCRUD��5   	   $	��600��6!   $	��800��6.   ��5	      �� 5
   
    �� ImageSource$' !/images/templates/HomePatient.png��6   .��5      � .+�5   
   �� $��EXAMINATIONS:��6   $��Center=�6(   $��311,-2,282,0q�6E   $	��Top=�6[   ���	#FF00182D$
��25px(�6�   $	��199��6�   �� 5   
   -   5         ��Name$ Textbox_username��5      $
��Left=�6,   $��23��6G   $��
625,10,0,0q�6S    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $	��120��6�   ���	#FF00182D$��17(�6�   {�.  6�   �� 5   
   $
��Left=�6   $��23��6+   $��
595,10,0,0q�67   $	��Top=�6K   $��24��6c   $��/images/users/patient.png��6n   {�.  6�   �� 5   
   -   5        $
��Left=�5      $��30��6,   $��35,0,0,0q�68   $	��Top=�6J   $��39��6b   ���#ffc300���	#FF00182D.��5      �� $'��!/images/details/backarrowBlue.png��6   $��26��6?   6L   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dg_examinations��5   <      SelectionMode$ Single=�6      
IsReadOnly . $
��Left=�6U   $	��263��6p   $��	74,40,0,0q�6}   $	��Top=�6�   $	��672��6�   	   AutoGenerateColumns	 . ���	#FF00182D���#fffaa1
 � 	Resources
 5       �� Color��%X   (��       5   "   * SystemColors.HighlightBrushKey+)�� 6   $ #ffc300��5      5      5      �� 5   
   $��Identificator:��6   $
��Left=�6)   $��
66,354,0,0q�6D   $	��Top=�6X   ���	#FF00182D$
��17px(�6�   �� 5   
   $��Start time:��6   $
��Left=�6&   $��
66,473,0,0q�6A   $	��Top=�6U   ���	#FF00182D$
��17px(�6�   �� 5   
   $��Doctor:��6   $
��Left=�6"   $��
66,394,0,0q�6=   $	��Top=�6Q   ���	#FF00182D$
��17px(�6�   �� 5   
   $��Date:��6   $
��Left=�6    $��
66,433,0,0q�6;   $	��Top=�6O   ���	#FF00182D$
��17px(�6~   �� 5   
   $��	End time:��6   $
��Left=�6$   $��
66,513,0,0q�6?   $	��Top=�6S   ���	#FF00182D$
��17px(�6�   �� 5   
   $��(HH:mm)��6   $
��Left=�6"   $��485,473,0,0q�6=   $	��Top=�6R   ���	#FF00182D$
��17px(�6�   �� 5    
   $��(HH:mm)��6   $
��Left=�6"   $��485,513,0,0q�6=   $	��Top=�6R   ���	#FF00182D$
��17px(�6�   �� 5!   
   -   5        $ Textbox1��5!      $
��Left=�6�   $��28��6�   $��178,357,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��384��6  ���	#FF00182D$
��17px(�66  {�.  ��6$   �� *SelectedItem.id+ �� ElementName$ dg_examinations�� �� Mode$ OneWay=�6F  �� 5"   
   -   5         ��Name$ 	Combobox1��5"      $
��Left=�6&   $��28��6A   $��178,396,0,0q�6M   $	��Top=�6b   $	��384��6z   ���	#FF00182D$
��17px(�6�   6�   (  "System.Windows.Controls.DatePicker  5#   
   -   5          Name$ Datepicker1��5#      $
��Left=�6w   $��28��6�   $��178,436,0,0q�6�   $	��Top=�6�   $	��384��6�   ���	#FF00182D$
��17px(�6�      Text 6*   �� *SelectedItem.date+$ dg_examinations��$ OneWay=�6�   �� 5$   
   -   5        $ Textbox2��5$      $
��Left=�6�   $��28��6�   $��178,475,0,0q�6�   $
 Wrap=�6�   $	��Top=�6  $	��301��6  ���	#FF00182D$
��17px(�6=  ��6$   �� *SelectedItem.startTime+$ dg_examinations��$ OneWay=�6=  �� 5%   
   -   5        $ Textbox3��5%      $
��Left=�6�   $��28��6�   $��178,515,0,0q�6�   $
 Wrap=�6�   $	��Top=�6   $	��301��6  ���	#FF00182D$
��17px(�6;  ��6$   �� *SelectedItem.endTime+$ dg_examinations��$ OneWay=�6;  �� 5&   
   -	   5        $��Create��5&      $
��Left=�6"   $��592,358,0,0q�6=   $	��Top=�6R   $	��154��6j   $��28��6v   ���	#FF00182D���#ffc300$
��17px(�6�   6�   �� 5'   
   -
   5        $��Update��5'      $
��Left=�6"   $��592,411,0,0q�6=   $	��Top=�6R   $	��154��6j   $��28��6v   ���	#FF00182D���#ffc300$
��17px(�6�   6�   �� 5(   
   -   5        $��Delete��5(      $
��Left=�6"   $��592,465,0,0q�6=   $	��Top=�6R   $	��154��6j   $��28��6v   ���	#FF00182D���#ffc300$
��17px(�6�   6�   �� 5)   
   -   5        $��Read all��5)      $
��Left=�6$   $��592,517,0,0q�6?   $	��Top=�6T   $	��154��6l   $��28��6x   ���	#FF00182D���#ffc300$
��17px(�6�   6�   5*      5+      