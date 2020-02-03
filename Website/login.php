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
         <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/index.php">Home</a></li>
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/about.html">About</a></li>
               <li class="nav-item"><a class="nav-link" href="https://github.com/JTBridges/Capstone-Defence.git">GitHub</a></li>
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/login.php">Login</a></li>
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/register.php">Register</a></li>
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/UnityIndex.html">Demo</a></li>
            </ul>
         </div>
      </nav>

      <div class="container">
         <div class="cont1">
            <div class="row text-center">
               <div class="col">
                  <h4>Login</h4>
                  <div style="color:#FFFFFF">
                     <form method="post" action="">
                        <input class="form-control white-border" type="text" placeholder="Username" aria-label="Username" name="loguser" required/>
                        <input class="form-control white-border" type="password" placeholder="Password" aria-label="Password" name="logpass" required/>
                        <input type="submit" name="submitlog" value="Submit" />
                     </form>
                     <div style="color:#FFFFFF">
                        <?php
                           session_start();

                           if (isset($_POST['submitlog']) ) {
                           require 'connection.php';


                           $username = $_POST['loguser'];
                           $pass = $_POST['logpass'];

                           $query = "select username,password from users where username = '$username' and password = '$pass';";

                           $result = mysqli_query($connect, $query);
                           $numrows = mysqli_num_rows($result);
                           if($numrows > 0){

                           	while($row = mysqli_fetch_array($result)) {

                           		$_SESSION['username'] = $username;
                           		header("Location: http://34.66.171.142/myaccount.php");

                           	}
                           }
                           else{
                           echo "Incorrect Username/Password.";
                           }
                           mysqli_close($connect);
                           }
                           ?>
                     </div>
                  </div>
               </div>

            </div>
         </div>
      </div>

      <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>

   </body>
</html>
