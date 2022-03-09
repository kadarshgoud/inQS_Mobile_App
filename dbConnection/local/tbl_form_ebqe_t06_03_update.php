<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t06field05 = $_POST['t06field05'];
	$t06field06 = $_POST['t06field06'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t06 SET t06field05= '$t06field05', t06field06 = '$t06field06' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   
		   $gest05 =$row['t06field05'];  
	  $gest06 = $row['t06field06'];
		}

	  echo $gest05.':' .$gest06.':';
	}

mysqli_close($connection);
?>