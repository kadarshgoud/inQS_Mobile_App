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
	
	$query = "SELECT t00field07_01, t00field07_02, t00field07_03, t00field07_04, t00field07_05, t00field07_06 
	FROM tbl_form_ebqe_t00 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);


	$numrows=mysqli_num_rows($sqlStmt); 
	

	  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   
         $field07_01=$row['t00field07_01'];  
	     $field07_02 =$row['t00field07_02'];  
		 $field07_03 =$row['t00field07_03'];  
		 $field07_04 =$row['t00field07_04'];  
		 $field07_05 =$row['t00field07_05'];  
		 $field07_06 =$row['t00field07_06'];  
		
		}
	echo $field07_01.':'.$field07_02.':'.$field07_03.':'.$field07_04.':'.$field07_05.':'.$field07_06.':';
	}
	
	

	
	
	

	
	
mysqli_close($connection);
?>