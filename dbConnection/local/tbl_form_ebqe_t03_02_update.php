<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t03field06 = $_POST['t03field06'];
	$t03field07 = $_POST['t03field07'];
	$t03field08 = $_POST['t03field08'];
	$t03field09 = $_POST['t03field09'];
	$t03field10 = $_POST['t03field10'];
	

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t03 SET t03field06= '$t03field06', t03field07 = '$t03field07', t03field08 = '$t03field08', 
	t03field09 = '$t03field09', t03field10 = '$t03field10' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   $verhalt06 =$row['t03field06'];  
		   $verhalt07 =$row['t03field07'];  
		   $verhalt08 =$row['t03field08'];  
		   $verhalt09 =$row['t03field09'];  
		   $verhalt10 =$row['t03field10'];  

		}
	echo $verhalt06.':' .$verhalt07.':' .$verhalt08.':' .$verhalt09.':' .$verhalt10.':';
	}

mysqli_close($connection);
?>