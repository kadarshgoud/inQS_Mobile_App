<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t12field02_03_01 = $_POST['t12field02_03_01'];
	$t12field02_03_02 = $_POST['t12field02_03_02'];
	$t12field02_03_03 = $_POST['t12field02_03_03'];
	$t12field02_03_04 = $_POST['t12field02_03_04'];
	$t12field02_04 = $_POST['t12field02_04'];
		$t12field03 = $_POST['t12field03'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t12 SET t12field02_03_01= '$t12field02_03_01', t12field02_03_02 = '$t12field02_03_02', t12field02_03_03 = '$t12field02_03_03', 
	t12field02_03_04 = '$t12field02_03_04', t12field02_04 = '$t12field02_04', t12field03 = '$t12field03' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $heim02_03_01 =$row['t12field02_03_01'];  
	  $heim02_03_02 = $row['t12field02_03_02'];
	  $heim02_03_03 =$row['t12field02_03_03'];  
	  $heim02_03_04 = $row['t12field02_03_04'];
		$heim02_04 =$row['t12field02_04'];
		$heim03 =$row['t12field03'];	  
		}
  
	  echo $heim02_03_01.':' .$heim02_03_02.':' .$heim02_03_03.':' .$heim02_03_04.':'  .$heim02_04.':' .$heim03.':';
		}

mysqli_close($connection);
?>