<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "snwl_planningsysteem";
    
    $uname = $_REQUEST["uname"];
    $ww = $_REQUEST["pwd"];

    $id = $_REQUEST["id"];
    $firstname = $_REQUEST["fname"];

    if(isset($_GET["insrt"])){
	$insert = $_GET["insrt"];
    }
    else{
    	$insert = "";
    }
    $lastname = $_REQUEST["lname"];
    $streetname = $_REQUEST["strname"];
    $number = $_REQUEST["nr"];
    $city = $_REQUEST["city"];

    //Salt genereren + wachtwoord encrypten
    $salt = dechex(mt_rand(0, 278317232)) . dechex(mt_rand(0, 278317232));
    $ww = hash('sha256', $ww.$salt);
    for($round = 0; $round < 65536; $round++){
        $ww = hash('sha256', $ww.$salt);
    }

    $conn = new mysqli($server, $user, $pwd, $database); 
    $sql = "insert into planners (ID, Username, Password, Salt) VALUES ('$id', '$uname', '$ww', '$salt');";
    $sql1 = "insert into plannerinfo (ID, Firstname, Insertion, Lastname, Streetname, Housenumber, City) VALUES ('$id', '$firstname',
     '$insert', '$lastname', '$streetname', '$number', '$city')";

    $result = mysqli_query($conn, $sql);
    $result1 = mysqli_query($conn, $sql1);
    
    if ($result && $result1) {
        echo "success";
    }
    else {
        echo 'failed';
    }
?>
