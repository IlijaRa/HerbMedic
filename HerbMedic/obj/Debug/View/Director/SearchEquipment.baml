   M S B A M L   `   `   `  ����D  @HerbMedic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HerbMedic.ViewHerbMedic.View  5   	   $    HerbMedic.View.SearchEquipment   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:HerbMedic.View     5   	     � WindowStyle$
  None=�5       � WindowStartupLocation$ CenterScreen=�6-    � Title$ SearchEquipment��5   	   $	��600��6!   $	��800��6.   ��5	      �� 5
   
    �� ImageSource$  /images/templates/Home.png��6   .��5      � .+�5   
   �� -   5        $
��Left=�5      $��30��6,   $��35,0,0,0q�68   $	��Top=�6J   $��39��6b   ���	#FF209E67���	#FF00182D.��5      �� $'��!/images/details/backarrowBlue.png��6   $��26��6?   6L   5      �� 5   
   $��SEARCH EQUIPMENT:��6   $��Center=�6,   $��267,-2,276,0q�6I   $	��Top=�6_   ���	#FF00182D$
��25px(�6�   $	��249��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dg_search��5   *      SelectionMode$ Single=�6      
IsReadOnly .    AutoGenerateColumns . $
��Left=�6j   $	��305��6�   $��
74,122,0,0q�6�   $	��Top=�6�   $	��674��6�   ���	#FF00182D���#CCFFCC � 	Resources 5      	 �� Color��%Z   (��       5   "   * SystemColors.HighlightBrushKey+)�� 6   $	 	#FF209E67��5      5      5      �� 5   
   $��Search by name:��6   $
��Left=�6*   $��	74,79,0,0q�6E   $	��Top=�6X   ���	#FF00182D$
��17px(�6�   �� 5   
   -   5        
 ��Name$
 Textbox1��5      $
��Left=�6`   $��28��6{   $��
211,82,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��289��6�   ���	#FF00182D$
��17px(�6�   6�   �� 5   
   $!��What are you searching for:��6   $
��Left=�66   $��304,454,0,0q�6Q   $	��Top=�6f   ���	#FF00182D$
��17px(�6�   �� 5   
   -   5        $��Static equip��5      $
��Left=�6(   $��292,486,0,0q�6C   $	��Top=�6X   $	��120��6p   $
��40px��6|   ���#209e67���	#FF00182D$
��17px(�6�   6�   �� 5   
   -   5        $��Dynamic equip��5      $
��Left=�6)   $��416,486,0,0q�6D   $	��Top=�6Y   $	��120��6q   $
��40px��6}   ���#209e67���	#FF00182D$
��17px(�6�   6�   �� 5   
   -   5         ��Name$ 
label_type��5      $�� ��6$   $
��Left=�6/   $��
544,79,0,0q�6J   $	��Top=�6^   $��33��6v   $	��204��6�   ���	#FF00182D$
��17px(�6�   5      5      