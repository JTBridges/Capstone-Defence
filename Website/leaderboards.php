<html lang="en">
   <head>
      <meta charset="utf-8">
      <meta http-equiv="X-UA-Compatible" content="IE=edge">
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
      <link href="css/main.css" rel="stylesheet" type="text/css">
      <link rel="stylesheet" type="text/css" href="css/slicebox.css" />
  		<link rel="stylesheet" type="text/css" href="css/custom.css" />
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
      <script type="text/javascript" src="js/modernizr.custom.46884.js"></script>
      <title>Capstone Defense</title>
   </head>
   <body>
     <?php session_start() ?>
     <nav class="navbar navbar-dark bg-dark fixed-top navbar-expand-sm">
         <a class="navbar-brand" href="#">Capstone Defense</a>
         <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"> <span class="navbar-toggler-icon"></span></button>
         <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/index.php">Home</a></li>
               <li class="nav-item"><a class="nav-link" href="https://github.com/JTBridges/Capstone-Defence.git">GitHub</a></li>
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/register.php">Register</a></li>
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/UnityIndex.php">Demo</a></li>
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/leaderboards.php">Leaderboard</a></li>
            </ul>
         </div>
             <ul class="nav navbar-nav flex-row justify-content-between ml-auto">
                   <li class="dropdown order-1">
                     <button id="login" name="login" class="btn btn-secondary" onclick="window.location.href='myaccount.php'"><i class="fa fa-sign-in" aria-hidden="true"></i>
                      <?php if (isset($_SESSION['username'])) : ?>
                         <?php echo $_SESSION['username'] ?>
                      <?php else: ?>
                         Login
                      <?php endif ?>
                    </button>
                  </li>
               </ul>
           </div>
       </div>
      </nav>
      <div class="container">
         <div class="row text-center justify-content-center">
            <div class="col">
               <h4 class="text-center">Current Top Leaderboard</h4>
               <h5 style="color:white">
                Check out the top users for our game thus far! (Limit 50)
              </h4>
              <table class="table table-hover table-dark">
                <thead>
                  <tr>
                    <th scope="col">#</th>
                    <th scope="col">Alias</th>
                    <th scope="col">_____</th>
                    <th scope="col">Name</th>
                    <th scope="col">_____</th>
                    <th scope="col">Score</th>
                    <th scope="col">_____</th>
                    <th scope="col">Kills</th>
                  </tr>
                </thead>
                <tbody>
                  <?php
                       require 'connection.php';
                       $count=0; //counter for rank
                       $query = "SELECT users.username,users.fName, Leaderboards.s_score,Leaderboards.s_kills FROM users JOIN Leaderboards ON users.uID =Leaderboards.users_uID ORDER BY s_score desc LIMIT 10;";
                       $result = mysqli_query($connect, $query);
                       while($row = mysqli_fetch_assoc($result)){ $count=$count+1;?>
                      <tr>
                        <th scope="row"><?php echo $count ?></th>
                        <td><?php echo $row["username"]; ?><td>
                        <td><?php echo $row["fName"]; ?><td>
                        <td><?php echo $row["s_score"]; ?><td>
                        <td><?php echo $row["s_kills"]; ?><td>
                      </tr>
                    <?php } mysqli_close($connect);?>
                </tbody>
              </table>
               <div>
               </div>
            </div>
         </div>
      </div>
    </body>
 </html>
