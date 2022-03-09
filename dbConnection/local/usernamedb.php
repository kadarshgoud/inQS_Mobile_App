<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

   
   
   


	if (isset($_POST['name']))
	{
	
	   $user = $_POST['name'];
	$sqlStmt = mysqli_query($connection,"SELECT  id_orga_Einrichtung, id_orga_wohnbereich FROM tbl_orga_benutzer WHERE Anmeldename = 'sabinesellner'");
	
	
	
	$numrows=mysqli_num_rows($sqlStmt); 
	

	
	
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $einrichtung =$row['id_orga_Einrichtung'];  
	  $wohnbereich = $row['id_orga_wohnbereich'];
       
	  
	  echo $einrichtung.':' .$wohnbereich.':';
		}
	
	}


	}
mysqli_close($connection);
?>