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
	
	$query = "SELECT t04fields2, t04fields3, t04field01, t04field02, t04field03, t04field04, t04field05, t04field06, t04field07, t04field08, t04field09, t04field10, t04field11, t04field12, t04field13 
	FROM tbl_form_ebqe_t04 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $selbsts2 =$row['t04fields2'];  $selbsts3 =$row['t04fields3'];  $selbst01 =$row['t04field01'];  $selbst02 = $row['t04field02']; $selbst03 =$row['t04field03'];  
	  $selbst04 = $row['t04field04']; $selbst05 =$row['t04field05']; $selbst06 =$row['t04field06'];  $selbst07 = $row['t04field07']; $selbst08 =$row['t04field08']; $selbst09 = $row['t04field09'];
	  $selbst10 =$row['t04field10']; $selbst11 =$row['t04field11']; $selbst12 = $row['t04field12']; $selbst13 =$row['t04field13']; 
		}
		
	  echo $selbsts2.':' .$selbsts3.':' .$selbst01.':' .$selbst02.':' .$selbst03.':' .$selbst04.':' .$selbst05.':' .$selbst06.':' .$selbst07.':' .$selbst08.':' .$selbst09.':' .$selbst10.':' .$selbst11.':' .$selbst12.':' .$selbst13.':';
	}
	
	
	
	
	
	mysqli_close($connection);
?>