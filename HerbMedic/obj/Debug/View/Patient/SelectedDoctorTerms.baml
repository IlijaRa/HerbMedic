   M S B A M L   `   `   `  ����D  @HerbMedic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:HerbMedic.View.PatientHerbMedic.View.Patient  5   	   0    *HerbMedic.View.Patient.SelectedDoctorTerms   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:HerbMedic.View.Patient     5   	     � WindowStartupLocation$  CenterScreen=�5       � WindowStyle$
 None=�6?    � Title$ SelectedDoctorTerms��5   	   $	��400��6%   $	��400��62   ��5	      �� 5
   
    �� ImageSource$/ )/images/templates/SelectedDoctorTerms.png��6   .��5      � .+�5   
   �� $��RESERVED APPOINTMENTS:��6   $��Center=�61   $��	49,0,19,0q�6N   $	��Top=�6a   ���	#FF00182D$
��25px(�6�   $	��324��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dg_terms��5   <      SelectionMode$ Single=�6      
IsReadOnly . $
��Left=�6N   $	��263��6i   $��	49,40,0,0q�6v   $	��Top=�6�   $	��324��6�      AutoGenerateColumns . ���	#FF00182D���#fffaa1 � 	Resources 5      	 �� Color��%X   (��       5   "   * SystemColors.HighlightBrushKey+)�� 6   $	 #ffc300��5      5      5      �� 5   
   -   5        $��OK��5      $
��Left=�6   $��128,328,0,0q�69   $	��Top=�6N   $	��154��6f   $��44��6r   ���	#FF00182D���#ffc300$
��17px(�6�   6�   5      5      