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
	
	$query = "SELECT t10field01, t10field02_01, t10field02_02, t10field02_03, t10field02_04, t10field03, t10field04 
	FROM tbl_form_ebqe_t10 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo' && id_mstr_ebqe = '$wn' && id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $freih01 =$row['t10field01'];  
	  
	  $freih02_01 =$row['t10field02_01'];
	  $freih02_02 =$row['t10field02_02'];
	  $freih02_03 =$row['t10field02_03']; 
	  $freih02_04 =$row['t10field02_04']; 
	  
	   $freih03 = $row['t10field03'];
	   $freih04 =$row['t10field04'];  
	   
	   
	  
       
		}
	  echo   $freih01.':' .$freih02_01.':' .$freih02_02.':' .$freih02_03.':' .$freih02_04.':' .$freih03.':' .$freih04.':';
		
	
	}
	
	
	
	
	
	mysqli_close($connection);
?>