<?php 
        $db = mysqli_connect('localhost', 'publvfgj_tgm', 'publicideabank666','publvfgj_facebookScores') or die('Could not connect: ' . mysql_error());
 
        // Strings must be escaped to prevent SQL injection attack. 
        $name = mysqli_real_escape_string($db,$_GET['name']); 
        $posts = $_GET['posts'];
        //$posts = serialize($posts_array); 
        $hash = $_GET['hash']; 
 
        $secretKey="mySecretKey"; # Change this value to match the value stored in the client javascript below 

        echo $posts;

        //check if user is already in the database
        $sql = "SELECT * FROM scores WHERE name = '$name'";
        if($sql === FALSE){
        	die(mysqli_error($db)); // better error handling
            echo "sql false dies";
        }
        $result = mysqli_query($db,$sql);
        if ($result === FALSE){
            die(mysqli_error($db));
            echo "result false dies";
        }

        if (mysqli_num_rows($result) > 0) {
            // query user name, add score to score
            echo "number of rows: " . $result->num_rows . " ";

            while($row = mysqli_fetch_assoc($result)) {

                $real_hash = md5($name . $posts . $secretKey);
                
                //echo "username recognized, checking hash: " . $hash . " against real hash: " . $real_hash . " ";

                if($real_hash == $hash) 
                { 
                    // Send variables for the MySQL database class. 
                    $query = "UPDATE scores SET posts = '$posts' WHERE name = '$name'"; 
                    $result = mysqli_query($db,$query) or die('Query failed: ' . mysqli_error());
                    echo "post set: " . $row["posts"];
                } 
            }
        } 
        // else if (mysqli_num_rows($result) == 0)
        // {
        //     echo "hello";
        //     $real_hash = md5($name . $posts . $secretKey); 
        //     if($real_hash == $hash) 
        //     { 
        //         echo "hey there";
        //     // Send variables for the MySQL database class. 
        //         $query = "INSERT INTO scores (name, posts) VALUES ('$name', '$posts')"; 
        //         $result = mysqli_query($db,$query) or die('Query failed: ' . mysqli_error());
                 
        //     } 
        // }

        mysqli_close($db);

        
?>
