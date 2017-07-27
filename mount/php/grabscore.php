<?php 
        $db = mysqli_connect('localhost', 'publvfgj_tgm', 'publicideabank666','publvfgj_facebookScores') or die('Could not connect: ' . mysql_error());
 
        // Strings must be escaped to prevent SQL injection attack. 
        $name = mysqli_real_escape_string($db,$_GET['name']); 

        $hash = $_GET['hash']; 
 
        $secretKey="mySecretKey"; # Change this value to match the value stored in the client javascript below 

        //check if user is already in the database
        $sql = "SELECT * FROM scores WHERE name = '$name'";
        if($sql === FALSE){
        	die(mysqli_error($db)); // better error handling
        }
        $result = mysqli_query($db,$sql);

        if (mysqli_num_rows($result) > 0) {
                while($row = mysqli_fetch_assoc($result)) {
                        $real_hash = md5($name . $secretKey);
                        if($real_hash == $hash) 
                        { 
                            echo $row["state"]."</next>";
                            echo $row["posts"]."</next>";
                            echo $row["messages"];
                        }     
                }
        } 
        else if (mysqli_num_rows($result) == 0)
        {
            $real_hash = md5($name . $posts . $secretKey); 
            if($real_hash == $hash) 
            { 
                // Send variables for the MySQL database class. 
                $query = "INSERT INTO scores (name) VALUES ('$name')"; 
                $result = mysqli_query($db,$query) or die('Query failed: ' . mysqli_error());
                 
            } 
        }

?>