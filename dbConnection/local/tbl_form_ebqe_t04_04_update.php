<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t04field06 = $_POST['t04field06'];
	$t04field07 = $_POST['t04field07'];
	$t04field08 = $_POST['t04field08'];
	$t04field09 = $_POST['t04field09'];
	$t04field10 = $_POST['t04field10'];
	

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t04 SET t04field06= '$t04field06', t04field07 = '$t04field07', t04field08 = '$t04field08', 
	t04field09 = '$t04field09', t04field10 = '$t04field10' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   $selbst06 =$row['t04field06'];  
			$selbst07 = $row['t04field07'];
			$selbst08 =$row['t04field08'];  
			$selbst09 = $row['t04field09'];
			$selbst10 =$row['t04field10'];   

		}
	echo $selbst06.':' .$selbst07.':' .$selbst08.':' .$selbst09.':' .$selbst10.':';
	}

mysqli_close($connection);
?>