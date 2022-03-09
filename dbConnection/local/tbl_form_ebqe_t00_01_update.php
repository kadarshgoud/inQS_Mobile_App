<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}


	
	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t00field01 = $_POST['t00field01'];
	$t00field02_1 = $_POST['t00field02_1'];
	$t00field02_2 = $_POST['t00field02_2'];
	$t00field03 = $_POST['t00field03'];
	$t00field04 = $_POST['t00field04'];
	$t00field05 = $_POST['t00field05'];
	$t00field06 = $_POST['t00field06'];
	
	
	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t00 SET t00field01= '$t00field01', t00field02_1 = '$t00field02_1', t00field02_2 = '$t00field02_2', 
	t00field03 = '$t00field03' , t00field04 = '$t00field04', t00field05 = '$t00field05', 
	t00field06 = '$t00field06' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
	

	  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   
            $field01=$row['t00field01'];  
       
	     $field02_1 =$row['t00field02_1'];  
		 $field02_2 =$row['t00field02_2'];  
		 $field03 =$row['t00field03'];  
		 $field04 =$row['t00field04'];  
		 $field05 =$row['t00field05'];  
		 $field06 =$row['t00field06']; 
		 
	  
		}
	echo $field01.':'.$field02_1.':'.$field02_2.':'.$field03.':'.$field04.':'.$field05.':'.$field06.':';
	}

mysqli_close($connection);
?>