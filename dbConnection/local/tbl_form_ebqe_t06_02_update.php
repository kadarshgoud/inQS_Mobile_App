<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t06field03 = $_POST['t06field03'];
	$t06field04 = $_POST['t06field04'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t06 SET t06field03= '$t06field03', t06field04 = '$t06field04' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   
		   $gest03 =$row['t06field03'];  
	  $gest04 = $row['t06field04'];
       
		}
	  echo $gest03.':' .$gest04.':';
	}

mysqli_close($connection);
?>