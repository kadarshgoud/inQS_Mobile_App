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
	
	$query = "SELECT t05field10_03, t05field10_02, t05field11_03, t05field11_02, t05field12_03, t05field12_02 
	FROM tbl_form_ebqe_t05 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
      $bewalt10_03 =$row['t05field10_03'];  
	  $bewalt10_02 = $row['t05field10_02'];
	  $bewalt11_03 =$row['t05field11_03'];  
	  $bewalt11_02 = $row['t05field11_02'];
	  $bewalt12_03 =$row['t05field12_03'];  
	  $bewalt12_02 = $row['t05field12_02'];
		
		}
	  echo $bewalt10_03.':' .$bewalt10_02.':' .$bewalt11_03.':' .$bewalt11_02.':' .$bewalt12_03.':' .$bewalt12_02.':';
		
	
	}
	
	
	
	
	
	mysqli_close($connection);
?>