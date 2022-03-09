<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t11field02_05 = $_POST['t11field02_05'];
	$t11field02_06 = $_POST['t11field02_06'];
	$t11field03_01 = $_POST['t11field03_01'];
	$t11field03_02 = $_POST['t11field03_02'];
	$t11field04 = $_POST['t11field04'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t11 SET t11field02_05= '$t11field02_05', t11field02_06 = '$t11field02_06', t11field03_01 = '$t11field03_01', 
	t11field03_02 = '$t11field03_02', t11field04 = '$t11field04' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $schmerz02_05 =$row['t11field02_05'];  
	  $schmerz02_06 = $row['t11field02_06'];
	  $schmerz03_01 =$row['t11field03_01'];  
	  $schmerz03_02 = $row['t11field03_02'];
	  $schmerz04 =$row['t11field04'];  
	  
		}
	  
	  echo $schmerz02_05.':' .$schmerz02_06.':' .$schmerz03_01.':' .$schmerz03_02.':' .$schmerz04.':';
		}
mysqli_close($connection);
?>