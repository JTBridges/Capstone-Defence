<html lang="en">
   <head>
      <meta charset="utf-8">
      <meta http-equiv="X-UA-Compatible" content="IE=edge">
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
      <link href="main.css" rel="stylesheet" type="text/css">
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
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
			   <li class="nav-item"><a class="nav-link" href="http://34.66.171.142/UnityIndex.html">Demo</a></li>
            </ul>
         </div>
      </nav>
      <div class="container">
         <div class="row text-center justify-content-center">
            <div class="col">
               <h3 class="text-center">Capstone Defense</h3>
               <h4>Log in or Register to continue</h4>
               <div class="carobg">
                  <div id="demo" class="carousel slide" data-ride="carousel">
                     <ul class="carousel-indicators">
                        <li data-target="#demo" data-slide-to="0" class="active"></li>
                        <li data-target="#demo" data-slide-to="1"></li>
                        <li data-target="#demo" data-slide-to="2"></li>
                     </ul>
                     <div class="carousel-inner">
                        <div class="carousel-item active">
                           <img src="unity.jpg" alt="Unity" width="1200" height="675">
                        </div>
                        <div class="carousel-item">
                           <img src="castle.jpg" alt="Castle" width="auto" height="auto">
                        </div>
                        <div class="carousel-item">
                           <img src="temple.jpg" alt="Temple" width="auto" height="auto">
                        </div>
                     </div>
                     <a class="carousel-control-prev" href="#demo" data-slide="prev">
                     <span class="carousel-control-prev-icon"></span>
                     </a>
                     <a class="carousel-control-next" href="#demo" data-slide="next">
                     <span class="carousel-control-next-icon"></span>
                     </a>
                  </div>
               </div>
            </div>
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
                           if (isset($_POST['submitlog']) ) {
                           require 'connection.php';

                           $username = $_POST['loguser'];
                           $pass = $_POST['logpass'];

                           $query = "select username,password from users where username = '$username' and password = '$pass';";

                           $result = mysqli_query($connect, $query);
                           $numrows = mysqli_num_rows($result);
                           if($numrows > 0){

                           	while($row = mysqli_fetch_array($result)) {
                           		session_start();

                           		$_SESSION['username'] = $_POST[$row['username']];
                           		header("Location: http://34.66.171.142/login.php");

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
                             $query = " Insert into users(username, password, fName, lName, email, role) values ('$username','$pass','$fname','$lname','$email','default');";
                             mysqli_query($connect, $query);
			     echo "Check email";
			     mysqli_close($connect);

require '/usr/share/php/libphp-phpmailer/class.phpmailer.php';
require '/usr/share/php/libphp-phpmailer/class.smtp.php';

$mail = new PHPMailer;
$mail->setFrom('capstonedef@gmail.com');
$mail->addAddress($email);
$mail->Subject = 'Account Verification For Capstone Defense';
$mail->Body = 'Visit the following link to activate your account: ';
$mail->IsSMTP();
$mail->SMTPSecure = 'ssl';
$mail->Host = 'ssl://smtp.gmail.com';
$mail->SMTPAuth = true;
$mail->Port = 465;

//Set your existing gmail address as user name
$mail->Username = 'capstonedef@gmail.com';

//Set the password of your gmail address here
$mail->Password = '$password1';
if(!$mail->send()) {
  echo 'Email is not sent.';
  echo 'Email error: ' . $mail->ErrorInfo;
} else {
  echo 'Email has been sent.';
}


                           }
                           ?>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
      </div>
      </div>
   </body>
</html>
