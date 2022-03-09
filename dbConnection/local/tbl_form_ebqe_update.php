<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}
	$master = $_POST['mstr']; $bid = $_POST['bewonerid']; $t00field01 = $_POST['t00field01']; $t00field02_1 = $_POST['t00field02_1']; $t00field02_2 = $_POST['t00field02_2'];
	$t00field03 = $_POST['t00field03']; $t00field04 = $_POST['t00field04']; $t00field05 = $_POST['t00field05']; $t00field06 = $_POST['t00field06']; $t00field07_01 = $_POST['t00field07_01'];
	$t00field07_02 = $_POST['t00field07_02']; $t00field07_03 = $_POST['t00field07_03']; $t00field07_04 = $_POST['t00field07_04']; $t00field07_05 = $_POST['t00field07_05']; $t00field07_06 = $_POST['t00field07_06'];
	$t00field08 = $_POST['t00field08']; $t00field08_01 = $_POST['t00field08_01']; $t00field08_02 = $_POST['t00field08_02']; $t00field08_03 = $_POST['t00field08_03'];
	$t00field08_04 = $_POST['t00field08_04']; $t00field09 = $_POST['t00field09']; $t00field10 = $_POST['t00field10']; $t00field11 = $_POST['t00field11']; $t00field12 = $_POST['t00field12']; $t00field13_1 = $_POST['t00field13_1'];
	$t00field13_2 = $_POST['t00field13_2']; $t00field13_3 = $_POST['t00field13_3']; $t00field13_4 = $_POST['t00field13_4']; $t00field13_5 = $_POST['t00field13_5'];
	$t00field13_6 = $_POST['t00field13_6']; $t00field13_7 = $_POST['t00field13_7']; $t00field13_7_1 = $_POST['t00field13_7_1']; $t00field13_8 = $_POST['t00field13_8'];
	$t00field13_9 = $_POST['t00field13_9']; $t00field13_10 = $_POST['t00field13_10']; $t00field13_11 = $_POST['t00field13_11'];

	$query00 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t00 SET t00field01= '$t00field01', t00field02_1 = '$t00field02_1', t00field02_2 = '$t00field02_2', 
	t00field03 = '$t00field03' , t00field04 = '$t00field04', t00field05 = '$t00field05', t00field06 = '$t00field06', t00field07_01= '$t00field07_01', t00field07_02 = '$t00field07_02', t00field07_03 = '$t00field07_03', 
	t00field07_04 = '$t00field07_04', t00field07_05 = '$t00field07_05', t00field07_06 = '$t00field07_06', t00field08 = '$t00field08', t00field08_01= '$t00field08_01', t00field08_02 = '$t00field08_02', t00field08_03 = '$t00field08_03', 
	t00field08_04 = '$t00field08_04', t00field09 = '$t00field09', t00field10 = '$t00field10', t00field11 = '$t00field11',
	t00field12 = '$t00field12', t00field13_1 = '$t00field13_1', t00field13_2= '$t00field13_2', t00field13_3 = '$t00field13_3', t00field13_4 = '$t00field13_4', 
	t00field13_5 = '$t00field13_5', t00field13_6 = '$t00field13_6', t00field13_7 = '$t00field13_7',
	t00field13_7_1 = '$t00field13_7_1', t00field13_8 = '$t00field13_8', t00field13_9 = '$t00field13_9',
	t00field13_10 = '$t00field13_10', t00field13_11 = '$t00field13_11' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt00 = mysqli_query($connection,$query00);
	
	$numrows=mysqli_num_rows($sqlStmt00); 
 
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{  
           $row=mysqli_fetch_assoc($sqlStmt00);
		   
            $field01=$row['t00field01'];  $field02_1 =$row['t00field02_1'];   $field02_2 =$row['t00field02_2'];  $field03 =$row['t00field03'];  $field04 =$row['t00field04'];  $field05 =$row['t00field05'];  
		 $field06 =$row['t00field06']; $field07_01=$row['t00field07_01'];   $field07_02 =$row['t00field07_02'];  $field07_03 =$row['t00field07_03'];  $field07_04 =$row['t00field07_04'];  
		 $field07_05 =$row['t00field07_05'];  $field07_06 =$row['t00field07_06']; $field08 =$row['t00field08']; $field08_01=$row['t00field08_01'];  $field08_02 =$row['t00field08_02'];  $field08_03 =$row['t00field08_03'];  
		 $field08_04 =$row['t00field08_04'];  $field09 =$row['t00field09']; $field10 =$row['t00field10'];  $field11 =$row['t00field11'];  $field12 =$row['t00field12'];
		 $field13_1 =$row['t00field13_1']; $field13_2 =$row['t00field13_2'];  $field13_3 =$row['t00field13_3']; $field13_4 =$row['t00field13_4'];  $field13_5 =$row['t00field13_5']; $field13_6 =$row['t00field13_6'];
		$field13_7 =$row['t00field13_7']; $field13_7_1 =$row['t00field13_7_1']; $field13_8 =$row['t00field13_8']; $field13_9 =$row['t00field13_9']; $field13_10 =$row['t00field13_10']; $field13_11 =$row['t00field13_11'];	
		}
	echo $field01.':'.$field02_1.':'.$field02_2.':'.$field03.':'.$field04.':'.$field05.':'.$field06.':' .$field07_01.':' .$field07_02.':' .$field07_03.':' .$field07_04.':' .$field07_05.':' .$field07_06.':' .$field08.':'.$field08_01.':'.$field08_02.':'.$field08_03.':'.$field08_04.':'.$field09.':' .$field10.':' .$field11.':' .$field12.':' .$field13_1.':' .$field13_2.':' .$field13_3.':' .$field13_4.':' .$field13_5.':' .$field13_6.':' .$field13_7.':' .$field13_7_1.':' .$field13_8.':' .$field13_9.':' .$field13_10.':' .$field13_11.':';
	}

mysqli_close($connection);
?>