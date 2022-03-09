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
	
	$query = "SELECT t05field01_03, t05field01_02, t05field02_03, t05field02_02, t05field03_03, t05field03_02, t05field04_03, t05field04_02, t05field05_03, t05field05_02, t05field06_03, t05field06_02, 
	t05field07_03, t05field07_02, t05field08_03, t05field08_02, t05field09_03, t05field09_02, t05field10_03, t05field10_02, t05field11_03, t05field11_02, t05field12_03, t05field12_02, t05field13_03, 
	t05field13_02, t05field14_03, t05field14_02, t05field15_03, t05field15_02, t05field16_01, t05field16_02 FROM tbl_form_ebqe_t05 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $bewalt01_03 =$row['t05field01_03']; $bewalt01_02 = $row['t05field01_02']; $bewalt02_03 =$row['t05field02_03']; $bewalt02_02 = $row['t05field02_02']; $bewalt03_03 =$row['t05field03_03'];  
	  $bewalt03_02 = $row['t05field03_02']; $bewalt04_03 =$row['t05field04_03']; $bewalt04_02 = $row['t05field04_02']; $bewalt05_03 =$row['t05field05_03']; $bewalt05_02 = $row['t05field05_02'];
	  $bewalt06_03 =$row['t05field06_03']; $bewalt06_02 = $row['t05field06_02']; $bewalt07_03 =$row['t05field07_03'];  $bewalt07_02 = $row['t05field07_02']; $bewalt08_03 =$row['t05field08_03'];  
	  $bewalt08_02 = $row['t05field08_02']; $bewalt09_03 =$row['t05field09_03']; $bewalt09_02 = $row['t05field09_02']; $bewalt10_03 =$row['t05field10_03']; $bewalt10_02 = $row['t05field10_02'];
	  $bewalt11_03 =$row['t05field11_03']; $bewalt11_02 = $row['t05field11_02']; $bewalt12_03 =$row['t05field12_03']; $bewalt12_02 = $row['t05field12_02']; $bewalt13_03 =$row['t05field13_03'];  
	  $bewalt13_02 = $row['t05field13_02']; $bewalt14_03 =$row['t05field14_03']; $bewalt14_02 = $row['t05field14_02']; $bewalt15_03 =$row['t05field15_03']; $bewalt15_02 = $row['t05field15_02'];
	  $bewalt16_01 =$row['t05field16_01']; $bewalt16_02 = $row['t05field16_02'];

       
		}
	  echo $bewalt01_03.':' .$bewalt01_02.':' .$bewalt02_03.':' .$bewalt02_02.':' .$bewalt03_03.':' .$bewalt03_02.':' .$bewalt04_03.':' .$bewalt04_02.':' .$bewalt05_03.':' .$bewalt05_02.':' .$bewalt06_03.':' .$bewalt06_02.':' .$bewalt07_03.':' .$bewalt07_02.':' .$bewalt08_03.':' .$bewalt08_02.':' .$bewalt09_03.':' .$bewalt09_02.':' .$bewalt10_03.':' .$bewalt10_02.':' .$bewalt11_03.':' .$bewalt11_02.':' .$bewalt12_03.':' .$bewalt12_02.':' .$bewalt13_03.':' .$bewalt13_02.':' .$bewalt14_03.':' .$bewalt14_02.':' .$bewalt15_03.':' .$bewalt15_02.':' .$bewalt16_01.':' .$bewalt16_02.':';
		
	
	}
	
	
	
	
	
	mysqli_close($connection);
?>