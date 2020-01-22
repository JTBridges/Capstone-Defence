<?php
define('hostname', 'localhost:3306');
define('user', 'root');
define('password', '$punjabi54');
define('databaseName', 'capstone');


$connect = mysqli_connect(hostname, user, password, databaseName);
if ($connect->connect_error) {
    die("Connection failed: " . $connect->connect_error);
} 
echo "Connected successfully";

?>