   M S B A M L   `   `   `  ����D  @HerbMedic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:HerbMedic.View.DoctorHerbMedic.View.Doctor  5   	   2    ,HerbMedic.View.Doctor.ReceiveReferralLetters   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:HerbMedic.View.Doctor     5   	     � WindowStartupLocation$  CenterScreen=�5       � WindowStyle$
 None=�6?    � Title$ ReceiveReferralLetters��5   	   $	��600��6(   $	��800��65   ��5	      �� 5
   
    �� ImageSource$&  /images/templates/HomeDoctor.png��6   .��5      � .+�5   
   �� $��RECEIVED REFERRALS:��6   $��Center=�6.   $��280,-2,244,0q�6K   $	��Top=�6a   ���	#FF00182D$
��25px(�6�   $	��268��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dg_referrals��5   <      SelectionMode$ Single=�6      
IsReadOnly . $
��Left=�6R   $	��222��6m   $��	72,70,0,0q�6z   $	��Top=�6�   $	��673��6�      AutoGenerateColumns . ���	#FF00182D���#BEFBFF � 	Resources 5      	 �� Color��%X   (��       5   "   * SystemColors.HighlightBrushKey+)�� 6   $	 #2dadf6��5      5      5      �� 5   
   -   5        
 ��Name$
 Textbox_username��5      $
��Left=�6,   $��23��6G   $��
625,10,0,0q�6S    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $	��120��6�   ���	#FF00182D$��17(�6�   {�.  6�   �� 5   
   $
��Left=�6   $��23��6+   $��
595,10,0,0q�67   $	��Top=�6K   $��24��6c   $��/images/users/surgeon.png��6n   {�.  6�   �� 5   
   -   5        $
��Left=�5      $��30��6,   $��35,0,0,0q�68   $	��Top=�6J   $��39��6b   ���#2dadf6���	#FF00182D.��5      �� $'��!/images/details/backarrowBlue.png��6   $��26��6?   6L   5      �� 5   
   $��Identificator:��6   $
��Left=�6)   $��
72,321,0,0q�6D   $	��Top=�6X   ���	#FF00182D$
��17px(�6�   �� 5   
   -   5        $
 Textbox1��5      $
��Left=�6�   $��28��6�   $��220,324,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��369��6  ���	#FF00182D$
��17px(�63  {�.  ��6$   �� *SelectedItem.id+ �� ElementName$ dg_referrals�� �� Mode$ OneWay=�6C  �� 5   
   $��Sending doctor:��6   $
��Left=�6*   $��
72,368,0,0q�6E   $	��Top=�6Y   ���	#FF00182D$
��17px(�6�   �� 5   
   -   5        $
 Textbox2��5      $
��Left=�6�   $��28��6�   $��220,371,0,0q�6�   $
 Wrap=�6�   $	��Top=�6  $	��369��6  ���	#FF00182D$
��17px(�6?  {�.  ��6$   �� *SelectedItem.doctorWhoSends+$ dg_referrals��$ OneWay=�6O  �� 5   
   $��Receiving doctor:��6   $
��Left=�6,   $��
72,414,0,0q�6G   $	��Top=�6[   ���	#FF00182D$
��17px(�6�   �� 5   
   -   5        $
 Textbox3��5      $
��Left=�6�   $��28��6�   $��220,417,0,0q�6�   $
 Wrap=�6�   $	��Top=�6  $	��369��6  ���	#FF00182D$
��17px(�6B  {�.  ��6$   �� * SelectedItem.doctorWhoReceives+$ dg_referrals��$ OneWay=�6R  �� 5    
   $��Patient name:��6   $
��Left=�6(   $��
72,459,0,0q�6C   $	��Top=�6W   ���	#FF00182D$
��17px(�6�   �� 5!   
   -   5        $
 Textbox4��5!      $
��Left=�6�   $��28��6�   $��220,462,0,0q�6�   $
 Wrap=�6�   $	��Top=�6  $	��369��6  ���	#FF00182D$
��17px(�6<  {�.  ��6$   �� *SelectedItem.patientName+$ dg_referrals��$ OneWay=�6L  �� 5"   
   $��Reason:��6   $
��Left=�6"   $��
72,502,0,0q�6=   $	��Top=�6Q   ���	#FF00182D$
��17px(�6�   �� 5#   
   -   5        $
 Textbox5��5#      $
��Left=�6�   $��28��6�   $��220,505,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��369��6  ���	#FF00182D$
��17px(�67  {�.  ��6$   �� *SelectedItem.reason+$ dg_referrals��$ OneWay=�6G  �� 5$   
   -	   5        $+��%Referral letter has 
      been read��5$      $
��Left=�6I   $��612,394,0,0q�6d   $	��Top=�6y   $	��161��6�   ���#2dadf6���	#FF00182D$
��17px(�6�   $��68��6�   6�   5%      5&      