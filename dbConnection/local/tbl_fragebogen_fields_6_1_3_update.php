<?php

$connection = mysqli_connect("localhost", "root", "123456", "qvidap");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}
		$id_Tour = $_POST['id_Tour'];
		$pf = $_POST['Pflegedienst'];
		$cid = $_POST['Customer_Id'];
		$zeit = $_POST['Zeitraum_Id'];
		$field_6_1 = $_POST['field_6_1']; 
		$field_6_2 = $_POST['field_6_2'];
		$field_6_3 = $_POST['field_6_3']; 
		$field_6_4 = $_POST['field_6_4'];
		$field_6_1_2_diff = $_POST['field_6_1_2_diff']; 
		$field_6_3_4_diff = $_POST['field_6_3_4_diff'];
		

	$query1 = mysqli_query($connection,"UPDATE tbl_fragebogen SET 6_1 = '$field_6_1', 6_2 = '$field_6_2', 6_3 = '$field_6_3', 6_4 = '$field_6_4', 6_1_2_days = '$field_6_1_2_diff', 6_3_4_days = '$field_6_3_4_diff' WHERE id_Pflegedienst = '$pf' && id_Tour= '$id_Tour' && id_Kunde= '$cid' && id_Zeitraum= '$zeit'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
		$row=mysqli_fetch_assoc($sqlStmt);
		  $field_6_1 =$row['field_6_1'];  
		  $field_6_2 =$row['field_6_2']; 
		  $field_6_3 =$row['field_6_3'];  
		  $field_6_4 =$row['field_6_4']; 
		  $field_6_1_2_diff =$row['field_6_1_2_diff'];  
		  $field_6_3_4_diff =$row['field_6_3_4_diff']; 
		    
		}
	echo $field_6_1.':' .$field_6_2.':' .$field_6_3.':' .$field_6_4.':'.$field_6_1_2_diff.':' .$field_6_3_4_diff.':';
	}

mysqli_close($connection);
?>