   M S B A M L   `   `   `  ����D  @HerbMedic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:HerbMedic.View.DoctorHerbMedic.View.Doctor  5   	   )    #HerbMedic.View.Doctor.MedicalRecord   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:HerbMedic.View.Doctor     5   	     � WindowStartupLocation$  CenterScreen=�5       � WindowStyle$
 None=�6?    � Title$ MedicalRecord��5   	   $	��600��6   $	��800��6,   ��5	      �� 5
   
    �� ImageSource$&  /images/templates/HomeDoctor.png��6   .��5      � .+�5   
   �� $��MEDICAL RECORD:��6   $��Center=�6*   $��285,-2,284,0q�6G   $	��Top=�6]   ���	#FF00182D$
��25px(�6�   $	��223��6�   �� 5   
   -   5         ��Name$ Textbox_username��5      $
��Left=�6,   $��23��6G   $��
625,10,0,0q�6S    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $	��120��6�   ���	#FF00182D$��17(�6�   {�.  6�   �� 5   
   $
��Left=�6   $��23��6+   $��
595,10,0,0q�67   $	��Top=�6K   $��24��6c   $��/images/users/surgeon.png��6n   {�.  6�   �� 5   
   -   5        $
��Left=�5      $��30��6,   $��35,0,0,0q�68   $	��Top=�6J   $��39��6b   ���#2dadf6���	#FF00182D.��5      �� $'��!/images/details/backarrowBlue.png��6   $��26��6?   6L   5      �� 5   
   -   5        $
��Left=�5      $��30��6,   $��35,0,0,0q�68   $	��Top=�6J   $��39��6b   ���#2dadf6���	#FF00182D.��5      �� $'��!/images/details/backarrowBlue.png��6   $��26��6?   6L   5      �� 5   
   $��Patient name:��6   $
��Left=�6(   $��
188,89,0,0q�6C   $	��Top=�6W   ���	#FF00182D���	#FF00182D$��25(�6�   �� 5   
   $��Patient surname:��6   $
��Left=�6+   $��188,145,0,0q�6F   $	��Top=�6[   ���	#FF00182D���	#FF00182D$��25(�6�   �� 5   
   -   5        $ Textbox1��5      $
��Left=�6$   $��35��6?   $��
397,95,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $	��222��6�   ���	#FF00182D$��25(�6�   {�.  6�   �� 5   
   -   5        $ Textbox2��5      $
��Left=�6$   $��35��6?   $��397,150,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��222��6�   ���	#FF00182D$��25(�6�   {�.  6�   �� 5   
   -   5        $��	ANAMNESIS��5      $
��Left=�6%   $��
63,232,0,0q�6@   $	��Top=�6T   $	��689��6l   $��90��6x   $��30(�6�   ���	#FF00182D���	#FF00182D���#2dadf66�   �� 5   
   -   5        $��PRESCRIPTION��5      $
��Left=�6(   $��
63,348,0,0q�6C   $	��Top=�6W   $	��689��6o   $��90��6{   $��30(�6�   ���	#FF00182D���	#FF00182D���#2dadf66�   �� 5   
   -   5        $��	ALLERGENS��5      $
��Left=�6%   $��
63,466,0,0q�6@   $	��Top=�6T   $	��689��6l   $��90��6x   $��30(�6�   ���	#FF00182D���	#FF00182D���#2dadf66�   5      5      