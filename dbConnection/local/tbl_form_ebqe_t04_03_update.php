<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t04field01 = $_POST['t04field01'];
	$t04field02 = $_POST['t04field02'];
	$t04field03 = $_POST['t04field03'];
	$t04field04 = $_POST['t04field04'];
	$t04field05 = $_POST['t04field05'];
	

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t04 SET t04field01= '$t04field01', t04field02 = '$t04field02', t04field03 = '$t04field03', 
	t04field04 = '$t04field04', t04field05 = '$t04field05' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   $selbst01 =$row['t04field01'];  
			$selbst02 = $row['t04field02'];
			$selbst03 =$row['t04field03'];  
			$selbst04 = $row['t04field04'];
			$selbst05 =$row['t04field05'];   

		}
	echo $selbst01.':' .$selbst02.':' .$selbst03.':' .$selbst04.':' .$selbst05.':';
	}

mysqli_close($connection);
?>