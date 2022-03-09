<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}
	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t05field13_03 = $_POST['t05field13_03'];
	$t05field13_02 = $_POST['t05field13_02'];
	$t05field14_03 = $_POST['t05field14_03'];
	$t05field14_02 = $_POST['t05field14_02'];
	$t05field15_03 = $_POST['t05field15_03'];
	$t05field15_02 = $_POST['t05field15_02'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t05 SET t05field13_03= '$t05field13_03', t05field13_02 = '$t05field13_02', t05field14_03 = '$t05field14_03', 
	t05field14_02 = '$t05field14_02', t05field15_03 = '$t05field15_03', t05field15_02 = '$t05field15_02' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		    
			$bewalt13_03 =$row['t05field13_03'];  
	  $bewalt13_02 = $row['t05field13_02'];
	  $bewalt14_03 =$row['t05field14_03'];  
	  $bewalt14_02 = $row['t05field14_02'];
	  $bewalt15_03 =$row['t05field15_03'];  
	  $bewalt15_02 = $row['t05field15_02'];
		
	  
	  echo $bewalt13_03.':' .$bewalt13_02.':' .$bewalt14_03.':' .$bewalt14_02.':' .$bewalt15_03.':' .$bewalt15_02.':';
	}
	}

mysqli_close($connection);
?>