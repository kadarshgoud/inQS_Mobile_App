<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$en = $_POST['einrichtung'];
	$wo = $_POST['wohnbereich'];
	$wn = $_POST['id'];
	$bid = $_POST['bewonerid']; 
	
	$query = "SELECT t00field13_1, t00field13_2, t00field13_3, t00field13_4,t00field13_5, t00field13_6, t00field13_7, t00field13_7_1, t00field13_8, t00field13_9, t00field13_10, t00field13_11, t00field13_11_1, t00field13_11_2 FROM tbl_form_ebqe_t00 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);


	$numrows=mysqli_num_rows($sqlStmt); 
		  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{            
           $row=mysqli_fetch_assoc($sqlStmt);
		           
			$field13_01 =$row['t00field13_1'];  
			$field13_02 =$row['t00field13_2'];  
			$field13_03 =$row['t00field13_3'];  
			$field13_04 =$row['t00field13_4'];  
			$field13_05 =$row['t00field13_5'];  
			$field13_06 =$row['t00field13_6']; 
			$field13_07 =$row['t00field13_7'];
			$field13_07_01 =$row['t00field13_7_1'];
		    $field13_08 =$row['t00field13_8'];
			$field13_09 =$row['t00field13_9'];
			$field13_10 =$row['t00field13_10'];
			$field13_11 =$row['t00field13_11'];
			$field13_11_1 =$row['t00field13_11_1'];
			$field13_11_2 =$row['t00field13_11_2'];
		}
		
	echo $field13_01.':'.$field13_02.':'.$field13_03.':'.$field13_04.':'.$field13_05.':'.$field13_06.':'.$field13_07.':' .$field13_07_01.':' .$field13_08.':' .$field13_09.':' .$field13_10.':' .$field13_11.':'.$field13_11_1.':'.$field13_11_2;
	
	}
	
mysqli_close($connection);
?>