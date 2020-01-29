<?php
require '/usr/share/php/libphp-phpmailer/class.phpmailer.php';
require '/usr/share/php/libphp-phpmailer/class.smtp.php';
session_start();

$sessmail = $_SESSION['regemail'];

$mail = new PHPMailer;
$mail->setFrom('capstonedef@gmail.com');
$mail->addAddress($sessmailx);
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
?>
