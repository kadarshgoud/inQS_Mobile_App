<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t03field11 = $_POST['t03field11'];
	$t03field12 = $_POST['t03field12'];
	$t03field13 = $_POST['t03field13'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t03 SET t03field11= '$t03field11', t03field12 = '$t03field12', t03field13 = '$t03field13' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   $verhalt11 =$row['t03field11'];  
		   $verhalt12 =$row['t03field12'];  
		   $verhalt13 =$row['t03field13'];  

		}
	echo $verhalt11.':' .$verhalt12.':' .$verhalt13.':';
	}

mysqli_close($connection);
?>