<!DOCTYPE html>
<html lang="en-us">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link href="css/main.css" rel="stylesheet" type="text/css">
    <link rel="shortcut icon" href="TemplateData/favicon.ico">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/modernizr.custom.46884.js"></script>
    <link rel="stylesheet" href="TemplateData/style.css">
    <script src="TemplateData/UnityProgress.js"></script>
    <script src="Build/UnityLoader.js"></script>
    <title>Capstone Defense</title>
    <script>
      var gameInstance = UnityLoader.instantiate("gameContainer", "Build/Desktop.json", {onProgress: UnityProgress});
    </script>
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


     <div class="webgl-content">
       <h4 class="text-center">Capstone Defense Demo</h4>
       <div id="gameContainer" style="width: 960px; height: 600px"></div>
       <div class="footer">
         <div class="webgl-logo"></div>
         <div class="fullscreen" onclick="gameInstance.SetFullscreen(1)"></div>
         <div class="title">Capstone Project</div>
       </div>
     </div>

  </body>
</html>