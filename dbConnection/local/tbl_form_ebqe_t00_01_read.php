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
	
	$query = "SELECT t00field01, t00field02_1, t00field02_2, t00field03 ,t00field04, t00field05, t00field06 
	FROM tbl_form_ebqe_t00 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);


	$numrows=mysqli_num_rows($sqlStmt); 
	

	  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   
            $field01=$row['t00field01'];  
       
	     $field02_1 =$row['t00field02_1'];  
		 $field02_2 =$row['t00field02_2'];  
		 $field03 =$row['t00field03'];  
		 $field04 =$row['t00field04'];  
		 $field05 =$row['t00field05'];  
		 $field06 =$row['t00field06']; 
		 
	  
		}
	echo $field01.':'.$field02_1.':'.$field02_2.':'.$field03.':'.$field04.':'.$field05.':'.$field06.':';
	}
	
	

	
	
	

	
	
mysqli_close($connection);
?>