<?php
    require 'connection.php';


    $query = "SELECT * FROM `Leaderboards` ORDER by `s_score` DESC LIMIT 5";
    $result = mysqli_query($connect,$query);

    while($row = mysqli_fetch_assoc($result)) {
        echo $row['users_uID'] . "\t" . $row['s_score'] . "\n";
    }
    mysqli_close($connect);
?>
