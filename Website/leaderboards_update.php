<?php
        require 'connection.php';

        // Strings must be escaped to prevent SQL injection attack.
        $name = mysqli_real_escape_string($connect, $_GET['users_uID']);
        $score = mysqli_real_escape_string($connect, $_GET['s_score']);
        $kills = mysqli_real_escape_string($connect, $_GET['s_kills']);
        $hash = $_GET['hash'];

        $secretKey="mySecretKey"; # Change this value to match the value stored in the client javascript below

        $real_hash = md5($name . $score . $kills . $secretKey);
        if($real_hash == $hash) {
            // Send variables for the MySQL database class.
            $query = "Insert into Leaderboards(users_uID, s_score, s_kills) values ('$name', '$score', '$kills');";
            $result = mysqli_query($connect, $query);
        }
        mysqli_close($connect);
?>
