<html lang="en">
   <head>
      <meta charset="utf-8">
      <meta http-equiv="X-UA-Compatible" content="IE=edge">
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
      <link href="css/main.css" rel="stylesheet" type="text/css">
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
      <script type="text/javascript" src="js/modernizr.custom.46884.js"></script>
      <title>Capstone Defense</title>
   </head>
   <body>
     <nav class="navbar navbar-dark bg-dark fixed-top navbar-expand-sm">
         <a class="navbar-brand" href="#">Capstone Defense</a>
         <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"> <span class="navbar-toggler-icon"></span></button>
         <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/index.php">Home</a></li>
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/about.html">About</a></li>
               <li class="nav-item"><a class="nav-link" href="https://github.com/JTBridges/Capstone-Defence.git">GitHub</a></li>
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/login.php">Login</a></li>
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/register.php">Register</a></li>
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/UnityIndex.html">Demo</a></li>
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/leaderboards.php">Leaderboard</a></li>
            </ul>
         </div>
      </nav>


      <div class="container">
        <div class="cont1">
            <div class="row text-center">
              <div class="col">
                <h3> <?php
                  echo "Account";
                  session_start();
                  $username = $_SESSION['username'];
                  $pass = $_SESSION['password'];

                  require 'connection.php';

                  $query = "select email,lName,fName from users where username = '$username';";
                  $result = mysqli_query($connect, $query);
                  while($row = mysqli_fetch_assoc($result)) {
                      $_SESSION['email']=$row["email"];
                      $_SESSION['fName']=$row["fName"];
                      $_SESSION['lName']=$row["lName"];
                  }
                  $email=$_SESSION['email'];
                  $fName=$_SESSION['fName'];
                  $lName=$_SESSION['lName'];

                  mysqli_close($connect);
                   ?>
                </h3>
                <h4> You can update your information accordingly </h4>
                <div style="color:#FFFFFF">
                  <form method="post" action="">
                    Username: <input class="form-control white-border" type="text" placeholder="Username" aria-label="Username" name="accuser" value=<?php echo $username?> disabled/>
                    Email: <input class="form-control white-border" type="email" placeholder="email"  aria-label="email" name="accemail" value=<?php echo $email ?> disabled/>
                    First Name: <input class="form-control white-border" type="text" placeholder="First Name"  aria-label="First Name" name="accfname" value=<?php echo $fName ?> />
                    Last Name: <input class="form-control white-border" type="text" placeholder="Last Name"  aria-label="Last Name" name="acclname" value=<?php echo $lName ?> />
                    New Password: <input class="form-control white-border" type="password" placeholder="New Password"  aria-label="New Password" name="accpass" required/>
                    Confirm Password: <input class="form-control white-border" type="password" placeholder="Confirm Password"  aria-label="Confirm Password" name="accpass2" required/>
                    <input type="submit" name="acclog" value="Update" />
                  </form>
                <div>
                  <?php
                     if (isset($_POST['acclog'])) {
                     require 'connection.php';

                       $pass = $_POST['accpass'];
                       $fname = $_POST['accfname'];
                       $lname = $_POST['acclname'];
                       $query = "UPDATE users SET password='$pass', fName='$fname', lName='$lname' WHERE email='$email';";
                       mysqli_query($connect, $query);
                       mysqli_close($connect);
                       Echo "Information was succesfully updated!";
                     }
                       ?>
                     </div>
                <div>
                   <form method="post" action="">
                      <input type="submit" name="logout" value="Log Out" />
                   </form>
                   <?php
                    if (isset($_POST['logout']) ) {
                      session_destroy();
                      header("Location: http://34.66.171.142/index.php");
                    }
                    ?>
                  </div>
            </div>
         </div>
      </div>
    </div>
  </div>
  <div class="container">
     <div class="row text-center justify-content-center">
        <div class="col">
           <h4 class="text-center">Latest Scores</h4>
           <h5 style="color:white">
            Here are your latest scores
          </h4>
          <table class="table table-hover table-dark">
            <thead>
              <tr>
                <th scope="col">#</th>
                <th scope="col">Alias</th>
                <th scope="col">Name</th>
                <th scope="col">Score</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <th scope="row">76</th>
                <td>Tester</td>
                <td>TesterName</td>
                <td>16321</td>
              </tr>
              <tr>
                <th scope="row">80</th>
                <td>Tester</td>
                <td>TesterName</td>
                <td>16321</td>
              </tr>
              <tr>
                <th scope="row">89</th>
                <td>Tester</td>
                <td>TesterName</td>
                <td>12400</td>
              </tr>
              <tr>
                <th scope="row">97</th>
                <td>Tester</td>
                <td>TesterName</td>
                <td>11000</td>
              </tr>
              <tr>
                <th scope="row">109</th>
                <td>Tester</td>
                <td>TesterName</td>
                <td>8799</td>
              </tr>
            </tbody>
          </table>
   </body>
</html>