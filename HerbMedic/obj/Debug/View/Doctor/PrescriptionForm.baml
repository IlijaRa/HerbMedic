   M S B A M L   `   `   `  ����D  @HerbMedic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:HerbMedic.View.DoctorHerbMedic.View.Doctor  5   	   ,    &HerbMedic.View.Doctor.PrescriptionForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:HerbMedic.View.Doctor     5   	     � WindowStyle$
  None=�5       � WindowStartupLocation$ CenterScreen=�6-    � Title$ PrescriptionForm��5   	   $	��600��6"   $	��800��6/   ��5	      �� 5
   
    �� ImageSource$&  /images/templates/HomeDoctor.png��6   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dg_prescriptions��5   <      SelectionMode$ Single=�6      
IsReadOnly . $
��Left=�6V   $	��170��6q   $��
56,403,0,0q�6~   $	��Top=�6�   $	��689��6�      AutoGenerateColumns . ���	#FF00182D���#BEFBFF � 	Resources 5      	 �� Color��%X   (��       5   "   * SystemColors.HighlightBrushKey+)�� 6   $	 #2dadf6��5      5      5      �� 5   
   $��Patient name:��6   $
��Left=�6(   $��
188,89,0,0q�6C   $	��Top=�6W   ���	#FF00182D���	#FF00182D$��25(�6�   �� 5   
   $��Patient surname:��6   $
��Left=�6+   $��188,145,0,0q�6F   $	��Top=�6[   ���	#FF00182D���	#FF00182D$��25(�6�   �� 5   
   -   5        
 ��Name$
 Textbox1��5      $
��Left=�6$   $��35��6?   $��
397,95,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��222��6�   ���	#FF00182D$��25(�6�   {�.  6�   �� 5   
   -   5        $
 Textbox2��5      $
��Left=�6$   $��35��6?   $��397,150,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��222��6�   ���	#FF00182D$��25(�6�   {�.  6�   �� 5   
   $��PRESCRIPTIONS:��6   $��Center=�6)   $��312,-2,286,0q�6F   $	��Top=�6\   ���	#FF00182D$
��25px(�6�   $	��194��6�   �� 5   
   -   5        $
 Textbox_username��5      $
��Left=�6,   $��23��6G   $��
625,10,0,0q�6S   $
 Wrap=�6g   $	��Top=�6{   $	��120��6�   ���	#FF00182D$��17(�6�   {�.  6�   �� 5   
   $
��Left=�6   $��23��6+   $��
595,10,0,0q�67   $	��Top=�6K   $��24��6c   $��/images/users/surgeon.png��6n   {�.  6�   �� 5   
   -   5        $
��Left=�5      $��30��6,   $��35,0,0,0q�68   $	��Top=�6J   $��39��6b   ���#2dadf6���	#FF00182D.��5      �� $'��!/images/details/backarrowBlue.png��6   $��26��6?   6L   5      �� 5   
   $��Choose medicine:��6   $
��Left=�6+   $��
76,236,0,0q�6F   $	��Top=�6Z   $��17(�6r   ���	#FF00182D6�   �� 5   
   $��	Quantity:��6   $
��Left=�6$   $��
76,278,0,0q�6?   $	��Top=�6S   $��17(�6k   ���	#FF00182D6y   �� 5    
   $��Instruction for usage:��6   $
��Left=�61   $��
76,320,0,0q�6L   $	��Top=�6`   $��17(�6x   ���	#FF00182D6�   �� 5!   
   -   5         ��Name$ 	Combobox1��5!      $
��Left=�6|   $��28��6�   $��265,238,0,0q�6�   $	��Top=�6�   $	��241��6�   $��17(�6�   ���	#FF00182D �� Text 6&   �� *SelectedItem.medicineName+ �� ElementName$ dg_prescriptions�� �� Mode$ OneWay=�6�   �� 5"   
   -   5        $ 	Combobox2��5"      $
��Left=�6x   $��28��6�   $��265,279,0,0q�6�   $	��Top=�6�   $	��241��6�   $��17(�6�   ���	#FF00182D 6&   �� *SelectedItem.quantity+$ dg_prescriptions��$ OneWay=�.@�5#      �� .��6   	1/2 table6&   �� 5$      .��6   	1 table6$   �� 5%      .��6   	2 table6$   �� 5&      .��6   	3 table6$   5'      �� 5(   
   -   5        $
 Textbox5��5(      $
��Left=�6�   $��71��6�   $��265,322,0,0q�6�   $
 Wrap=�6�   $	��Top=�6
  $	��241��6"  $��17(�6.  ���	#FF00182D��6$   �� *SelectedItem.usageInstruction+$ dg_prescriptions��$ OneWay=�6<  �� 5)   
   -	   5        $��Create��5)      $
��Left=�6"   $��569,213,0,0q�6=   $	��Top=�6R   $	��150��6j   $��40��6v   ���	#FF00182D$
��17px(�6�   ���#2dadf66�   �� 5*   
   -
   5        $��Update��5*      $
��Left=�6"   $��569,275,0,0q�6=   $	��Top=�6R   $	��150��6j   $��40��6v   ���	#FF00182D���#2dadf6$��17(�6�   6�   �� 5+   
   -   5        $��Read all��5+      $
��Left=�6$   $��569,337,0,0q�6?   $	��Top=�6T   $	��150��6l   $��40��6x   ���	#FF00182D���#2dadf6$��17(�6�   6�   �� 5,   
   $��Identificator:��6   $
��Left=�6)   $��
76,194,0,0q�6D   $	��Top=�6X   $��17(�6p   ���	#FF00182D6~   �� 5-   
   -   5        $
 Textbox3��5-      $
��Left=�6p   $��28��6�   $��265,196,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��241��6�   $��17(�6�   ���	#FF00182D{�.  ��6$   �� *SelectedItem.id+$ dg_prescriptions��$ OneWay=�6	  5.      5/      