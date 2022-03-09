<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t02field06 = $_POST['t02field06'];
	$t02field07 = $_POST['t02field07'];
	$t02field08 = $_POST['t02field08'];
	$t02field09 = $_POST['t02field09'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t02 SET t02field06= '$t02field06', t02field07 = '$t02field07', t02field08 = '$t02field08', 
	t02field09 = '$t02field09' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   $kog06 =$row['t02field06'];  
		   $kog07 =$row['t02field07'];  
		   $kog08 =$row['t02field08'];  
		   $kog09 =$row['t02field09'];  
}
	echo $kog06.':' .$kog07.':' .$kog08. ':' .$kog09. ':';
	}

mysqli_close($connection);
?>