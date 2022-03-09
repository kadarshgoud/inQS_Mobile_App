<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t02field10 = $_POST['t02field10'];
	$t02field11 = $_POST['t02field11'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t02 SET t02field10= '$t02field10', t02field11 = '$t02field11' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   $kog10 =$row['t02field10'];  
		   $kog11 =$row['t02field11'];  
}
	echo $kog10.':' .$kog11.':';
	}

mysqli_close($connection);
?>