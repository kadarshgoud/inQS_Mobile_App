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
	
	$query = "SELECT t04field01, t04field02, t04field03, t04field04, t04field05 FROM tbl_form_ebqe_t04 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $selbst01 =$row['t04field01'];  
	  $selbst02 = $row['t04field02'];
	  $selbst03 =$row['t04field03'];  
	  $selbst04 = $row['t04field04'];
	  $selbst05 =$row['t04field05'];  
	  
       
		}
	  echo $selbst01.':' .$selbst02.':' .$selbst03.':' .$selbst04.':' .$selbst05.':';
		
	
	}
	
	
	
	
	
	mysqli_close($connection);
?>