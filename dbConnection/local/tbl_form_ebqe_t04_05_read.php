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
	
	$query = "SELECT t04field11, t04field12, t04field13 FROM tbl_form_ebqe_t04 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $selbst11 =$row['t04field11'];  
	  $selbst12 = $row['t04field12'];
	  $selbst13 =$row['t04field13'];  
	
       
		}
	  echo $selbst11.':' .$selbst12.':' .$selbst13.':';
		
	
	}
	
	
	
	
	
	mysqli_close($connection);
?>