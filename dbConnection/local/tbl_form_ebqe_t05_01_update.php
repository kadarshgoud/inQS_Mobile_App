<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t05field01_03 = $_POST['t05field01_03'];
	$t05field01_02 = $_POST['t05field01_02'];
	$t05field02_03 = $_POST['t05field02_03'];
	$t05field02_02 = $_POST['t05field02_02'];
	$t05field03_03 = $_POST['t05field03_03'];
	$t05field03_02 = $_POST['t05field03_02'];
	

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t05 SET t05field01_03= '$t05field01_03', t05field01_02 = '$t05field01_02', t05field02_03 = '$t05field02_03', 
	t05field02_02 = '$t05field02_02', t05field03_03 = '$t05field03_03', t05field03_02 = '$t05field03_02' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   $bewalt01_03 =$row['t05field01_03'];  
	  $bewalt01_02 = $row['t05field01_02'];
	  $bewalt02_03 =$row['t05field02_03'];  
	  $bewalt02_02 = $row['t05field02_02'];
	  $bewalt03_03 =$row['t05field03_03'];  
	  $bewalt03_02 = $row['t05field03_02'];
		
		}
	  
	  echo $bewalt01_03.':' .$bewalt01_02.':' .$bewalt02_03.':' .$bewalt02_02.':' .$bewalt03_03.':' .$bewalt03_02.':';
	
	}

mysqli_close($connection);
?>