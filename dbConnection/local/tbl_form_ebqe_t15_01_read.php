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
	
	$query = "SELECT t15field01, t15field02_01, t15field02_02, t15field02_03, t15field02_04, t15field02_05, t15field03 FROM tbl_form_ebqe_t15 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $beweg01 =$row['t15field01'];  
	  $beweg02_01 = $row['t15field02_01'];
	  $beweg02_02 =$row['t15field02_02'];  
	  $beweg02_03 = $row['t15field02_03'];
	  $beweg02_04 =$row['t15field02_04'];  
	  $beweg02_05 = $row['t15field02_05'];
	  $beweg03 = $row['t15field03'];
       
		}
	  echo $beweg01.':' .$beweg02_01.':' .$beweg02_02.':' .$beweg02_03.':' .$beweg02_04.':' .$beweg02_05.':' .$beweg03.':';
		
	
	}
	
	
	
	
	
	mysqli_close($connection);
?>