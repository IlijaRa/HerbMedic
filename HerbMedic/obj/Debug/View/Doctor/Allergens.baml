   M S B A M L   `   `   `  ����D  @HerbMedic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:HerbMedic.View.DoctorHerbMedic.View.Doctor  5   	   %    HerbMedic.View.Doctor.Allergens   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:HerbMedic.View.Doctor     5   	     � WindowStartupLocation$  CenterScreen=�5       � WindowStyle$
 None=�6?    � Title$ 	Allergens��5   	   $	��600��6   $	��800��6(   ��5	      �� 5
   
    �� ImageSource$&  /images/templates/HomeDoctor.png��6   .��5      � .+�5   
   �� $��PATIENT ALLERGENS:��6   $��Center=�6-   $��281,-2,268,0q�6J   $	��Top=�6`   ���	#FF00182D$
��25px(�6�   $	��243��6�   �� 5   
   -   5         ��Name$ Textbox_username��5      $
��Left=�6,   $��23��6G   $��
625,10,0,0q�6S    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $	��120��6�   ���	#FF00182D$��17(�6�   {�.  6�   �� 5   
   $
��Left=�6   $��23��6+   $��
595,10,0,0q�67   $	��Top=�6K   $��24��6c   $��/images/users/surgeon.png��6n   {�.  6�   �� 5   
   -   5        $
��Left=�5      $��30��6,   $��35,0,0,0q�68   $	��Top=�6J   $��39��6b   ���#2dadf6���	#FF00182D.��5      �� $'��!/images/details/backarrowBlue.png��6   $��26��6?   6L   5      �� 5   
   $��Patient name:��6   $
��Left=�6(   $��
188,89,0,0q�6C   $	��Top=�6W   ���	#FF00182D���	#FF00182D$��25(�6�   �� 5   
   $��Patient surname:��6   $
��Left=�6+   $��188,145,0,0q�6F   $	��Top=�6[   ���	#FF00182D���	#FF00182D$��25(�6�   �� 5   
   -   5        $ Textbox1��5      $
��Left=�6$   $��35��6?   $��
397,95,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $	��222��6�   ���	#FF00182D$��25(�6�   {�.  6�   �� 5   
   -   5        $ Textbox2��5      $
��Left=�6$   $��35��6?   $��397,150,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��222��6�   ���	#FF00182D$��25(�6�   {�.  6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dg_allergens��5   J      SelectionMode$ Single=�6      
IsReadOnly . $��25(�6<   $
��Left=�6`   $	��191��6{   $��
73,224,0,0q�6�   $	��Top=�6�   $	��672��6�   	   AutoGenerateColumns	 . ���	#FF00182D���#BEFBFF
 � 	Resources
 5       �� Color��%X   (��       5   "   * SystemColors.HighlightBrushKey+)�� 6   $ #2dadf6��5      5      5      �� 5   
   -   5        $��240,513,441,31q�5      ���#2dadf6���	#FF00182D$
��17px(�6U   .��5      �� $��/images/details/plus.png��6   $��34��66   5      �� 5    
   -   5        $��359,513,323,31q�5       ���#2dadf6���	#FF00182D$
��17px(�6V   .��5!      �� $��/images/details/minus.png��6   $��34��67   5"      �� 5#   
   -   5        $��478,513,204,31q�5#      $��Read all��6)   ���#2dadf6���	#FF00182D$
��17px(�6i   6y   �� 5$   
   -	   5        $ Textbox3��5$      $
��Left=�6a   $��30��6|   $��357,450,0,0q�6�   ���	#FF00182D$
��17px(�6�   $
 Wrap=�6�   $	��Top=�6�   $	��231��6�   �� 5%   
   $��New allergen:��6   $
��Left=�6(   ���	#FF00182D$
��17px(�6Z   $��240,449,0,0q�6j   $	��Top=�6   5&      5'      