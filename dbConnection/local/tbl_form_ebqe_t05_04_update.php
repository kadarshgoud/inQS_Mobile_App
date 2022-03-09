<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}
	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t05field10_03 = $_POST['t05field10_03'];
	$t05field10_02 = $_POST['t05field10_02'];
	$t05field11_03 = $_POST['t05field11_03'];
	$t05field11_02 = $_POST['t05field11_02'];
	$t05field12_03 = $_POST['t05field12_03'];
	$t05field12_02 = $_POST['t05field12_02'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t05 SET t05field10_03= '$t05field10_03', t05field10_02 = '$t05field10_02', t05field11_03 = '$t05field11_03', 
	t05field11_02 = '$t05field11_02', t05field12_03 = '$t05field12_03', t05field12_02 = '$t05field12_02' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		    
			$bewalt10_03 =$row['t05field10_03'];  
	  $bewalt10_02 = $row['t05field10_02'];
	  $bewalt11_03 =$row['t05field11_03'];  
	  $bewalt11_02 = $row['t05field11_02'];
	  $bewalt12_03 =$row['t05field12_03'];  
	  $bewalt12_02 = $row['t05field12_02'];
		

	  echo $bewalt10_03.':' .$bewalt10_02.':' .$bewalt11_03.':' .$bewalt11_02.':' .$bewalt12_03.':' .$bewalt12_02.':';
	}
	}
mysqli_close($connection);
?>