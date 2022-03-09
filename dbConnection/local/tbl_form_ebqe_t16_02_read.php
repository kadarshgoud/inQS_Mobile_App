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
	$bid=$_POST['bewonerid']; 
	
	$query = "SELECT t16field10, t16field11 
	FROM tbl_form_ebqe_t16 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo' && id_mstr_ebqe = '$wn' && id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $dock10 =$row['t16field10'];
	$dock11 =$row['t16field11'];
	
		}
	  echo   $dock10.':' .$dock11.':';
		
	
	}
	

	mysqli_close($connection);
?>