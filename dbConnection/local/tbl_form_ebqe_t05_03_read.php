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
	
	$query = "SELECT t05field07_03, t05field07_02, t05field08_03, t05field08_02, t05field09_03, t05field09_02 
	FROM tbl_form_ebqe_t05 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $bewalt07_03 =$row['t05field07_03'];  
	  $bewalt07_02 = $row['t05field07_02'];
	  $bewalt08_03 =$row['t05field08_03'];  
	  $bewalt08_02 = $row['t05field08_02'];
	  $bewalt09_03 =$row['t05field09_03'];  
	  $bewalt09_02 = $row['t05field09_02'];
       
		}
	  echo $bewalt07_03.':' .$bewalt07_02.':' .$bewalt08_03.':' .$bewalt08_02.':' .$bewalt09_03.':' .$bewalt09_02.':';
		
	
	}
	
	
	
	
	
	mysqli_close($connection);
?>