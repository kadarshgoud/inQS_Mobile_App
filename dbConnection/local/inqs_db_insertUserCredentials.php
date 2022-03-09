<?php 
 
$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno())  
{ 
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n"; 
    die(); 
} 
	$woID = $_POST['id_orga_wohnbereich']; 
	$eiID = $_POST['id_orga_Einrichtung']; 
	$username = $_POST['username']; 
	$password = $_POST['password']; 
	$role = $_POST['id_orga_benutzer_gruppe'];
	$id_benutzer = $_POST['id_benutzer'];
 
	$query = "INSERT INTO tbl_mobile_user (id_orga_Einrichtung, id_orga_wohnbereich, username, password, id_orga_benutzer_gruppe, id_benutzer)  
	VALUES ('".$eiID."','".$woID."','".$username."','".$password."','".$role."','".$id_benutzer."');";  
	 
	$sqlStmt = mysqli_query($connection, $query);
	 
mysqli_close($connection); 
 
?>