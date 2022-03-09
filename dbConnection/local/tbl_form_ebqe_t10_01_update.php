<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t10field01 = $_POST['t10field01'];
	$t10field02_01 = $_POST['t10field02_01'];
	$t10field02_02 = $_POST['t10field02_02'];
	$t10field02_03 = $_POST['t10field02_03'];
	$t10field02_04 = $_POST['t10field02_04'];
	$t10field03 = $_POST['t10field03'];
	$t10field04 = $_POST['t10field04'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t10 SET t10field01= '$t10field01', t10field02_01 = '$t10field02_01', t10field02_02 = '$t10field02_02', 
	t10field02_03 = '$t10field02_03', t10field02_04 = '$t10field02_04', t10field03 = '$t10field03', t10field04 = '$t10field04' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
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