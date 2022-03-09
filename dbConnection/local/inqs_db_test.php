<?php
  $host_name = 'db668754826.db.1and1.com';
  $database = 'db668754826';
  $user_name = 'dbo668754826';
  $password = 'vav59nam';
  $connect = mysqli_connect($host_name, $user_name, $password, $database);

  if (mysqli_connect_errno()) {
    die('<p>Verbindung zum MySQL Server fehlgeschlagen: '.mysqli_connect_error().'</p>');
  } else {
    echo '<p>Verbindung zum MySQL Server erfolgreich aufgebaut.</p >';
  }
?>