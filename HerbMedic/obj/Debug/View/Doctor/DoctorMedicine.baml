   M S B A M L   `   `   `  ����D  @HerbMedic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:HerbMedic.View.DoctorHerbMedic.View.Doctor  5   	   *    $HerbMedic.View.Doctor.DoctorMedicine   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:HerbMedic.View.Doctor     5   	     � WindowStartupLocation$  CenterScreen=�5       � WindowStyle$
 None=�6?    � Title$ DoctorMedicine��5   	   $	��600��6    $	��800��6-   ��5	      �� 5
   
    �� ImageSource$&  /images/templates/HomeDoctor.png��6   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dg_medicines��5   <      SelectionMode$ Single=�6      
IsReadOnly . $
��Left=�6R   $	��184��6m   $��
76,248,0,0q�6z   $	��Top=�6�   $	��669��6�      AutoGenerateColumns . ���	#FF00182D���#BEFBFF � 	Resources 5      	 �� Color��%X   (��       5   "   * SystemColors.HighlightBrushKey+)�� 6   $	 #2dadf6��5      5      5        5   
   -   5        $ dg_ingredients��5   %    . $
��Left=�6=   $	��120��6X   $��
76,437,0,0q�6e   $	��Top=�6y   $	��329��6�   ���	#FF00182D . ���#BEFBFF 5      ��%X   (��       5   "   * SystemColors.HighlightBrushKey+)�� 6   $	 #2dadf6��5      5      5        5   
   -   5        $ dg_alternatives��5   %    . $
��Left=�6>   $	��120��6Y   $��416,437,0,0q�6f   $	��Top=�6{   $	��329��6�    . ���	#FF00182D���#BEFBFF 5      ��%X   (��       5   "   * SystemColors.HighlightBrushKey+)�� 6   $	 #2dadf6��5      5      5      �� 5   
   $��
MEDICINES:��6   $��Center=�6%   $��331,-2,318,0q�6B   $	��Top=�6X   ���	#FF00182D$
��25px(�6�   $	��143��6�   �� 5    
   -   5        
 ��Name$
 Textbox_username��5       $
��Left=�6,   $��23��6G   $��
625,10,0,0q�6S    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $	��120��6�   ���	#FF00182D$��17(�6�   {�.  6�   �� 5!   
   $
��Left=�6   $��23��6+   $��
595,10,0,0q�67   $	��Top=�6K   $��24��6c   $��/images/users/surgeon.png��6n   {�.  6�   �� 5"   
   -   5        $
��Left=�5"      $��30��6,   $��35,0,0,0q�68   $	��Top=�6J   $��39��6b   ���#2dadf6���	#FF00182D.��5#      �� $'��!/images/details/backarrowBlue.png��6   $��26��6?   6L   5$      �� 5%   
   -   5        $��Read all��5%      $
��Left=�6$   $��540,194,0,0q�6?   $	��Top=�6T   $	��205��6l   ���#2dadf6���	#FF00182D$
��17px(�6�   6�   �� 5&   
   -   5        $��Update medicine��5&      $
��Left=�6+   $��540,151,0,0q�6F   $	��Top=�6[   $	��205��6s   ���#2dadf6���	#FF00182D$
��17px(�6�   6�   �� 5'   
   -   5        $��Decline medicine��5'      $
��Left=�6,   $��540,110,0,0q�6G   $	��Top=�6\   $	��205��6t   ���#2dadf6���	#FF00182D$
��17px(�6�   6�   �� 5(   
   -	   5        $��Accept medicine��5(      $
��Left=�6+   $��
540,70,0,0q�6F   $	��Top=�6Z   $	��205��6r   ���#2dadf6���	#FF00182D$
��17px(�6�   6�   �� 5*   
   $��Identificator:��6   $
��Left=�6)   ���	#FF00182D$
��17px(�6[   $��
103,67,0,0q�6k   $	��Top=�6   �� 5+   
   $��Name:��6   $
��Left=�6    ���	#FF00182D$
��17px(�6R   $��103,107,0,0q�6b   $	��Top=�6w   �� 5,   
   $��Status:��6   $
��Left=�6"   ���	#FF00182D$
��17px(�6T   $��103,148,0,0q�6d   $	��Top=�6y   �� 5-   
   $��Description:��6   $
��Left=�6'   ���	#FF00182D$
��17px(�6Y   $��103,191,0,0q�6i   $	��Top=�6~   �� 5.   
   -
   5        $
 Textbox1��5.      $
��Left=�6$   $��28��6�   ���	#FF00182D$
��17px(�6�   $��
212,69,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��278��6�   {�.  ��6?   �� *SelectedItem.id+ �� ElementName$ dg_medicines�� �� Mode$ OneWay=�6  �� 5/   
   -   5        $
 Textbox2��5/      $
��Left=�6$   $��28��6�   ���	#FF00182D$
��17px(�6�   $��212,110,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��278��6�   ��6?   �� *SelectedItem.name+$ dg_medicines��$ OneWay=�6�   �� 50   
   -   5        $
 Textbox3��50      $
��Left=�6$   $��28��6�   ���	#FF00182D$
��17px(�6�   $��212,151,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��278��6�   {�.  ��6?   �� *SelectedItem.status+$ dg_medicines��$ OneWay=�6  �� 51   
   -   5        $
 Textbox4��51      $
��Left=�6$   $��28��6�   ���	#FF00182D$
��17px(�6�   $��212,193,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��278��6  ��6?   �� *SelectedItem.description+$ dg_medicines��$ OneWay=�6  52      53      