<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t16field10 = $_POST['t16field10'];
	$t16field11 = $_POST['t16field11'];


	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t16 SET t16field10= '$t16field10', t16field11 = '$t16field11' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  

      $dock10 =$row['t16field10'];
	$dock11 =$row['t16field11'];
		}
	  echo   $dock10.':' .$dock11.':';
		}
mysqli_close($connection);
?>