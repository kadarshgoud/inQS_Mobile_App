<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t04field11 = $_POST['t04field11'];
	$t04field12 = $_POST['t04field12'];
	$t04field13 = $_POST['t04field13'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t04 SET t04field11= '$t04field11', t04field12 = '$t04field12', t04field13 = '$t04field13' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   $selbst11 =$row['t04field11'];  
	  $selbst12 = $row['t04field12'];
	  $selbst13 =$row['t04field13'];  
		}

	  echo $selbst11.':' .$selbst12.':' .$selbst13.':';
	}

mysqli_close($connection);
?>