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

$query = mysqli_query($connection,"SELECT * FROM  tbl_form_ebqe WHERE id_mstr_ebqe = '$id_mstr_ebqe' && id_orga_Einrichtung = '$ein'&& id_orga_Wohnbereich = '$wohn' && ende = 1 && is_delete = 0");

	$numrows=mysqli_num_rows($query); 

	if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
		  $row=mysqli_fetch_assoc($query);  
	  
		  $id = $row['id'];
		  $id_form_ebqe = $row['id_form_ebqe'];
		  $id_pers_Bewohner=$row['id_pers_Bewohner'];
		  
		  echo $id.':'.$id_form_ebqe.':'.$id_pers_Bewohner.'|';
		}
	}	
	
mysqli_close($connection);
?>