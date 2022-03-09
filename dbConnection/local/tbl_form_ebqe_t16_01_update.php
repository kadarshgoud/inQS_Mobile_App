<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t16field01 = $_POST['t16field01'];
	$t16field02 = $_POST['t16field02'];
	$t16field03 = $_POST['t16field03'];
	$t16field04 = $_POST['t16field04'];
	$t16field05 = $_POST['t16field05'];
		$t16field06 = $_POST['t16field06'];
		$t16field07 = $_POST['t16field07'];
		$t16field08 = $_POST['t16field08'];
		$t16field09 = $_POST['t16field09'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t16 SET t16field01= '$t16field01', t16field02 = '$t16field02', t16field03 = '$t16field03', 
	t16field04 = '$t16field04', t16field05 = '$t16field05', t16field06 = '$t16field06', t16field07 = '$t16field07', t16field08 = '$t16field08', t16field09 = '$t16field09' 
	WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
      $dock01 =$row['t16field01'];
	$dock02 =$row['t16field02'];
	$dock03 =$row['t16field03'];
	$dock04 =$row['t16field04'];
	$dock05 =$row['t16field05'];
	$dock06 =$row['t16field06'];
	$dock07 =$row['t16field07'];
	$dock08 =$row['t16field08'];
	$dock09 =$row['t16field09'];
		}
	  echo   $dock01.':' .$dock02.':' .$dock03.':' .$dock04.':' .$dock05.':' .$dock06.':' .$dock07.':' .$dock08.':' .$dock09.':';
		}
mysqli_close($connection);
?>