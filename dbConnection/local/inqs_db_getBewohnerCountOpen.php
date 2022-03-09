<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

$id_mstr_ebqe = $_POST['id_mstr_ebqe'];
$ein = $_POST['ein'];
$wohn = $_POST['wohn'];

$query = mysqli_query($connection,"SELECT * FROM  tbl_form_ebqe WHERE id_mstr_ebqe = '$id_mstr_ebqe' && id_orga_Einrichtung = '$ein'&& id_orga_Wohnbereich = '$wohn' && ende != 1" );

	$numrows=mysqli_num_rows($query); 

    echo $numrows.':';
	
mysqli_close($connection);
?>