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
	
	$query = "SELECT t02field01, t02field02, t02field03, t02field04, t02field05, t02field06, t02field07, t02field08, t02field09, t02field10, t02field11 FROM tbl_form_ebqe_t02 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $kog01 =$row['t02field01'];  $kog02 = $row['t02field02']; $kog03 =$row['t02field03']; $kog04 = $row['t02field04']; $kog05 =$row['t02field05']; $kog06 =$row['t02field06'];  
	  $kog07 = $row['t02field07']; $kog08 =$row['t02field08']; $kog09 = $row['t02field09']; $kog10 =$row['t02field10']; $kog11 = $row['t02field11'];  
	  }
	  echo $kog01.':' .$kog02.':' .$kog03.':' .$kog04.':' .$kog05.':' .$kog06.':' .$kog07.':' .$kog08. ':' .$kog09. ':' .$kog10.':' .$kog11.':';
	}
	mysqli_close($connection);
?>