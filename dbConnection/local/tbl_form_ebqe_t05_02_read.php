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
	
	$query = "SELECT t05field04_03, t05field04_02, t05field05_03, t05field05_02, t05field06_03, t05field06_02 
	FROM tbl_form_ebqe_t05 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $bewalt04_03 =$row['t05field04_03'];  
	  $bewalt04_02 = $row['t05field04_02'];
	  $bewalt05_03 =$row['t05field05_03'];  
	  $bewalt05_02 = $row['t05field05_02'];
	  $bewalt06_03 =$row['t05field06_03'];  
	  $bewalt06_02 = $row['t05field06_02'];
       
		}
	  echo $bewalt04_03.':' .$bewalt04_02.':' .$bewalt05_03.':' .$bewalt05_02.':' .$bewalt06_03.':' .$bewalt06_02.':';
		
	
	}
	
	
	
	
	
	mysqli_close($connection);
?>