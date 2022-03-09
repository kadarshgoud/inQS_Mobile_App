<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t09field01 = $_POST['t09field01'];
	$t09field02_01 = $_POST['t09field02_01'];
	$t09field02_02 = $_POST['t09field02_02'];
	$t09field02_03 = $_POST['t09field02_03'];
	$t09field02_04 = $_POST['t09field02_04'];
	$t09field02_05 = $_POST['t09field02_05'];
	$t09field02_06 = $_POST['t09field02_06'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t09 SET t09field01= '$t09field01', t09field02_01 = '$t09field02_01', t09field02_02 = '$t09field02_02', 
	t09field02_03 = '$t09field02_03', t09field02_04 = '$t09field02_04', t09field02_05 = '$t09field02_05', t09field02_06 = '$t09field02_06' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
			$row=mysqli_fetch_assoc($sqlStmt);
		   
		   $sturz01 =$row['t09field01'];  
	  $sturz02_01 =$row['t09field02_01'];
	  $sturz02_02 =$row['t09field02_02'];  
	  $sturz02_03 =$row['t09field02_03'];
	  $sturz02_04 =$row['t09field02_04'];  
	  $sturz02_05 =$row['t09field02_05'];
	  $sturz02_06 =$row['t09field02_06'];
		}
	  echo $sturz01.':' .$sturz02_01.':' .$sturz02_02.':' .$sturz02_03.':' .$sturz02_04.':' .$sturz02_05.':' .$sturz02_06.':';
	}

mysqli_close($connection);
?>