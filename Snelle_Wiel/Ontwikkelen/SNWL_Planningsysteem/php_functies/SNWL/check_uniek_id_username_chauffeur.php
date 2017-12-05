<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "snwl_planningsysteem";
    
    $username = $_REQUEST["uname"];
    $id = $_REQUEST["id"];
    
    $status_username = "uniek.";
    $status_id = "uniek";

    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "select * from `chauffeurs` where `Username` = '$username'";

    $result = mysqli_query($conn, $sql);
    if ($rij = mysqli_fetch_array($result)) {
        $status_username = "username_bestaat.";
    }

    $sql = "select * from `chauffeurs` where `ID` = '$id'";

    $result = mysqli_query($conn, $sql);
    if ($rij = mysqli_fetch_array($result)) {
        $status_id = "id_bestaat";
    }
    
    echo $status_username,$status_id;
?>