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
         <div class="cont1">
            <div class="row text-center">
               <div class="col">
                  <h4>Register</h4>
                  <div style="color:#FFFFFF">
                     <form method="post" action="">
                        <input class="form-control white-border" type="text" placeholder="Username" aria-label="Username" name="reguser" required/>
                        <input class="form-control white-border" type="password" placeholder="Password" aria-label="Password" name="regpass" required/>
                        <input class="form-control white-border" type="password" placeholder="Confirm Password" aria-label="Confirm Password" name="regpass1" required/>
                        <input class="form-control white-border" type="text" placeholder="First Name" aria-label="First Name" name="regf"required/>
                        <input class="form-control white-border" type="text" placeholder="Last Name" aria-label="Last Name" name="regl" required/>
                        <input class="form-control white-border" type="email" placeholder="Email" aria-label="Email" name="regemail"required/>
                        <button type="submit" name="submitreg" class="btn btn-primary">Submit</button>
                        <button type="button" class="btn btn-secondary" onclick="window.location.href='login.php'">Already Registered?</button>
                     </form>
                     <div style="color:#FFFFFF">
                        <?php
                           if (isset($_POST['submitreg'])) {
                           require 'connection.php';

                             $username = $_POST['reguser'];
                             $pass = $_POST['regpass'];
                             $pass1 = $_POST['regpass1'];
                             $fname = $_POST['regf'];
                             $lname = $_POST['regl'];
                             $email = $_POST['regemail'];
                             $random_string = chr(rand(65,90)) . chr(rand(65,90)) . chr(rand(65,90)) . chr(rand(65,90)) . chr(rand(65,90)) . chr(rand(65,90)); // random(ish) 6 character string


                             $query = " Insert into users(username, password, email, fName, lName, verification) values ('$username','$pass','$email','$fname','$lname','$random_string');";
                             mysqli_query($connect, $query);

                             mysqli_close($connect);

                            require '/usr/share/php/libphp-phpmailer/class.phpmailer.php';
                            require '/usr/share/php/libphp-phpmailer/class.smtp.php';

                            $mail = new PHPMailer;
                            $mail->setFrom('capstonedef@gmail.com');
                            $mail->addAddress($email);
                            $mail->Subject = 'Account Verification For Capstone Defense';
                            $mail->Body = "Your code: '$random_string'. \nVisit the following link to activate your account: http://capstonedefense.org/verify.php.";
                            $mail->IsSMTP();
                            $mail->SMTPSecure = 'ssl';
                            $mail->Host = 'ssl://smtp.gmail.com';
                            $mail->SMTPAuth = true;
                            $mail->Port = 465;

                            //Set your existing gmail address as user name
                            $mail->Username = 'capstonedef@gmail.com';

                            //Set the password of your gmail address here
                            $mail->Password = '$password1';
                            header("Location: http://34.66.171.142/landing.php");
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

      <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>

   </body>
</html>
