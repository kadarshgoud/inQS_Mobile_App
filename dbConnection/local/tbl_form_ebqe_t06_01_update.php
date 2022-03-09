<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t06field01 = $_POST['t06field01'];
	$t06field02 = $_POST['t06field02'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t06 SET t06field01= '$t06field01', t06field02 = '$t06field02' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   $gest01 =$row['t06field01'];  
	  $gest02 = $row['t06field02'];
       
		}
	  echo $gest01.':' .$gest02.':';
	
	}

mysqli_close($connection);
?>