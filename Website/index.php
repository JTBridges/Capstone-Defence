<html lang="en">
   <head>
      <meta charset="utf-8">
      <meta http-equiv="X-UA-Compatible" content="IE=edge">
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
      <link href="main.css" rel="stylesheet" type="text/css">
      <title>Capstone Defense</title>
   </head>
   <body>
      <nav class="navbar navbar-light bg-light fixed-top navbar-expand-sm">
         <a class="navbar-brand" href="#">Capstone Defense</a>
         <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/index.php">Home</a></li>
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/about.html">About</a></li>
               <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/download.html">Download</a></li>
               <li class="nav-item"><a class="nav-link" href="https://github.com/JTBridges/Capstone-Defence.git">GitHub</a></li>
            </ul>
         </div>
      </nav>
      <div class="container">
         <div class="row text-center justify-content-center">
            <div class="col">
               <h3 class="text-center">Capstone Defense</h3>
               <h4>Log in or Register to continue</h4>
            </div>
         </div>
         <div class="container">
            <div class="cont1">
               <div class="row text-center">
                  <div class="col">
                     <h4>Login</h4>
                     <div style="color:#FFFFFF">
                        <form method="post" action="">
                           <input class="form-control white-border" type="text" placeholder="Username" aria-label="Username" name="loguser"/>
                           <input class="form-control white-border" type="text" placeholder="Password" aria-label="Password" name="logpass"/>
                           <input type="submit" name="submitlog" value="Submit" />
                        </form>
                        <div style="color:#FFFFFF">
                           <?php
                              if (isset($_POST['submitlog'])) {
                                require 'connection.php';

                                $username = $_POST['loguser'];
                                $pass = $_POST['logpass'];
                                $query = "select username,password from users where username = '$username' and password = '$pass';";
                                $result = mysqli_query($connect, $query);
                                $numrows = mysqli_num_rows($result);

                                if($numrows != 0) {
                                  while($row = mysqli_fetch_array($result)) {

                                    header("Location: http://34.66.171.142/login.php");
                                    exit();
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
                  <div class="col">
                     <h4>Register</h4>
                     <div style="color:#FFFFFF">
                        <form method="post" action="">
                           <input class="form-control white-border" type="text" placeholder="Username" aria-label="Username" name="reguser"/>
                           <input class="form-control white-border" type="text" placeholder="Password" aria-label="Password" name="regpass"/>
                           <input class="form-control white-border" type="text" placeholder="First Name" aria-label="First Name" name="regf"/>
                           <input class="form-control white-border" type="text" placeholder="Last Name" aria-label="Last Name" name="regl"/>
                           <input class="form-control white-border" type="text" placeholder="Email" aria-label="Email" name="regemail"/>
                           <input type="submit" name="submitreg" value="Submit" />
                        </form>
                        <div style="color:#FFFFFF">
                           <?php
                              if (isset($_POST['submitreg'])) {
                              require 'connection.php';

                                $username = $_POST['reguser'];
                                $pass = $_POST['regpass'];
                                $fname = $_POST['regf'];
                                $lname = $_POST['regl'];
                                $email = $_POST['regemail'];

                              $query = " Insert into users(username, password, fName, lName, email) values ('$username','$pass','$fname','$lname','$email');";
                              mysqli_query($connect, $query) or die (mysqli_error($connect));
                              mysqli_close($connect);
                                echo "Thank you  for registering, ", $username, ". Check your email for more information.";
                              }
                              ?>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </body>
</html>
