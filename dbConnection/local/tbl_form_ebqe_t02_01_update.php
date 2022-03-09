<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t02field01 = $_POST['t02field01'];
	$t02field02 = $_POST['t02field02'];
	$t02field03 = $_POST['t02field03'];
	$t02field04 = $_POST['t02field04'];
	$t02field05 = $_POST['t02field05'];
	

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t02 SET t02field01= '$t02field01', t02field02 = '$t02field02', t02field03 = '$t02field03', 
	t02field04 = '$t02field04', t02field05 = '$t02field05' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   $kog01 =$row['t02field01'];  
		   $kog02 =$row['t02field02'];  
		   $kog03 =$row['t02field03'];  
		   $kog04 =$row['t02field04'];  
		   $kog05 =$row['t02field05'];  

		}
	echo $kog01.':' .$kog02.':' .$kog03.':' .$kog04.':' .$kog05.':';
	}

mysqli_close($connection);
?>