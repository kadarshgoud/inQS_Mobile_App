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
	
	$query = "SELECT t09field01, t09field02_01, t09field02_02, t09field02_03, t09field02_04, t09field02_05, t09field02_06 
	FROM tbl_form_ebqe_t09 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $sturz01 =$row['t09field01'];  
	  $sturz02_01 =$row['t09field02_01'];
	  $sturz02_02 =$row['t09field02_02'];  
	  $sturz02_03 =$row['t09field02_03'];
	  $sturz02_04 =$row['t09field02_04'];  
	  $sturz02_05 =$row['t09field02_05'];
	  $sturz02_06 =$row['t09field02_06'];
       
		}
	  echo $sturz01.':' .$sturz02_01.':' .$sturz02_02.':' .$sturz02_03.':' .$sturz02_04.':' .$sturz02_05.':' .$sturz02_06.':';
		
	
	}
	
	
	
	
	
	mysqli_close($connection);
?>