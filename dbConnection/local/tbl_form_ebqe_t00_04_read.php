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
	
	$query = "SELECT t00field09, t00field10, t00field11, t00field12
	FROM tbl_form_ebqe_t00 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);


	$numrows=mysqli_num_rows($sqlStmt); 
	

	  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   
           
       
	     $field09 =$row['t00field09'];  
		 $field10 =$row['t00field10'];  
		 $field11 =$row['t00field11'];  
		 $field12 =$row['t00field12'];  
		 
		
		 
	  
		}
	echo $field09.':'.$field10.':'.$field11.':'.$field12.':';
	}
	
	

	
	
	

	
	
mysqli_close($connection);
?>